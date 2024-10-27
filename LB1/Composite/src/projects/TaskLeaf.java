package projects;

public class TaskLeaf implements IComponent {
    public final int estimate;
    private final String name;

    public TaskLeaf(String name, int estimate) {
        this.name = name;
        this.estimate = estimate;
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public int countOfTasks() {
        return 1;
    }

    @Override
    public int getEstimate() {
        return this.estimate;
    }
}
