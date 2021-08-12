// @author duyenthai

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using LeagueManagement.thaind.common;
using LeagueManagement.thaind.dao;
using LeagueManagement.thaind.entity;
using log4net;

namespace LeagueManagement.thaind.backend
{
    public class HardResetRankingWorker : BaseWorker
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(BaseWorker));

        private readonly ConcurrentDictionary<int, bool> CONCURRENT_CACHE = new ConcurrentDictionary<int, bool>();

        private bool _running = true;

        public HardResetRankingWorker(string workerName, string name) : base(workerName, name)
        {
        }

        protected override void RunThread()
        {
            while (_running)
            {
                lock (JOB_QUEUE)
                {
                    if (!JOB_QUEUE.IsEmpty)
                    {
                        var takeOk = JOB_QUEUE.TryTake(out var job);
                        if (takeOk)
                        {
                            ValidJob(job);
                        }
                    }

                    while (!JOB_QUEUE.IsEmpty)
                    {
                        var isOk = JOB_QUEUE.TryTake(out var job);
                        if (isOk && CONCURRENT_CACHE.IsEmpty)
                        {
                            ValidJob(job);
                        }
                    }
                }

                lock (CONCURRENT_CACHE)
                {
                    foreach (var entry in CONCURRENT_CACHE)
                    {
                        if (entry.Value)
                        {
                            ProcessRefresh(entry.Key);
                        }
                    }
                }
                
                //This worker requires response immediately, do not sleep it
            }
        }

        protected override void Stop()
        {
            _running = false;
            Log.Info($"Worker {GetWorkerName()} has stopped!!!");
        }

        private void ValidJob(BaseJob job)
        {
            if (job.GetType() == typeof(HardResetRankingJob))
            {
                lock (CONCURRENT_CACHE)
                {
                    var workJob = (HardResetRankingJob) job;
                    if (CONCURRENT_CACHE.IsEmpty || !CONCURRENT_CACHE.ContainsKey(workJob.Id))
                    {
                        CONCURRENT_CACHE.TryAdd(workJob.Id, true);
                    }
                }
            }
        }

        private void ProcessRefresh(int leagueId)
        {
            try
            {
                var dhMatchDao = new DhMatchDAO();
                var dhLeagueRankingDao = new DhLeagueRankingDAO();
                var listMatches = dhMatchDao.GetMatchesByLeagueId(leagueId);
                var localCaches = new ConcurrentDictionary<int, bool>();
                foreach (var dbEntity in listMatches)
                {
                    var dhCurrentLeagueRankingHost =
                        dhLeagueRankingDao.GetByLeagueSeasonTeam(dbEntity.LeagueId, dbEntity.SeasonId,
                            dbEntity.TeamHostId, true);
                    if (dhCurrentLeagueRankingHost == null)
                    {
                        dhCurrentLeagueRankingHost = DbUtil.CreateNewRankingEntityFromMatch(dbEntity);
                    }
                    else
                    {
                        localCaches.TryGetValue(dhCurrentLeagueRankingHost.TeamId, out var hasReset);
                        if (hasReset)
                        {
                            dhCurrentLeagueRankingHost =
                                DbUtil.UpdateRankingEntityWithMatch(dhCurrentLeagueRankingHost, dbEntity);
                        }
                        else
                        {
                            var oldId = dhCurrentLeagueRankingHost.Id;
                            dhCurrentLeagueRankingHost = DbUtil.CreateNewRankingEntityFromMatch(dbEntity);
                            dhCurrentLeagueRankingHost.Id = oldId;
                            localCaches.TryAdd(dhCurrentLeagueRankingHost.TeamId, true);
                        }
                    }

                    var dhCurrentLeagueRankingAway =
                        dhLeagueRankingDao.GetByLeagueSeasonTeam(dbEntity.LeagueId, dbEntity.SeasonId,
                            dbEntity.TeamAwayId, true);
                    if (dhCurrentLeagueRankingAway == null)
                    {
                        dhCurrentLeagueRankingAway = DbUtil.CreateNewRankingEntityFromMatch(dbEntity);
                    }
                    else
                    {
                        localCaches.TryGetValue(dhCurrentLeagueRankingHost.TeamId, out var hasReset);
                        if (hasReset)
                        {
                            dhCurrentLeagueRankingAway =
                                DbUtil.UpdateRankingEntityWithMatch(dhCurrentLeagueRankingAway, dbEntity);
                        }
                        else
                        {
                            var oldId = dhCurrentLeagueRankingAway.Id;
                            dhCurrentLeagueRankingAway = DbUtil.CreateNewRankingEntityFromMatch(dbEntity);
                            dhCurrentLeagueRankingAway =
                                DbUtil.UpdateRankingEntityWithMatch(dhCurrentLeagueRankingAway, dbEntity);
                            dhCurrentLeagueRankingAway.Id = oldId;
                            localCaches.TryAdd(dhCurrentLeagueRankingAway.TeamId, true);
                        }
                    }

                    Log.Info(
                        $"Updating league ranking, host_team_id: {dbEntity.TeamHostId}, away_team_id: {dbEntity.TeamAwayId} ");
                    dhLeagueRankingDao.SaveOrUpdate(dhCurrentLeagueRankingHost);
                    dhLeagueRankingDao.SaveOrUpdate(dhCurrentLeagueRankingAway);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error ", ex);
            }
        }
    }
}