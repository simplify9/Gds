using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using SW.EfCoreExtensions;
using SW.Logger;

namespace SW.Gds.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).
                UseSwLogger().
                Build().
                MigrateDatabase<GdsDbContext>().
                Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
