using System;
namespace TEngineServer.Order
{
    // Readonly representatuon of order
    public record OrderRecord(long OrderID, uint Quantity, long Price, bool IsBuy, string username, long SecurityID, uint QueuePosition);
}
