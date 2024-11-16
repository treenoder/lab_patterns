namespace Logistics;

// Елементи
public interface ILogisticsOperation
{
    void Accept(ILogisticsVisitor visitor);
}

public class Cargo : ILogisticsOperation
{
    public double Weight { get; set; }
    public string Destination { get; set; }

    public void Accept(ILogisticsVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class TransportMode : ILogisticsOperation
{
    public string Mode { get; set; } // e.g., "Air", "Sea", "Road"

    public void Accept(ILogisticsVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Відвідувачі
public interface ILogisticsVisitor
{
    void Visit(Cargo cargo);
    void Visit(TransportMode transportMode);
}

public class ShippingCostCalculator : ILogisticsVisitor
{
    public double TotalCost { get; private set; }

    public void Visit(Cargo cargo)
    {
        // Проста логіка розрахунку
        TotalCost += cargo.Weight * 10; // $10 per kg
    }

    public void Visit(TransportMode transportMode)
    {
        switch (transportMode.Mode)
        {
            case "Air":
                TotalCost += 500;
                break;
            case "Sea":
                TotalCost += 200;
                break;
            case "Road":
                TotalCost += 300;
                break;
        }
    }
}

public class TransitTimeEstimator : ILogisticsVisitor
{
    public double TotalTime { get; private set; } // in days

    public void Visit(Cargo cargo)
    {
        // Можлива додаткова логіка
    }

    public void Visit(TransportMode transportMode)
    {
        switch (transportMode.Mode)
        {
            case "Air":
                TotalTime += 2;
                break;
            case "Sea":
                TotalTime += 20;
                break;
            case "Road":
                TotalTime += 7;
                break;
        }
    }
}

public class Program
{
    public static void Main()
    {
        List<ILogisticsOperation> operations = new List<ILogisticsOperation>
        {
            new Cargo { Weight = 100, Destination = "New York" },
            new TransportMode { Mode = "Air" }
        };

        ILogisticsVisitor costCalculator = new ShippingCostCalculator();
        ILogisticsVisitor timeEstimator = new TransitTimeEstimator();

        foreach (var op in operations)
        {
            op.Accept(costCalculator);
            op.Accept(timeEstimator);
        }

        ShippingCostCalculator calculator = costCalculator as ShippingCostCalculator;
        TransitTimeEstimator estimator = timeEstimator as TransitTimeEstimator;

        Console.WriteLine($"Total Shipping Cost: ${calculator.TotalCost}");
        Console.WriteLine($"Estimated Transit Time: {estimator.TotalTime} days");
    }
}

// Output:
// Total Shipping Cost: $1500
// Estimated Transit Time: 2 days