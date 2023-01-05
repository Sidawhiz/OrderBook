using System;
namespace TEngineServer.Order
{
    public sealed class CreateOrderStatus
    {
        public CreateOrderStatus()
        {
        }

        // These methods will be filled later

        public static CancelOrderStatus GeneratecancelOrderStatus(CancelOrder cancel)
        {
            return new CancelOrderStatus();
        }

        public static NewOrderStatus GenerateNewOrderStatus(CancelOrder cancel)
        {
            return new NewOrderStatus();
        }

        public static ModifyOrderStatus GeneratemodifyOrderStatus(CancelOrder cancel)
        {
            return new ModifyOrderStatus();
        }

    }
}
