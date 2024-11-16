from abc import ABC, abstractmethod


# Інтерфейс Команди
class Command(ABC):
    @abstractmethod
    def execute(self):
        pass

    @abstractmethod
    def undo(self):
        pass


# Приймач
class OrderManager:
    def __init__(self):
        self.orders = {}

    def place_order(self, order_id, details):
        self.orders[order_id] = details
        print(f"Order {order_id} placed: {details}")

    def modify_order(self, order_id, new_details):
        if order_id in self.orders:
            old_details = self.orders[order_id]
            self.orders[order_id] = new_details
            print(f"Order {order_id} modified from {old_details} to {new_details}")
            return old_details
        else:
            print(f"Order {order_id} does not exist.")
            return None

    def cancel_order(self, order_id):
        if order_id in self.orders:
            details = self.orders.pop(order_id)
            print(f"Order {order_id} canceled: {details}")
            return details
        else:
            print(f"Order {order_id} does not exist.")
            return None


# Конкретні Команди
class PlaceOrderCommand(Command):
    def __init__(self, order_manager, order_id, details):
        self.order_manager = order_manager
        self.order_id = order_id
        self.details = details

    def execute(self):
        self.order_manager.place_order(self.order_id, self.details)

    def undo(self):
        self.order_manager.cancel_order(self.order_id)


class ModifyOrderCommand(Command):
    def __init__(self, order_manager, order_id, new_details):
        self.order_manager = order_manager
        self.order_id = order_id
        self.new_details = new_details
        self.old_details = None

    def execute(self):
        self.old_details = self.order_manager.modify_order(self.order_id, self.new_details)

    def undo(self):
        if self.old_details:
            self.order_manager.modify_order(self.order_id, self.old_details)


class CancelOrderCommand(Command):
    def __init__(self, order_manager, order_id):
        self.order_manager = order_manager
        self.order_id = order_id
        self.details = None

    def execute(self):
        self.details = self.order_manager.cancel_order(self.order_id)

    def undo(self):
        if self.details:
            self.order_manager.place_order(self.order_id, self.details)


class OrderController:
    def __init__(self):
        self.history = []

    def execute_command(self, command: Command):
        command.execute()
        self.history.append(command)

    def undo_last(self):
        if self.history:
            command = self.history.pop()
            command.undo()
        else:
            print("No commands to undo.")


if __name__ == "__main__":
    order_manager = OrderManager()
    controller = OrderController()

    # Розміщення замовлення
    place_command = PlaceOrderCommand(order_manager, 1, "Pizza Margherita")
    controller.execute_command(place_command)

    # Модифікація замовлення
    modify_command = ModifyOrderCommand(order_manager, 1, "Pizza Pepperoni")
    controller.execute_command(modify_command)

    # Скасування замовлення
    cancel_command = CancelOrderCommand(order_manager, 1)
    controller.execute_command(cancel_command)

    # Відкат останньої команди (скасування замовлення)
    controller.undo_last()

    # Відкат попередньої команди (модифікація замовлення)
    controller.undo_last()

    # Відкат першої команди (розміщення замовлення)
    controller.undo_last()

    # Спроба відкату при відсутності історії
    controller.undo_last()

# Output:
# Order 1 placed: Pizza Margherita
# Order 1 modified from Pizza Margherita to Pizza Pepperoni
# Order 1 canceled: Pizza Pepperoni
# Order 1 placed: Pizza Pepperoni
# Order 1 modified from Pizza Pepperoni to Pizza Margherita
# Order 1 canceled: Pizza Margherita
# No commands to undo.
