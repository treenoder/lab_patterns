from LB1.AbstractFactory.model.furniture import Chair, Sofa, CoffeeTable, FurnitureFactory


class ClassicChair(Chair):
    def sit_on(self) -> str:
        return 'Sitting on a Classic Chair'


class ClassicSofa(Sofa):
    def lie_on(self) -> str:
        return 'Lying on a Classic Sofa'


class ClassicCoffeeTable(CoffeeTable):
    def look_at(self) -> str:
        return 'Looking at a Classic Coffee Table'


class ClassicFurnitureFactory(FurnitureFactory):
    def create_chair(self) -> Chair:
        return ClassicChair()

    def create_sofa(self) -> Sofa:
        return ClassicSofa()

    def create_coffee_table(self) -> CoffeeTable:
        return ClassicCoffeeTable()
