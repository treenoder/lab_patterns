package departments;

import java.util.ArrayList;
import java.util.List;

public class DepartmentComposite extends Composite {
    private final List<IComponent> workers = new ArrayList<>();

    public DepartmentComposite(String name) {
        super(name);
    }

    @Override
    public void add(IComponent worker) {
        workers.add(worker);
    }

    @Override
    public void remove(IComponent worker) {
        workers.remove(worker);
    }

    @Override
    public int getBudget() {
        return workers.stream().mapToInt(IComponent::getBudget).sum();
    }

    @Override
    public int countOfWorkers() {
        return workers.stream().mapToInt(IComponent::countOfWorkers).sum();
    }
}
