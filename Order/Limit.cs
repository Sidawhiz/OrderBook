using System;
using System.Collections.Generic;

namespace TEngineServer.Order
{
    public class Limit
    {
        public Limit(long price)
        {
            Price = price;
        }

        public long Price { get; private set; }
        public OrderBookEntry Head { get; set; }
        public OrderBookEntry Tail { get; set; }

        // Helper Properties for the limits

        public bool IsEmpty
        {
            get
            {
                return Head == null && Tail == null; // Tail isn't required
            }
        }

        // We can't have buys and sells on the same limits as they will automatically get satisfied
        // So there can be only Buy or Sell type orders at a Limit

        public Side Side
        {
            get
            {
                if (IsEmpty)
                {
                    return Side.Unknown;
                }
                if (Head.Currorder.IsBuy)
                {
                    return Side.Bid;
                }
                return Side.Ask;
            }
        }

        public uint GetLevelOrderCount()
        {
            if (IsEmpty)
            {
                return (uint)0;
            }
            uint ans = 0;
            OrderBookEntry curr = Head;
            while (curr != null)
            {
                if (curr.Currorder.CurrentQuantity != 0)
                {
                    ans += 1;
                }
                curr = curr.Next;
            }

            return ans;
        }

        public long GetLevelOrderQuantity()
        {
            if (IsEmpty)
            {
                return (uint)0;
            }
            uint ans = 0;

            OrderBookEntry curr = Head;
            while (curr != null)
            {
                ans += curr.Currorder.CurrentQuantity;
                curr = curr.Next;
            }

            return ans;
        }

        public List<OrderRecord> GetLevelOrderRecords()
        {
            List<OrderRecord> ls = new List<OrderRecord>();
            OrderBookEntry curr = Head;
            uint Queueposition = 0;
            while (curr != null)
            {
                NewOrder entry = curr.Currorder;
                if (entry.CurrentQuantity != 0)
                {
                    ls.Add(new OrderRecord(entry.OrderID, entry.CurrentQuantity, entry.Price, entry.IsBuy, entry.UserName, entry.SecurityID, Queueposition));
                    //Queueposition += 1;
                }
                Queueposition += 1;
                curr = curr.Next;
            }
            return ls;
        }
    }
}
