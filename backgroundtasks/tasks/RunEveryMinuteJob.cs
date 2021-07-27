using System;
using System.Threading.Tasks;

namespace backgroundtasks.tasks
{
    public class RunEveryMinuteJob : BaseHostedService
    {
        private const string cron = "0 */1 * * * *";

        public RunEveryMinuteJob() : base(cron)
        {
        }

        public override Task DoWork()
        {
            Console.WriteLine($"[RunEveryMinuteJob] - {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}