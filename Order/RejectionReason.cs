using System;
namespace TEngineServer.Reject
{
    public enum RejectionReason
    {
        Unknown,
        OrderIdNotfound,
        SecurityIdNotFound,
        BuySellMisread,
    }
}
