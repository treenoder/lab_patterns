package departments;

public abstract class Composite implements IComponent {
    private final String name;

    public Composite(String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public abstract void add(IComponent worker);

    public abstract void remove(IComponent worker);
}
