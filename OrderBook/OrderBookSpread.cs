using System;
namespace TEngineServer.OrderBook
{
    public class OrderBookSpread
    {
        public OrderBookSpread(long? bid, long? ask) // question mark means ::: null value is allowed as an arguement
        {
            Bid = bid;
            Ask = ask; 
        }

        // Spread is defined by Bid and Ask
        // Edge Cases : No bids in orderbook, no asks in orderbook

        // PROPERTIES

        public long? Bid { get; private set; }
        public long? Ask { get; private set; } // long and long? are different datatypes

        //METHODS

        public long? Spread
        {
            get
            {
                if((Bid!=null && Ask!=null)||(Bid.HasValue && Ask.HasValue))
                {
                    return Ask.Value - Bid.Value;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
