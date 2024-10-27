package projects;

public abstract class Composite implements IComponent {
    public abstract void add(IComponent task);

    public abstract void remove(IComponent task);
}
