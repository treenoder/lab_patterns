### Завдання для лабораторної роботи: Шаблон проєктування Composite у вирішенні бізнес-завдань

#### Завдання 1: Система управління корпоративними відділами

**Огляд завдання**:
Компанія потребує систему для управління відділами, підрозділами та їхніми співробітниками.

**Визначення проблеми**:

- Комплексне управління ієрархічною структурою організації з різними рівнями підрозділів.

**Завдання проєктування**:

- Розробіть систему, в якій композитний клас `DepartmentComposite` представляє кожен відділ, що може містити підрозділи
  або співробітників. Клас `EmployeeLeaf` представляє окремих співробітників.

#### Завдання 2: Менеджмент продуктового каталогу

**Огляд завдання**:
Інтернет-магазин потребує ефективно управляти своїм асортиментом товарів, які класифіковані за категоріями і
підкатегоріями.

**Визначення проблеми**:

- Необхідність представлення і управління великою кількістю товарів, розподілених за багатьма категоріями.

**Завдання проєктування**:

- Створіть композитну структуру за допомогою класу `CategoryComposite`, який може включати інші категорії або конкретні
  товари (`ProductLeaf`).

#### Завдання 3: Управління проектами

**Огляд завдання**:
Компанія управляє численними проектами, які містять різні завдання та підзавдання.

**Визначення проблеми**:

- Організація та виконання складних проектних структур з множинними залежностями між завданнями.

**Завдання проєктування**:

- Впровадження класу `ProjectComposite`, який агрегує підпроекти або окремі завдання (`TaskLeaf`).