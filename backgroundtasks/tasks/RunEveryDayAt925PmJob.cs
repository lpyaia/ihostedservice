using System;
using System.Threading.Tasks;

namespace backgroundtasks.tasks
{
    public class RunEveryDayAt933PmJob : BaseHostedService
    {
        private const string cron = "0 33 21 * * *";

        public RunEveryDayAt933PmJob() : base(cron)
        {
        }

        public override Task DoWork()
        {
            Console.WriteLine($"[RunEveryDayAt933PmJob] - {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}