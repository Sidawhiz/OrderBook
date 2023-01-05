using System;
namespace TEngineServer.Order
{
    public class ModifyOrder : IOrderCore
    {
        // ORDER MODIFYING IS DONE BY CANCELLING PREVIOUS ORDER AND PLACING NEW ORDER

        public ModifyOrder(IOrderCore order, bool isBuy, uint quantity, long price)
        {
            orderCore = order;
            IsBuy = isBuy;
            ModifyQuantity = quantity;
            Price = price;
        }

        // PROPERTIES

        public long Price { get; }
        public uint ModifyQuantity { get; }
        public bool IsBuy { get; }

        // FIELDS

        private readonly IOrderCore orderCore;

        // INTERFACE

        public long OrderID => orderCore.OrderID;

        public long SecurityID => orderCore.SecurityID;

        public string UserName => orderCore.UserName;

        // METHODS

        public CancelOrder ToCancelOrder()
        {
            return new CancelOrder(this);
        }

        public NewOrder ToNewOrder()
        {
            return new NewOrder(this);
        }
    }
}
