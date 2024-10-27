using System;

namespace TemplateMethod.Company
{
    public struct Order
    {
        public OrderType Type { get; }
        
        public Order(OrderType type)
        {
            Type = type;
        }
        
        public override string ToString()
        {
            return $"{Type} Order";
        }
    }
}