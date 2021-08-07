using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Threading;
using LeagueManagement.thaind.common;
using log4net;

namespace LeagueManagement.thaind.backend
{
    public class UpdateRankingWorker : BaseWorker
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(UpdateRankingWorker));
        private readonly ConcurrentDictionary<string, long> CONCURRENT_CACHE = new ConcurrentDictionary<string, long>();
        
        private bool _running = true;
        
        public UpdateRankingWorker(string workerName, string name) : base(workerName, name)
        {
        }

        protected override void RunThread()
        {
            while (_running)
            {
                long currentTime = DateTime.Now.Millisecond;
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
                    foreach (var entry in CONCURRENT_CACHE)
                    {
                        if (currentTime < entry.Value)
                        {
                            Log.Info($"Processed id: {entry.Key}, removing {entry.Key} from cached");
                            ProcessUpdate(entry.Key);
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
                    Log.Info("Do sleep");
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
                    Console.WriteLine($"Job with id: {workJob.Id}, startTime: {workJob.TimeStart}");
                    CONCURRENT_CACHE.AddOrUpdate(workJob.Id, workJob.TimeStart, (key, value) => value);
                }
            }
        }

        private void ProcessUpdate(string matchId)
        {
            
        }
    }
}