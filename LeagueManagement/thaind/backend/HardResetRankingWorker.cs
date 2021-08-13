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
        private static readonly ILog Log = LogManager.GetLogger(typeof(HardResetRankingWorker));

        private readonly ConcurrentDictionary<string, HardResetRankingJob> CONCURRENT_CACHE =
            new ConcurrentDictionary<string, HardResetRankingJob>();

        private bool _running = true;

        public HardResetRankingWorker(string name) : base(name)
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
                        if (entry.Value != null)
                        {
                            Log.Info($"Process job with id: {entry.Key}");
                            ProcessRefresh(entry.Value);
                            Log.Info($"Remove job with {entry.Key}");
                            CONCURRENT_CACHE.TryRemove(entry.Key, out var isOk);
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
                    var key = "league_" + workJob.LeagueId + "_season_" + workJob.SeasonId;
                    if (CONCURRENT_CACHE.IsEmpty || !CONCURRENT_CACHE.ContainsKey(key))
                    {
                        CONCURRENT_CACHE.TryAdd(key, workJob);
                    }
                }
            }
        }

        private void ProcessRefresh(HardResetRankingJob job)
        {
            try
            {
                var dhMatchDao = new DhMatchDAO();
                var dhLeagueRankingDao = new DhLeagueRankingDAO();
                /*Delete duplicate record*/
                var listLeagueRankingByLeagueSeason =
                    dhLeagueRankingDao.GetListAllRankingByLeagueSeasonId(job.LeagueId, job.SeasonId);
                // (teamId,true)
                var cachesCheckDuplicateRanking = new ConcurrentDictionary<int, bool>();
                listLeagueRankingByLeagueSeason.ForEach(ranking =>
                {
                    if (cachesCheckDuplicateRanking.ContainsKey(ranking.TeamId))
                    {
                        dhLeagueRankingDao.Delete(ranking);
                    }
                    else
                    {
                        cachesCheckDuplicateRanking.TryAdd(ranking.TeamId, true);
                    }
                });
                /*End check duplicate record*/

                var listMatches = dhMatchDao.GetListFinishedMatchesByLeagueSeasonId(job.LeagueId, job.SeasonId);
                /*Reset record go here*/
                var localCaches = new ConcurrentDictionary<int, bool>();
                foreach (var dbEntity in listMatches)
                {
                    var dhCurrentLeagueRankingHost =
                        dhLeagueRankingDao.GetByLeagueSeasonTeam(dbEntity.LeagueId, dbEntity.SeasonId,
                            dbEntity.TeamHostId, true);
                    if (dhCurrentLeagueRankingHost == null)
                    {
                        dhCurrentLeagueRankingHost = CreateNewAndUpdate(dbEntity, true);
                        localCaches.TryAdd(dhCurrentLeagueRankingHost.TeamId, true);
                    }
                    else
                    {
                        localCaches.TryGetValue(dhCurrentLeagueRankingHost.TeamId, out var hasResetHost);
                        if (hasResetHost)
                        {
                            dhCurrentLeagueRankingHost =
                                DbUtil.UpdateRankingEntityWithMatch(dhCurrentLeagueRankingHost, dbEntity);
                        }
                        else
                        {
                            dhCurrentLeagueRankingHost = CreateNewAndUpdate(dbEntity, true);
                            localCaches.TryAdd(dhCurrentLeagueRankingHost.TeamId, true);
                        }
                    }

                    var dhCurrentLeagueRankingAway =
                        dhLeagueRankingDao.GetByLeagueSeasonTeam(dbEntity.LeagueId, dbEntity.SeasonId,
                            dbEntity.TeamAwayId, true);
                    if (dhCurrentLeagueRankingAway == null)
                    {
                        dhCurrentLeagueRankingAway = CreateNewAndUpdate(dbEntity, false);
                        localCaches.TryAdd(dhCurrentLeagueRankingAway.TeamId, true);
                    }
                    else
                    {
                        localCaches.TryGetValue(dhCurrentLeagueRankingAway.TeamId, out var hasResetAway);
                        if (hasResetAway)
                        {
                            dhCurrentLeagueRankingAway =
                                DbUtil.UpdateRankingEntityWithMatch(dhCurrentLeagueRankingAway, dbEntity);
                        }
                        else
                        {
                            dhCurrentLeagueRankingAway = CreateNewAndUpdate(dbEntity, false);
                            localCaches.TryAdd(dhCurrentLeagueRankingAway.TeamId, true);
                        }
                    }

                    Log.Info(
                        $"Resetting league ranking, host_team_id: {dbEntity.TeamHostId}, away_team_id: {dbEntity.TeamAwayId} ");
                    dhLeagueRankingDao.SaveOrUpdate(dhCurrentLeagueRankingHost);
                    dhLeagueRankingDao.SaveOrUpdate(dhCurrentLeagueRankingAway);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error ", ex);
            }
        }

        private DhLeagueRanking CreateNewAndUpdate(DhMatch match, bool isHost)
        {
            var newDhLeagueRanking = DbUtil.CreateNewRankingEntityFromMatch(match, isHost);
            return DbUtil.UpdateRankingEntityWithMatch(newDhLeagueRanking, match);
        }
    }
}