from LB1.AbstractFactory.model.furniture import Chair, Sofa, CoffeeTable, FurnitureFactory


class ModernChair(Chair):
    def sit_on(self) -> str:
        return "Sitting on a modern chair"


class ModernSofa(Sofa):
    def lie_on(self) -> str:
        return "Lying on a modern sofa"


class ModernCoffeeTable(CoffeeTable):
    def look_at(self) -> str:
        return "Looking at a modern coffee table"


class ModernFurnitureFactory(FurnitureFactory):
    def create_chair(self) -> Chair:
        return ModernChair()

    def create_sofa(self) -> Sofa:
        return ModernSofa()

    def create_coffee_table(self) -> CoffeeTable:
        return ModernCoffeeTable()
