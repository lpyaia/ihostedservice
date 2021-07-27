using Microsoft.Extensions.Hosting;
using NCrontab;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace backgroundtasks.tasks
{
    public abstract class BaseHostedService : IHostedService
    {
        private readonly CrontabSchedule _cronSchedule;

        protected BaseHostedService(string cron)
        {
            _cronSchedule = CrontabSchedule
                .Parse(cron, new CrontabSchedule.ParseOptions { IncludingSeconds = true });
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(async () =>
            {
                DateTime now = DateTime.Now;
                DateTime _nextRun = _cronSchedule.GetNextOccurrence(now);

                do
                {
                    now = DateTime.Now;

                    if (now > _nextRun)
                    {
                        await DoWork();

                        _nextRun = _cronSchedule.GetNextOccurrence(DateTime.Now);
                    }

                    TimeSpan timespan = _nextRun - now;

                    await Task.Delay(timespan, cancellationToken);
                } while (!cancellationToken.IsCancellationRequested);
            });

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;

        public abstract Task DoWork();
    }
}