package credit;

// Підсистема 1: Перевірка кредитоспроможності
class CreditScoreService {
    public int getCreditScore(String customerId) {
        // Логіка отримання кредитного рейтингу
        System.out.println("Fetching credit score for customer: " + customerId);
        return 750;
    }
}

// Підсистема 2: Перевірка історії кредитів
class CreditHistoryService {
    public String getCreditHistory(String customerId) {
        // Логіка отримання історії кредитів
        System.out.println("Fetching credit history for customer: " + customerId);
        return "Good";
    }
}

// Підсистема 3: Оформлення заявки на кредит
class LoanApplicationService {
    public void applyForLoan(String customerId, double amount) {
        // Логіка оформлення заявки
        System.out.println("Processing loan application for customer: " + customerId + ", Amount: " + amount);
    }
}

// Фасад
class CreditServiceFacade {
    private CreditScoreService creditScoreService;
    private CreditHistoryService creditHistoryService;
    private LoanApplicationService loanApplicationService;

    public CreditServiceFacade() {
        this.creditScoreService = new CreditScoreService();
        this.creditHistoryService = new CreditHistoryService();
        this.loanApplicationService = new LoanApplicationService();
    }

    public void processLoanApplication(String customerId, double amount) {
        int score = creditScoreService.getCreditScore(customerId);
        String history = creditHistoryService.getCreditHistory(customerId);
        if (score > 700 && "Good".equals(history)) {
            loanApplicationService.applyForLoan(customerId, amount);
            System.out.println("Loan application approved.");
        } else {
            System.out.println("Loan application denied.");
        }
    }
}

class Main {
    public static void main(String[] args) {
        CreditServiceFacade creditFacade = new CreditServiceFacade();
        creditFacade.processLoanApplication("C67890", 10000.0);
    }
}

// Output:
// Fetching credit score for customer: C67890
// Fetching credit history for customer: C67890
// Processing loan application for customer: C67890, Amount: 10000.0
// Loan application approved.
