using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace TargetWebAPI2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider((_, opt) =>
                {
                    opt.ValidateScopes = true;
                    opt.ValidateOnBuild = true;
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                });
    }
}
