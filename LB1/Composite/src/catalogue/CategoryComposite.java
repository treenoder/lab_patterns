package catalogue;

import java.util.ArrayList;
import java.util.List;

public class CategoryComposite extends Composite {
    private final List<IComponent> items;
    private final String name;

    public CategoryComposite(String name) {
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
    public int countOfItems() {
        return this.items.stream().mapToInt(IComponent::countOfItems).sum();
    }

    @Override
    public void listItems() {
        System.out.print("-->");
        System.out.println(this.getName());
        this.items.forEach(IComponent::listItems);
    }
}
