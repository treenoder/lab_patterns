using System;

namespace TemplateMethod.Company
{
    public class CorporateOrderProcessor: OrderProcessor
    {
        protected override bool IsValidOrder()
        {
            Console.WriteLine("Validated corporate order");
            return true;
        }

        protected override void ShipOrder()
        {
            Console.WriteLine("Shipped corporate order");
        }
    }
}