using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TEngineServer.Core.Configuration;
using TEngineServer.Logging;

namespace TEngineServer.Core
{
    public sealed class TEngineServer :BackgroundService, ITEngineServer
    {
        private readonly ITextLogger _logger; // logger and it's properties derived from json are stored in this class

        private readonly TEngineServerConfiguration _TEngineServeroptions; // this connects to .json file

        public TEngineServer(ITextLogger logger, IOptions<TEngineServerConfiguration> options)// these are the services added to server
        {
            if(logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            else
            {
                _logger = logger;
            }

            if (options.Value == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            else
            {
                _TEngineServeroptions = options.Value;
            }
        }

        public Task Run(CancellationToken token)
        {
            return ExecuteAsync(token);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            //Console.WriteLine("Log test succes2s");

            _logger.Debug("Trying", "Yes Succeeded");
            _logger.Information("shut up", "I'm studying");
            while (!stoppingToken.IsCancellationRequested)
            {

            }
            return Task.CompletedTask;
        }
    }
}
