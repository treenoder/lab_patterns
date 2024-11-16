package orders;

// Підсистема 1: Обробка замовлень
class OrderService {
    public void createOrder(String productId, int quantity) {
        // Логіка створення замовлення
        System.out.println("Creating order for Product ID: " + productId + ", Quantity: " + quantity);
    }
}

// Підсистема 2: Управління складськими запасами
class InventoryService {
    public void updateInventory(String productId, int quantity) {
        // Логіка оновлення запасів
        System.out.println("Updating inventory for Product ID: " + productId + ", Quantity: " + quantity);
    }
}

// Підсистема 3: Організація доставки
class ShippingService {
    public void arrangeShipping(String productId, int quantity) {
        // Логіка організації доставки
        System.out.println("Arranging shipping for Product ID: " + productId + ", Quantity: " + quantity);
    }
}

// Фасад
class OrderManagementFacade {
    private OrderService orderService;
    private InventoryService inventoryService;
    private ShippingService shippingService;

    public OrderManagementFacade() {
        this.orderService = new OrderService();
        this.inventoryService = new InventoryService();
        this.shippingService = new ShippingService();
    }

    public void processOrder(String productId, int quantity) {
        orderService.createOrder(productId, quantity);
        inventoryService.updateInventory(productId, quantity);
        shippingService.arrangeShipping(productId, quantity);
        System.out.println("Order processed successfully.");
    }
}

class Main {
    public static void main(String[] args) {
        OrderManagementFacade orderFacade = new OrderManagementFacade();
        orderFacade.processOrder("P12345", 10);
    }
}

// Output:
// Creating order for Product ID: P12345, Quantity: 10
// Updating inventory for Product ID: P12345, Quantity: 10
// Arranging shipping for Product ID: P12345, Quantity: 10
// Order processed successfully.