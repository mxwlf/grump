using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace framewolf.net.Extensions.Hosting
{
    public class WolfHost 
    {
        private readonly IHost _genericHost;

        public static IHostBuilder CreateDefaultHostBuilder(string[] args)
        {
            
            return Host.CreateDefaultBuilder(args)
            .ConfigureLogging(config =>
            {
                config.AddSeq();
                config.AddConsole(consoleLoggerOptions =>
                {
                    consoleLoggerOptions.LogToStandardErrorThreshold = LogLevel.Debug;
                });
            });

        }
    }
}