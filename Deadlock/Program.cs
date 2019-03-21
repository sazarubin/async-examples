using Microsoft.AspNetCore.Hosting;

namespace Deadlock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>();
    }
}