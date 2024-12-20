### Завдання для лабораторної роботи: Шаблон проєктування Abstract Factory у вирішенні бізнес-завдання

#### Огляд завдання:

Шаблон проєктування Abstract Factory забезпечує спосіб створення серій сумісних об'єктів без прив'язки до конкретних
класів їх реалізації. Цей патерн є ключовим у ситуаціях, коли система повинна бути незалежною від того, як її компоненти
створюються, скомпоновані та представлені.

#### Завдання:

1. **Визначення проблеми**:
    - Розгляньте ситуацію, де велика меблева компанія потребує систему для створення різних типів меблів (Класичних,
      Модерн, Вікторіанських), причому кожен стиль повинен включати різні типи елементів (крісла, дивани, столики).

2. **Завдання проєктування**:
    - Розробіть концепцію системи, використовуючи шаблон Abstract Factory, де базовий інтерфейс 'FurnitureFactory'
      позволяє створювати продукти різних видів. Потім реалізуйте декілька фабрик: 'ClassicFurnitureFactory', '
      ModernFurnitureFactory', 'VictorianFurnitureFactory', кожна з яких виробляє відповідний стиль меблів.
    - Опишіть, як ці фабрики взаємодіють з абстракціями продуктів ('Chair', 'Sofa', 'CoffeeTable').
