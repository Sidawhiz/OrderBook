using System;

// AUTHORITY OF ORDERBOOK
// 1. Match, Retrieve, write and read
// 2. Retrive , write and read
// 3. Write and read
// 4. Readonly

// This is LEVEL 1

namespace TEngineServer.OrderBook
{
    public interface IMatchingOrderBook : IRetrieveOrderBook
    {
        MatchResult Match();
    }
}
