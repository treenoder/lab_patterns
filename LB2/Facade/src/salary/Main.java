package salary;

// Підсистема 1: Розрахунок базової зарплати
class SalaryCalculator {
    public double calculateBaseSalary(String employeeId) {
        // Логіка розрахунку базової зарплати
        System.out.println("Calculating base salary for employee: " + employeeId);
        return 5000.0;
    }
}

// Підсистема 2: Розрахунок податків
class TaxCalculator {
    public double calculateTaxes(double baseSalary) {
        // Логіка розрахунку податків
        System.out.println("Calculating taxes on base salary: " + baseSalary);
        return baseSalary * 0.2;
    }
}

// Підсистема 3: Розрахунок відрахувань до фондів
class DeductionCalculator {
    public double calculateDeductions(double baseSalary) {
        // Логіка розрахунку відрахувань
        System.out.println("Calculating deductions on base salary: " + baseSalary);
        return baseSalary * 0.1;
    }
}

// Фасад
class PayrollFacade {
    private SalaryCalculator salaryCalculator;
    private TaxCalculator taxCalculator;
    private DeductionCalculator deductionCalculator;

    public PayrollFacade() {
        this.salaryCalculator = new SalaryCalculator();
        this.taxCalculator = new TaxCalculator();
        this.deductionCalculator = new DeductionCalculator();
    }

    public void processPayroll(String employeeId) {
        double baseSalary = salaryCalculator.calculateBaseSalary(employeeId);
        double taxes = taxCalculator.calculateTaxes(baseSalary);
        double deductions = deductionCalculator.calculateDeductions(baseSalary);
        double netSalary = baseSalary - taxes - deductions;
        System.out.println("Net Salary for " + employeeId + ": " + netSalary);
    }
}

class Main {
    public static void main(String[] args) {
        PayrollFacade payrollFacade = new PayrollFacade();
        payrollFacade.processPayroll("E12345");
    }
}

// Output:
// Calculating base salary for employee: E12345
// Calculating taxes on base salary: 5000.0
// Calculating deductions on base salary: 5000.0
// Net Salary for E12345: 3500.0