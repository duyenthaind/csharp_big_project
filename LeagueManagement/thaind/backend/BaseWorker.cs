using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using log4net;

namespace LeagueManagement.thaind.backend
{
    public abstract class BaseWorker
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(BaseWorker));
        
        private Thread _thread;
        private string workerName;

        private static ConcurrentDictionary<string, List<BaseWorker>> ALL_WORKERS =
            new ConcurrentDictionary<string, List<BaseWorker>>();

        protected ConcurrentBag<BaseJob> JOB_QUEUE = new ConcurrentBag<BaseJob>();

        protected BaseWorker(string workerName, string name)
        {
            _thread = new Thread(new ThreadStart(this.RunThread));
            _thread.Name = name;
            this.workerName = workerName;
        }

        public void Start() => _thread.Start();
        public void Join() => _thread.Join();
        public bool IsAlive => _thread.IsAlive;

        public string GetWorkerName()
        {
            return workerName;
        }

        protected abstract void RunThread();
        protected abstract void Stop();

        public void Register()
        {
            if (_thread.Name != null)
            {
                var id = _thread.Name;
                if (!ALL_WORKERS.ContainsKey(id))
                {
                    var listWorker = new List<BaseWorker>();
                    ALL_WORKERS.TryAdd(id, listWorker);
                    listWorker.Add(this);
                }
                else
                {
                    var isOk = ALL_WORKERS.TryGetValue(id, out var listWorker);
                    if (isOk)
                    {
                        listWorker.Add(this);
                    }
                }

                var isOk2 = ALL_WORKERS.TryGetValue(id, out var listWorker2);
                log.Info($"Register worker name: {workerName}, group: {id}, size: {listWorker2?.Count ?? -1}");
            }
        }

        public static void PubJob(string groupName, int workerChooseIndex, BaseJob job)
        {
            try
            {
                if (groupName != null)
                {
                    var isOk = ALL_WORKERS.TryGetValue(groupName, out var listWorker);
                    if (isOk)
                    {
                        if (workerChooseIndex > -1)
                        {
                            listWorker[listWorker.Count % workerChooseIndex].JOB_QUEUE.Add(job);
                        }
                        else
                        {
                            listWorker[new Random(listWorker.Count).Next()].JOB_QUEUE.Add(job);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("Error when process pack, " , ex);
            }
        }

        public static void StopAllWorker()
        {
            try
            {
                foreach(var entry in ALL_WORKERS)
                {
                    entry.Value.ForEach(index => index.Stop());
                    log.Info($"Stop all workers in group {entry.Key}");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error when stop all workers: ", ex);
            }
        }
    }
}