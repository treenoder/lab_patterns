using System;
using System.Collections.Generic;
using System.Linq;

// Інтерфейс для транзакцій
public interface ITransaction
{
    Guid Id { get; }
    DateTime Date { get; }
    decimal Amount { get; }
    string Type { get; }
}

// Клас для депозитних транзакцій
public class DepositTransaction : ITransaction
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public decimal Amount { get; private set; }
    public string Type => "Deposit";

    public DepositTransaction(decimal amount)
    {
        Id = Guid.NewGuid();
        Date = DateTime.Now;
        Amount = amount;
    }
}

// Клас для зняття коштів
public class WithdrawalTransaction : ITransaction
{
    public Guid Id { get; private set; }
    public DateTime Date { get; private set; }
    public decimal Amount { get; private set; }
    public string Type => "Withdrawal";

    public WithdrawalTransaction(decimal amount)
    {
        Id = Guid.NewGuid();
        Date = DateTime.Now;
        Amount = amount;
    }
}

// Інтерфейс для збереження транзакцій
public interface ITransactionRepository
{
    void AddTransaction(ITransaction transaction);
    IEnumerable<ITransaction> GetAllTransactions();
}

// Реалізація репозиторію транзакцій
public class TransactionRepository : ITransactionRepository
{
    private readonly List<ITransaction> _transactions = new List<ITransaction>();

    public void AddTransaction(ITransaction transaction)
    {
        _transactions.Add(transaction);
    }

    public IEnumerable<ITransaction> GetAllTransactions()
    {
        return _transactions;
    }
}

// Інтерфейс для сервісу балансу
public interface IBalanceService
{
    decimal GetBalance();
    void Deposit(decimal amount);
    void Withdraw(decimal amount);
}

// Реалізація сервісу балансу
public class BalanceService : IBalanceService
{
    private decimal _balance;
    private readonly ITransactionRepository _transactionRepository;

    public BalanceService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
        _balance = 0m;
    }

    public decimal GetBalance()
    {
        return _balance;
    }

    public void Deposit(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума поповнення повинна бути позитивною.");

        var deposit = new DepositTransaction(amount);
        _balance += amount;
        _transactionRepository.AddTransaction(deposit);
    }

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Сума зняття повинна бути позитивною.");

        if (_balance - amount < 0)
            throw new InvalidOperationException("Недостатньо коштів на рахунку.");

        var withdrawal = new WithdrawalTransaction(amount);
        _balance -= amount;
        _transactionRepository.AddTransaction(withdrawal);
    }
}

// Інтерфейс для сервісу звітів
public interface IReportService
{
    void GenerateReport();
}

// Реалізація сервісу звітів
public class ReportService : IReportService
{
    private readonly ITransactionRepository _transactionRepository;

    public ReportService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }

    public void GenerateReport()
    {
        var transactions = _transactionRepository.GetAllTransactions()
            .OrderBy(t => t.Date);

        Console.WriteLine("Звіт транзакцій:");
        Console.WriteLine("-------------------------------");
        foreach (var transaction in transactions)
        {
            Console.WriteLine($"{transaction.Date}: {transaction.Type} - {transaction.Amount:C}");
        }
        Console.WriteLine("-------------------------------");
    }
}

// Клас користувача
public class User
{
    public string Name { get; private set; }
    public IBalanceService BalanceService { get; private set; }
    public IReportService ReportService { get; private set; }

    public User(string name, IBalanceService balanceService, IReportService reportService)
    {
        Name = name;
        BalanceService = balanceService;
        ReportService = reportService;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ITransactionRepository transactionRepository = new TransactionRepository();
        IBalanceService balanceService = new BalanceService(transactionRepository);
        IReportService reportService = new ReportService(transactionRepository);

        User user = new User("Іван", balanceService, reportService);

        try
        {
            user.BalanceService.Deposit(1000m);
            user.BalanceService.Withdraw(250m);
            user.BalanceService.Deposit(500m);
            user.BalanceService.Withdraw(1500m); // Це викличе виключення
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }

        Console.WriteLine($"Поточний баланс користувача {user.Name}: {user.BalanceService.GetBalance():C}");
        user.ReportService.GenerateReport();
    }
}

// Output:
// Помилка: Недостатньо коштів на рахунку.
// Поточний баланс користувача Іван: 1250,00 ₴
// Звіт транзакцій:
// -------------------------------
// 15.12.2024 22:16:15: Deposit - 1000,00 ₴
// 15.12.2024 22:16:15: Withdrawal - 250,00 ₴
// 15.12.2024 22:16:15: Deposit - 500,00 ₴
// -------------------------------

