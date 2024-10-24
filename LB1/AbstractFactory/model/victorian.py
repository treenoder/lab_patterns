from LB1.AbstractFactory.model.furniture import Chair, Sofa, CoffeeTable, FurnitureFactory


class VictorianChair(Chair):
    def sit_on(self) -> str:
        return "Sitting on a Victorian chair"


class VictorianSofa(Sofa):
    def lie_on(self) -> str:
        return "Lying on a Victorian sofa"


class VictorianCoffeeTable(CoffeeTable):
    def look_at(self) -> str:
        return "Looking at a Victorian coffee table"


class VictorianFurnitureFactory(FurnitureFactory):
    def create_chair(self) -> Chair:
        return VictorianChair()

    def create_sofa(self) -> Sofa:
        return VictorianSofa()

    def create_coffee_table(self) -> CoffeeTable:
        return VictorianCoffeeTable()
