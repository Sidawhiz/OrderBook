using System;
namespace TEngineServer.Order
{

    public class OrderBookEntry // functionality as name suggests
    {
        // PROPERTIES

        public NewOrder Currorder { get; private set; }
        public Limit Parentlimit { get; private set; }
        public DateTime CreationTime { get; private set; }

        // POINTERS

        public OrderBookEntry Next { get; set; }
        public OrderBookEntry Previous { get; set; }

        public OrderBookEntry(NewOrder currorder, Limit parentlimit) 
        {
            CreationTime = DateTime.Now;
            Parentlimit = parentlimit;
            Currorder = currorder;
        }
    }
}
