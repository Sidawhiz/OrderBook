using System;
using System.Threading;
using System.Threading.Tasks;

namespace TEngineServer.Core
{
    interface ITEngineServer
    {
        Task Run(CancellationToken token);
    }
}
