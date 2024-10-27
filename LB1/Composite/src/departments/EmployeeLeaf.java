package departments;

public class EmployeeLeaf implements IComponent {
    private final int salary;

    public EmployeeLeaf(int salary) {
        this.salary = salary;
    }

    @Override
    public int getBudget() {
        return salary;
    }

    @Override
    public int countOfWorkers() {
        return 1;
    }
}
