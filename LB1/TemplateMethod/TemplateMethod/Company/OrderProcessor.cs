using System;

namespace TemplateMethod.Company
{
    public abstract class OrderProcessor
    {
    
        public void ProcessOrder(Order order)
        {
            ReceiveOrder(order);
            if (!IsValidOrder())
            {
                return;
            }
            ProcessPayment();
            ShipOrder();
        }

        private void ReceiveOrder(Order order)
        {
            Console.WriteLine($"Order received: {order}");
        }

        private void ProcessPayment()
        {
            Console.WriteLine("Payment was processed");
        }
        
        
        protected abstract bool IsValidOrder();
        protected abstract void ShipOrder();
    
        
    }
}