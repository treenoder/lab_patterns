using System;

namespace TemplateMethod.Company
{
    public class IndividualOrderProcessor: OrderProcessor
    {
        protected override bool IsValidOrder()
        {
            Console.WriteLine("Validated individual order");
            return true;
        }

        protected override void ShipOrder()
        {
            Console.WriteLine("Shipped individual order");
        }
    }
}