package catalogue;

public abstract class Composite implements IComponent {
    public abstract void add(IComponent item);

    public abstract void remove(IComponent item);
}
