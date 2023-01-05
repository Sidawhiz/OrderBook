using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TEngineServer.Core.Configuration;
using TEngineServer.Logging;
using TEngineServer.Logging.LoggingCOnfiguration;

namespace TEngineServer.Core
{
    public sealed class TEngineServerHostBuilder
    {
        public TEngineServerHostBuilder()
        {
        }

        public static IHost BuildTradingEngineServer() // Here ConfigureServices and Configure are built in host itself 
        {
            return Host.CreateDefaultBuilder().ConfigureServices((context,services)=>
            {
                // Configuration of Json
                services.AddOptions();
                services.Configure<TEngineServerConfiguration>(context.Configuration.GetSection(nameof(TEngineServerConfiguration)));

                // logging configuration from json is added
                services.Configure<LoggingConfiguration>(context.Configuration.GetSection(nameof(LoggingConfiguration)));

                // Add Singleton
                services.AddSingleton<ITEngineServer,TEngineServer>(); // this is a middleware request specifier

                //Custom Textlogger class is added as service to host
                services.AddSingleton<ITextLogger, TextLogger>();


                // Add Hosted Service
                services.AddHostedService<TEngineServer>();
            }).Build();
        }
    }
}
