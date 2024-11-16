from abc import ABC, abstractmethod


class PaymentProcessor(ABC):
    @abstractmethod
    def process_payment(self, amount: float):
        pass


class CreditCardProcessor(PaymentProcessor):
    def process_payment(self, amount: float):
        print(f"Processing credit card payment of ${amount:.2f}")


class PaypalProcessor(PaymentProcessor):
    def process_payment(self, amount: float):
        print(f"Processing PayPal payment of ${amount:.2f}")


class CryptoProcessor(PaymentProcessor):
    def process_payment(self, amount: float):
        print(f"Processing cryptocurrency payment of ${amount:.2f}")


class PaymentSystem(ABC):
    def __init__(self, processor: PaymentProcessor):
        self.processor = processor

    @abstractmethod
    def make_payment(self, amount: float):
        pass


class OnlinePaymentSystem(PaymentSystem):
    def make_payment(self, amount: float):
        print("Initiating online payment...")
        self.processor.process_payment(amount)
        print("Payment completed successfully.")


if __name__ == "__main__":
    credit_card = CreditCardProcessor()
    paypal = PaypalProcessor()
    crypto = CryptoProcessor()

    online_payment = OnlinePaymentSystem(credit_card)
    online_payment.make_payment(150.00)

    online_payment = OnlinePaymentSystem(paypal)
    online_payment.make_payment(200.00)

    online_payment = OnlinePaymentSystem(crypto)
    online_payment.make_payment(300.00)

# Output:
# Initiating online payment...
# Processing credit card payment of $150.00
# Payment completed successfully.
# Initiating online payment...
# Processing PayPal payment of $200.00
# Payment completed successfully.
# Initiating online payment...
# Processing cryptocurrency payment of $300.00
# Payment completed successfully.
