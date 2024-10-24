from abc import ABC, abstractmethod


class Chair(ABC):
    @abstractmethod
    def sit_on(self) -> str:
        pass


class Sofa(ABC):
    @abstractmethod
    def lie_on(self) -> str:
        pass


class CoffeeTable(ABC):
    @abstractmethod
    def look_at(self) -> str:
        pass


class FurnitureFactory(ABC):
    @abstractmethod
    def create_chair(self) -> Chair:
        pass

    @abstractmethod
    def create_sofa(self) -> Sofa:
        pass

    @abstractmethod
    def create_coffee_table(self) -> CoffeeTable:
        pass
