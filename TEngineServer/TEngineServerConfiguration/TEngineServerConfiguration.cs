using System;
namespace TEngineServer.Core.Configuration
{
    public class TEngineServerConfiguration
    {
        public TEngineServerServiceSettings TengineServerServiceSettings { get; set; }
    }

    public class TEngineServerServiceSettings
    {
        public int Port { get; set; }
    }
}
