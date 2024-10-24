from LB1.AbstractFactory.model.classic import ClassicFurnitureFactory
from LB1.AbstractFactory.model.company import FurnitureCompany
from LB1.AbstractFactory.model.modern import ModernFurnitureFactory
from LB1.AbstractFactory.model.victorian import VictorianFurnitureFactory


def main():
    ikea = FurnitureCompany('IKEA')
    ikea.present_furniture(ClassicFurnitureFactory())
    print('-' * 50)
    ikea.present_furniture(ModernFurnitureFactory())
    print('-' * 50)
    ikea.present_furniture(VictorianFurnitureFactory())


if __name__ == '__main__':
    main()

# Output:
# IKEA presents:
# Chair: Sitting on a Classic Chair
# Sofa: Lying on a Classic Sofa
# Coffee table: Looking at a Classic Coffee Table
# --------------------------------------------------
# IKEA presents:
# Chair: Sitting on a modern chair
# Sofa: Lying on a modern sofa
# Coffee table: Looking at a modern coffee table
# --------------------------------------------------
# IKEA presents:
# Chair: Sitting on a Victorian chair
# Sofa: Lying on a Victorian sofa
# Coffee table: Looking at a Victorian coffee table
