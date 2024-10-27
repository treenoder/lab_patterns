import catalogue.CategoryComposite;
import catalogue.ProductLeaf;
import departments.DepartmentComposite;
import departments.EmployeeLeaf;
import projects.ProjectComposite;
import projects.TaskLeaf;

public class Main {
    public static void main(String[] args) {
        runDepartments();
        //Company: Company
        //Company budget: 9000
        //Company workers: 6
        System.out.println("********************");
        runCatalogue();
        //Catalogue: Catalogue
        //Catalogue items: 6
        //-->Catalogue
        //-->Online Shop
        //T-shirt
        //Jeans
        //-->Electronics
        //-->Phone
        //Samsung
        //iPhone
        //-->Laptop
        //Dell
        //HP
        System.out.println("********************");
        runProjects();
        //Project: Main Project
        //Project tasks: 4
        //Project estimate: 100
    }

    private static void runDepartments() {
        var company = new DepartmentComposite("Company");
        var hr = new DepartmentComposite("HR");
        hr.add(new EmployeeLeaf(1000));
        hr.add(new EmployeeLeaf(1000));
        company.add(hr);

        var it = new DepartmentComposite("IT");

        var dev = new DepartmentComposite("Development");
        dev.add(new EmployeeLeaf(2000));
        dev.add(new EmployeeLeaf(2000));
        it.add(dev);

        var qa = new DepartmentComposite("Quality Assurance");
        qa.add(new EmployeeLeaf(1500));
        qa.add(new EmployeeLeaf(1500));
        it.add(qa);

        company.add(it);

        System.out.println("Company: " + company.getName());
        System.out.println("Company budget: " + company.getBudget());
        System.out.println("Company workers: " + company.countOfWorkers());
    }

    private static void runCatalogue() {
        var catalogue = new CategoryComposite("Catalogue");

        var clothes = new CategoryComposite("Online Shop");
        clothes.add(new ProductLeaf("T-shirt"));
        clothes.add(new ProductLeaf("Jeans"));
        catalogue.add(clothes);

        var electronics = new CategoryComposite("Electronics");

        var phone = new CategoryComposite("Phone");
        phone.add(new ProductLeaf("Samsung"));
        phone.add(new ProductLeaf("iPhone"));
        electronics.add(phone);

        var laptop = new CategoryComposite("Laptop");
        laptop.add(new ProductLeaf("Dell"));
        laptop.add(new ProductLeaf("HP"));
        electronics.add(laptop);

        catalogue.add(electronics);

        System.out.println("Catalogue: " + catalogue.getName());
        System.out.println("Catalogue items: " + catalogue.countOfItems());
        catalogue.listItems();
    }

    private static void runProjects() {
        var project = new ProjectComposite("Main Project");

        var task1 = new TaskLeaf("Task 1", 10);
        var task2 = new TaskLeaf("Task 2", 20);
        project.add(task1);
        project.add(task2);

        var subProject = new ProjectComposite("Sub Project");

        var task3 = new TaskLeaf("Task 3", 30);
        var task4 = new TaskLeaf("Task 4", 40);
        subProject.add(task3);
        subProject.add(task4);

        project.add(subProject);

        System.out.println("Project: " + project.getName());
        System.out.println("Project tasks: " + project.countOfTasks());
        System.out.println("Project estimate: " + project.getEstimate());
    }
}