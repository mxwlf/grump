using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace grump.hosting
{
    public class LoggingExtensions
    {
        public static void EnsureLoggerIsAvailable(IServiceCollection serviceCollection, IConfigurationBuilder configurationBuilder)
        {
            serviceCollection.AddLogging(x =>
            {
                var configuration = configurationBuilder.Build();
                
                x.AddConfiguration(configuration);
                x.AddConsole(); 
                x.AddSeq();
                x.AddDebug();
                x.AddStructuredFileLogger(x =>
                {
                    x.FolderPath = "/logs/";
                });
            });
        }
    }
}