package projects;

import java.util.ArrayList;
import java.util.List;

public class ProjectComposite extends Composite {
    private final List<IComponent> items;
    private final String name;

    public ProjectComposite(String name) {
        this.items = new ArrayList<>();
        this.name = name;
    }

    @Override
    public void add(IComponent item) {
        this.items.add(item);
    }

    @Override
    public void remove(IComponent item) {
        this.items.remove(item);
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public int countOfTasks() {
        return this.items.stream().mapToInt(IComponent::countOfTasks).sum();
    }

    @Override
    public int getEstimate() {
        return this.items.stream().mapToInt(IComponent::getEstimate).sum();
    }
}
