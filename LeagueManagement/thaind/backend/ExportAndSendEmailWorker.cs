// @author duyenthai

using System;
using System.Threading;
using LeagueManagement.thaind.common;
using log4net;

namespace LeagueManagement.thaind.backend
{
    public class ExportAndSendEmailWorker : BaseWorker
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(ExportAndSendEmailWorker));

        private static bool _running = true;

        public ExportAndSendEmailWorker(string name) : base(name)
        {
        }

        protected override void RunThread()
        {
            while (_running)
            {
                lock (JOB_QUEUE)
                {
                    while (!JOB_QUEUE.IsEmpty)
                    {
                        var takeOk = JOB_QUEUE.TryTake(out var job);
                        if (takeOk)
                        {
                            ExportAndSendMail(job);
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

        private void ExportAndSendMail(BaseJob job)
        {
            try
            {
                Log.Info("Try do job: " + job);
                if (job.GetType() == typeof(ExportAndSendEmailJob))
                {
                }
            }
            catch (Exception ex)
            {
                Log.Error("Error ", ex);
            }
        }
    }
}