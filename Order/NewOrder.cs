using System;
namespace TEngineServer.Order
{
    public class NewOrder : IOrderCore
    {

        // Orders are like ------------    BUY 50 Apple-Equity @350 from Username

        // Iordercore is information of user, information of traded stock and orderid

        public NewOrder(IOrderCore order, bool isBuy, uint quantity, long price)
        {
            orderCore = order;
            IsBuy = isBuy;
            InitialQuantity = quantity;
            CurrentQuantity = quantity;
            Price = price;
        }

        public NewOrder(ModifyOrder modifyOrder) : this(modifyOrder, modifyOrder.IsBuy,modifyOrder.ModifyQuantity,modifyOrder.Price)
        {
            
        }

        // FIELDS

        private readonly IOrderCore orderCore;

        // PROPERTIES

        public long Price { get; }
        public uint InitialQuantity { get; }
        public uint CurrentQuantity { get; private set; }
        public bool IsBuy { get; }

        // INTERFACE

        public long OrderID => orderCore.OrderID;

        public long SecurityID => orderCore.SecurityID;

        public string UserName => orderCore.UserName;

        // METHODS

        public void increaseQuantity(uint x)
        {
            CurrentQuantity += x;
        }

        public void decreaseQuantity(uint x)
        {
            if (CurrentQuantity < x)
            {
                throw new InvalidOperationException($"Decrement in order is out of bounds for OrderID = {orderCore.OrderID}");
            }
            CurrentQuantity -= x;
        }
    }

}
