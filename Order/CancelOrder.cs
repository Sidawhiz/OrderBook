using System;
namespace TEngineServer.Order
{
    public class CancelOrder : IOrderCore
    {
        public CancelOrder(IOrderCore order)
        {
            orderCore = order;
        }

        // FIELDS

        private readonly IOrderCore orderCore;

        // INTERFACE

        public long OrderID => orderCore.OrderID;

        public long SecurityID => orderCore.SecurityID;

        public string UserName => orderCore.UserName;
    }
}
