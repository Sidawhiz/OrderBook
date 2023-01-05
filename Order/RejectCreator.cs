using System;
using TEngineServer.Order;

namespace TEngineServer.Reject
{
    public class RejectCreator
    {
        public RejectCreator()
        {
        }

        public static Reject GenerateRejector(IOrderCore orderCore, RejectionReason reason)
        {
            return new Reject(orderCore, reason);
        }
    }
}
