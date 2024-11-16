namespace Restaurant;

using System;
using System.Collections.Generic;

// Елементи
public interface IOrderComponent
{
    void Accept(IOrderVisitor visitor);
}

public class FoodItem : IOrderComponent
{
    public string Name { get; set; }
    public double Price { get; set; }

    public void Accept(IOrderVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class BeverageItem : IOrderComponent
{
    public string Name { get; set; }
    public double Price { get; set; }

    public void Accept(IOrderVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Order : IOrderComponent
{
    public List<IOrderComponent> Items { get; set; } = new List<IOrderComponent>();

    public void Accept(IOrderVisitor visitor)
    {
        foreach (var item in Items)
        {
            item.Accept(visitor);
        }

        visitor.Visit(this);
    }
}

// Відвідувачі
public interface IOrderVisitor
{
    void Visit(FoodItem food);
    void Visit(BeverageItem beverage);
    void Visit(Order order);
}

public class OrderProcessor : IOrderVisitor
{
    public void Visit(FoodItem food)
    {
        Console.WriteLine($"Processing food item: {food.Name}");
    }

    public void Visit(BeverageItem beverage)
    {
        Console.WriteLine($"Processing beverage item: {beverage.Name}");
    }

    public void Visit(Order order)
    {
        Console.WriteLine("Order processing complete.");
    }
}

public class CostCalculator : IOrderVisitor
{
    public double TotalCost { get; private set; } = 0;

    public void Visit(FoodItem food)
    {
        TotalCost += food.Price;
    }

    public void Visit(BeverageItem beverage)
    {
        TotalCost += beverage.Price;
    }

    public void Visit(Order order)
    {
        Console.WriteLine($"Total Cost: ${TotalCost}");
    }
}

public class BillGenerator : IOrderVisitor
{
    public void Visit(FoodItem food)
    {
        Console.WriteLine($"Food: {food.Name} - ${food.Price}");
    }

    public void Visit(BeverageItem beverage)
    {
        Console.WriteLine($"Beverage: {beverage.Name} - ${beverage.Price}");
    }

    public void Visit(Order order)
    {
        Console.WriteLine("Bill generated.");
    }
}

public class Program
{
    public static void Main()
    {
        Order order = new Order();
        order.Items.Add(new FoodItem { Name = "Steak", Price = 25.0 });
        order.Items.Add(new BeverageItem { Name = "Wine", Price = 15.0 });
        order.Items.Add(new FoodItem { Name = "Salad", Price = 10.0 });

        IOrderVisitor processor = new OrderProcessor();
        IOrderVisitor costCalculator = new CostCalculator();
        IOrderVisitor billGenerator = new BillGenerator();

        Console.WriteLine("Processing Order:");
        order.Accept(processor);

        Console.WriteLine("\nCalculating Cost:");
        order.Accept(costCalculator);

        Console.WriteLine("\nGenerating Bill:");
        order.Accept(billGenerator);
    }
}

// Output:
// Processing Order:
// Processing food item: Steak
// Processing beverage item: Wine
// Processing food item: Salad
// Order processing complete.
// 
// Calculating Cost:
// Total Cost: $50
// 
// Generating Bill:
// Food: Steak - $25
// Beverage: Wine - $15
// Food: Salad - $10
// Bill generated.