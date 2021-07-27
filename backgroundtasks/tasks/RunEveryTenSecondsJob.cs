using System;
using System.Threading.Tasks;

namespace backgroundtasks.tasks
{
    public class RunEveryTenSecondsJob : BaseHostedService
    {
        private const string cron = "*/10 * * * * *";

        public RunEveryTenSecondsJob() : base(cron)
        {
        }

        public override Task DoWork()
        {
            Console.WriteLine($"[RunEveryTenSecondsJob] - {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}