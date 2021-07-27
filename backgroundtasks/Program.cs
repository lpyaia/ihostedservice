using backgroundtasks.tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace backgroundtasks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureServices(services =>
                {
                    services.AddHostedService<RunEveryTenSecondsJob>();
                    services.AddHostedService<RunEveryMinuteJob>();
                    services.AddHostedService<RunEveryDayAt933PmJob>();
                    services.AddHostedService<RunEverySecondJob>();
                });
    }
}