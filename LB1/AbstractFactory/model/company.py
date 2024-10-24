from LB1.AbstractFactory.model.furniture import FurnitureFactory


class FurnitureCompany:
    def __init__(self, name, ):
        self.name = name

    def __str__(self):
        return f'{self.name} furniture company'

    def present_furniture(self, factory: FurnitureFactory):
        chair = factory.create_chair()
        sofa = factory.create_sofa()
        coffee_table = factory.create_coffee_table()
        print(f'{self.name} presents:')
        print(f'Chair: {chair.sit_on()}')
        print(f'Sofa: {sofa.lie_on()}')
        print(f'Coffee table: {coffee_table.look_at()}')
