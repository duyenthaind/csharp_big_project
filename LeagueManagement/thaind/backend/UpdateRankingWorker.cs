using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using LeagueManagement.thaind.common;
using LeagueManagement.thaind.dao;
using log4net;

namespace LeagueManagement.thaind.backend
{
    public class UpdateRankingWorker : BaseWorker
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UpdateRankingWorker));

        private readonly ConcurrentDictionary<string, UpdateRankingJob> CONCURRENT_CACHE =
            new ConcurrentDictionary<string, UpdateRankingJob>();

        private bool _running = true;

        public UpdateRankingWorker(string name) : base(name)
        {
        }

        protected override void RunThread()
        {
            while (_running)
            {
                long currentTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                lock (JOB_QUEUE)
                {
                    while (!JOB_QUEUE.IsEmpty)
                    {
                        var isOk = JOB_QUEUE.TryTake(out var job);
                        if (isOk)
                        {
                            ResolveJob(job);
                        }
                    }
                }

                lock (CONCURRENT_CACHE)
                {
                    var dhMatchDao = new DhMatchDAO();
                    var dhLeagueRankingDao = new DhLeagueRankingDAO();
                    foreach (var entry in CONCURRENT_CACHE)
                    {
                        if (currentTime > entry.Value.TimeStart)
                        {
                            ProcessUpdate(entry.Value, dhMatchDao, dhLeagueRankingDao);
                            Log.Info($"Processed id: {entry.Key}, removing {entry.Key} from cached");
                            CONCURRENT_CACHE.TryRemove(entry.Key, out var isOk);
                        }
                        else
                        {
                            Log.Info($"Skipping entry with key {entry.Key}");
                        }
                    }
                }

                try
                {
                    // Log.Info("Do sleep");
                    Thread.Sleep(TimeSpan.FromSeconds(Config.RANKING_WORKER_INTERVAL));
                }
                catch (Exception ex)
                {
                    Log.Error("Concurrent exception, ", ex);
                }
            }
        }

        protected override void Stop()
        {
            _running = false;
            Log.Info($"Worker {GetWorkerName()} has stopped!!!");
        }

        private void ResolveJob(BaseJob job)
        {
            if (job.GetType() == typeof(UpdateRankingJob))
            {
                lock (CONCURRENT_CACHE)
                {
                    var workJob = (UpdateRankingJob) job;
                    // if this job is still not processed then update it
                    Log.Debug($"Job with id: match_{workJob.Id}, startTime: {workJob.TimeStart}");
                    CONCURRENT_CACHE.AddOrUpdate("match_" + workJob.Id, workJob, (key, value) => value);
                }
            }
        }

        private void ProcessUpdate(UpdateRankingJob job, DhMatchDAO dhMatchDao, DhLeagueRankingDAO dhLeagueRankingDao)
        {
            try
            {
                var dbEntity = dhMatchDao.GetById(job.Id, true);
                if (dbEntity == null)
                {
                    return;
                }

                var dhCurrentLeagueRankingHost =
                    dhLeagueRankingDao.GetByLeagueSeasonTeam(dbEntity.LeagueId, dbEntity.SeasonId, dbEntity.TeamHostId,
                        true);
                if (dhCurrentLeagueRankingHost == null)
                {
                    dhCurrentLeagueRankingHost = DbUtil.CreateNewRankingEntityFromMatch(dbEntity, true);
                }

                dhCurrentLeagueRankingHost =
                    DbUtil.UpdateRankingEntityWithMatch(dhCurrentLeagueRankingHost, dbEntity);
                var dhCurrentLeagueRankingAway =
                    dhLeagueRankingDao.GetByLeagueSeasonTeam(dbEntity.LeagueId, dbEntity.SeasonId, dbEntity.TeamAwayId,
                        true);
                if (dhCurrentLeagueRankingAway == null)
                {
                    dhCurrentLeagueRankingAway = DbUtil.CreateNewRankingEntityFromMatch(dbEntity, false);
                }

                dhCurrentLeagueRankingAway =
                    DbUtil.UpdateRankingEntityWithMatch(dhCurrentLeagueRankingAway, dbEntity);
                Log.Info(
                    $"Updating league ranking, host_team_id: {dbEntity.TeamHostId}, away_team_id: {dbEntity.TeamAwayId} ");
                dhLeagueRankingDao.SaveOrUpdate(dhCurrentLeagueRankingHost);
                dhLeagueRankingDao.SaveOrUpdate(dhCurrentLeagueRankingAway);
            }
            catch (Exception ex)
            {
                Log.Error("Error", ex);
            }
        }
    }
}