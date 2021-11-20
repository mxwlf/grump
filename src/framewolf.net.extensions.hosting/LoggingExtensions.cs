using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace framewolf.net.Extensions.Hosting
{
    public static class LoggingExtensions
    {
        // public static void EnsureLoggerIsAvailable(IServiceCollection serviceCollection, IConfigurationBuilder configurationBuilder)
        // {
        //     serviceCollection.AddLogging(x =>
        //     {
        //         var configuration = configurationBuilder.Build();
        //         
        //         x.AddConfiguration(configuration);
        //         x.AddConsole(); 
        //         x.AddSeq();
        //         x.AddDebug();
        //         x.AddStructuredFileLogger(x =>
        //         {
        //             x.FolderPath = "/logs/";
        //         });
        //     });
        // }

        // public static IWolfHostBuilder AddLogging(this IWolfHostBuilder hostBuilder, Action<ILoggingBuilder> loggingBuilder)
        // {
        //     hostBuilder.GenericHostBuilder.ConfigureLogging(loggingBuilder);
        //     return hostBuilder;
        // }
        //
        // public static ILoggingBuilder AddStructuredFileLogger(this ILoggingBuilder builder, Action<StructuredFileLoggerOptions> configure)
        // {
        //     builder.Services.AddSingleton<ILoggerProvider, StructuredFileLoggerProvider>();
        //     builder.Services.Configure(configure);
        //     return builder;
        // }
    }
}