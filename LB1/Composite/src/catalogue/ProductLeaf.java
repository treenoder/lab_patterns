package catalogue;

public class ProductLeaf implements IComponent {
    private final String name;

    public ProductLeaf(String name) {
        this.name = name;
    }

    @Override
    public String getName() {
        return this.name;
    }

    @Override
    public int countOfItems() {
        return 1;
    }

    @Override
    public void listItems() {
        System.out.println(this.getName());
    }
}
