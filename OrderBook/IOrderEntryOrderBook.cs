using System;
using TEngineServer.Order;

// AUTHORITY OF ORDERBOOK
// 1. Match, Retrieve, write and read
// 2. Retrive , write and read
// 3. Write and read
// 4. Readonly

// This is LEVEL 3

namespace TEngineServer.OrderBook
{
    public interface IOrderEntryOrderBook: IReadOnlyOrderBook 
    {
        // this is to write in orderbook, if we're writing in then we should be able to read as well

        void AddOrder(NewOrder newOrder);

        void ModifyOrder(ModifyOrder modifyOrder);

        void CancelOrder(CancelOrder cancelOrder);
    }
}
