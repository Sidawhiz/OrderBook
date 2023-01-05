using System;
using System.Collections.Generic;
using TEngineServer.Order;

// AUTHORITY OF ORDERBOOK
// 1. Match, Retrieve, write and read
// 2. Retrive , write and read
// 3. Write and read
// 4. Readonly

// This is LEVEL 2

namespace TEngineServer.OrderBook
{
    public interface IRetrieveOrderBook : IOrderEntryOrderBook
    {
        // this interface can retrieve the state of orderbook

        List<OrderBookEntry> GetAskOrders();

        List<OrderBookEntry> GetBidOrders();



    }
}
