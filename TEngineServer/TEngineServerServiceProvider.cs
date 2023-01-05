using System;


namespace TEngineServer.Core
{
    public class TEngineServerServiceProvider
    {
        public TEngineServerServiceProvider()
        {
        }

        public static IServiceProvider ServiceProvider
        {
            get;
            set;
        }
    }
}
