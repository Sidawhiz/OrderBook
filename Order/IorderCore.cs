using System;

namespace TEngineServer.Order
{
    public interface IOrderCore
    {
        public long OrderID { get; }

        public long SecurityID { get; }

        public string UserName { get; }

    }
}
