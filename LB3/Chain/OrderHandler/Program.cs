namespace OrderHandler;

// Абстрактний клас обробника
public abstract class OrderHandler
{
    protected OrderHandler _nextHandler;

    public void SetNext(OrderHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void HandleOrder(Order order);
}

// Конкретний обробник для базових замовлень
public class BasicOrderHandler : OrderHandler
{
    public override void HandleOrder(Order order)
    {
        if (order.Amount <= 1000)
        {
            Console.WriteLine($"BasicOrderHandler: Обробка замовлення №{order.OrderId} на суму {order.Amount} грн.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleOrder(order);
        }
    }
}

// Конкретний обробник для просунутих замовлень
public class AdvancedOrderHandler : OrderHandler
{
    public override void HandleOrder(Order order)
    {
        if (order.Amount > 1000 && order.Amount <= 5000)
        {
            Console.WriteLine($"AdvancedOrderHandler: Обробка замовлення №{order.OrderId} на суму {order.Amount} грн.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleOrder(order);
        }
    }
}

// Конкретний обробник для преміальних замовлень
public class PremiumOrderHandler : OrderHandler
{
    public override void HandleOrder(Order order)
    {
        if (order.Amount > 5000)
        {
            Console.WriteLine($"PremiumOrderHandler: Обробка замовлення №{order.OrderId} на суму {order.Amount} грн.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleOrder(order);
        }
    }
}

// Клас замовлення
public class Order
{
    public int OrderId { get; set; }
    public decimal Amount { get; set; }

    public Order(int orderId, decimal amount)
    {
        OrderId = orderId;
        Amount = amount;
    }
}

public class OrderProcessingClient
{
    private OrderHandler _handlerChain;

    public OrderProcessingClient()
    {
        // Створюємо ланцюг обробників
        _handlerChain = new BasicOrderHandler();
        var advancedHandler = new AdvancedOrderHandler();
        var premiumHandler = new PremiumOrderHandler();

        _handlerChain.SetNext(advancedHandler);
        advancedHandler.SetNext(premiumHandler);
    }

    public void ProcessOrder(Order order)
    {
        _handlerChain.HandleOrder(order);
    }
}

public class Program
{
    public static void Main()
    {
        OrderProcessingClient client = new OrderProcessingClient();

        Order order1 = new Order(1, 500);
        Order order2 = new Order(2, 3000);
        Order order3 = new Order(3, 7000);
        Order order4 = new Order(4, 800);

        client.ProcessOrder(order1);
        client.ProcessOrder(order2);
        client.ProcessOrder(order3);
        client.ProcessOrder(order4);
    }
}

// Output:
// BasicOrderHandler: Обробка замовлення №1 на суму 500 грн.
// AdvancedOrderHandler: Обробка замовлення №2 на суму 3000 грн.
// PremiumOrderHandler: Обробка замовлення №3 на суму 7000 грн.
// BasicOrderHandler: Обробка замовлення №4 на суму 800 грн.