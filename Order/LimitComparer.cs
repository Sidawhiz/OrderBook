using System;
using System.Collections.Generic;

namespace TEngineServer.Order
{
    public class BidLimitComparer : IComparer<Limit>
    {

        public static IComparer<Limit> comparer { get; } = new BidLimitComparer();

        public int Compare(Limit x, Limit y)
        {
            if (x.Price == y.Price)
            {
                return 0;
            }
            else if (x.Price > y.Price)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

    public class AskLimitComparer : IComparer<Limit>
    {

        public static IComparer<Limit> comparer { get; } = new AskLimitComparer();

        public int Compare(Limit x, Limit y)
        {
            if (x.Price == y.Price)
            {
                return 0;
            }
            else if (x.Price < y.Price)
            {
                return -1;
            }
            else
            {
                return 1;
            }
        }
    }

}
