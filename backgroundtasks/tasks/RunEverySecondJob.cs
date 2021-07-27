using System;
using System.Threading.Tasks;

namespace backgroundtasks.tasks
{
    public class RunEverySecondJob : BaseHostedService
    {
        private const string cron = "*/1 * * * * *";

        public RunEverySecondJob() : base(cron)
        {
        }

        public override Task DoWork()
        {
            Console.WriteLine($"[RunEverySecondJob] - {DateTime.Now}");
            return Task.CompletedTask;
        }
    }
}