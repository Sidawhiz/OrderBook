using System;
using System.Collections.Generic;
using TEngineServer.Order;
using TEngineServer.Instrument;


namespace TEngineServer.OrderBook
{
    public class OrderBook : IRetrieveOrderBook
    {
        // PROPERTIES OF ORDERBOOK

        private readonly Security instrument;
        private readonly SortedSet<Limit> asklimits = new SortedSet<Limit>(AskLimitComparer.comparer);
        private readonly SortedSet<Limit> buylimits = new SortedSet<Limit>(BidLimitComparer.comparer);
        private readonly Dictionary<long, OrderBookEntry> order = new Dictionary<long, OrderBookEntry>();

        public OrderBook(Security security)
        {
            instrument = security;
        }

        public int CountOrders => order.Count;

        public void AddOrder(NewOrder newOrder)
        {
            Limit limit = new Limit(newOrder.Price);
            AddOrder(limit, newOrder, newOrder.IsBuy ? buylimits : asklimits , order);
           
        }

        private static void AddOrder(Limit l, NewOrder order, SortedSet<Limit> x, Dictionary<long, OrderBookEntry> dict)
        {
            if(x.TryGetValue(l, out Limit limit))
            {
                OrderBookEntry orderBookEntry = new OrderBookEntry(order, l);
                // Now limit might exist but not have any orders on it

                if(l.Head == null)
                {
                    l.Head = orderBookEntry;
                    l.Tail = orderBookEntry;
                }
                else
                {
                    OrderBookEntry temp = l.Tail;
                    temp.Next = orderBookEntry;
                    orderBookEntry.Previous = temp;
                    l.Tail = orderBookEntry;
                }

                dict.Add(order.OrderID, orderBookEntry);
            }
            else
            {
                // If this limit doesn't exist already in the value

                OrderBookEntry orderBookEntry = new OrderBookEntry(order, l);
                x.Add(l);
                l.Head = orderBookEntry;
                l.Tail = orderBookEntry;

                dict.Add(order.OrderID,orderBookEntry);
            }
        }

        public void CancelOrder(CancelOrder cancelOrder)
        {
            if (order.TryGetValue(cancelOrder.OrderID, out OrderBookEntry value)) // gives out value of key-value pair
            {
                CancelOrder(cancelOrder, value, order);
            }
        }

        private static void CancelOrder(CancelOrder order, OrderBookEntry x, Dictionary<long, OrderBookEntry> dict)
        {
            OrderBookEntry temp = x;
            if (temp.Previous != null && temp.Next != null)
            {
                OrderBookEntry prev = temp.Previous;
                OrderBookEntry nex = temp.Next;
                prev.Next = nex;
                nex.Previous = prev;
            }
            else if(temp.Next == null)
            {
                temp.Previous.Next = null;
            }
            else
            {
                temp.Next.Previous = null;
            }

            Limit l = temp.Parentlimit;
            if(l.Head == temp && l.Tail == temp)
            {
                l.Head = null;
                l.Tail = null;
            }
            else if(l.Head == temp)
            {
                l.Head = temp.Next;
            }
            else if(l.Tail == temp)
            {
                l.Tail = temp.Previous;
            }

            dict.Remove(order.OrderID);
        }

        public bool ContainsOrder(long OrderId)
        {
            return order.ContainsKey(OrderId);
        }

        public List<OrderBookEntry> GetAskOrders()
        {
            List<OrderBookEntry> orderBookEntries = new List<OrderBookEntry>();

            foreach(Limit limit in asklimits)
            {
                if (!limit.IsEmpty)
                {
                    OrderBookEntry orderBookEntry = limit.Head;
                    while (orderBookEntry != null)
                    {
                        orderBookEntries.Add(orderBookEntry);
                        orderBookEntry = orderBookEntry.Next;
                    }
                }
            }

            return orderBookEntries;
        }

        public List<OrderBookEntry> GetBidOrders()
        {
            List<OrderBookEntry> orderBookEntries = new List<OrderBookEntry>();

            foreach (Limit limit in buylimits)
            {
                if (!limit.IsEmpty)
                {
                    OrderBookEntry orderBookEntry = limit.Head;
                    while (orderBookEntry != null)
                    {
                        orderBookEntries.Add(orderBookEntry);
                        orderBookEntry = orderBookEntry.Next;
                    }
                }
            }

            return orderBookEntries;
        }

        public OrderBookSpread GetSpread()
        {
            long? bestbid = null;
            long? bestask = null;
            SortedSet<Limit>.Enumerator enumarator = asklimits.GetEnumerator();

            Limit bestasklimit = GetLimit(enumarator);

            if (bestasklimit != null)
            {
                bestask = bestasklimit.Price;
            }

            enumarator = buylimits.GetEnumerator();

            Limit bestbuylimit = GetLimit(enumarator);

            if (bestbuylimit != null)
            {
                bestbid = bestasklimit.Price;
            }

            return new OrderBookSpread(bestbid, bestask);

        }

        static Limit GetLimit(IEnumerator<Limit> em)
        {
            Limit l = null;

            while (em.MoveNext())
            {
                if (!em.Current.IsEmpty)
                {
                    l = em.Current;
                }
            }
            return l;
        }

        public void ModifyOrder(ModifyOrder modifyOrder)
        {
            if(order.TryGetValue(modifyOrder.OrderID, out OrderBookEntry value))
            {
                CancelOrder(modifyOrder.ToCancelOrder());
                AddOrder(modifyOrder.ToNewOrder()); // MIGHT NEED TO DEBUG
            }
        }
    }
}
