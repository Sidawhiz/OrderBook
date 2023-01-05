using System;

// this class contains information required from user when they send order




namespace TEngineServer.Order
{
    public class OrderCore : IOrderCore
    {
        public OrderCore(long Orderid, string username, long securityid)
        {
            OrderID = Orderid;
            UserName = username;
            SecurityID = securityid;
        }

        // OrderCore are basic values that are required for placing, modifying or cancelling order

        public long OrderID { get; }

        public long SecurityID { get; }

        public string UserName { get; }
    }
}
