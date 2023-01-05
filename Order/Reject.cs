using System;
using TEngineServer.Order;

namespace TEngineServer.Reject
{
    public class Reject : IOrderCore
    {
        private readonly IOrderCore _ordercore;
        private readonly RejectionReason rejectionReason;

        public Reject(IOrderCore rejectedorder, RejectionReason rejection)
        {
            _ordercore = rejectedorder;
            rejectionReason = rejection;
        }

        long IOrderCore.OrderID => _ordercore.OrderID;

        long IOrderCore.SecurityID => _ordercore.SecurityID;

        string IOrderCore.UserName => _ordercore.UserName;
    }
}
