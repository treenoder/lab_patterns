namespace Accounting;

// Цільовий інтерфейс, який очікує компанія
public interface IAccountingReport
{
    List<ReportData> GetReportData();
}

// Клас для зберігання даних звіту
public class ReportData
{
    public string AccountName { get; set; }
    public decimal Amount { get; set; }
}

// Система обліку A з власним інтерфейсом
public class SystemA
{
    public List<AData> FetchDataA()
    {
        return new List<AData>
        {
            new() { Account = "Revenue", Value = 10000 },
            new() { Account = "Expenses", Value = 5000 }
        };
    }
}

public class AData
{
    public string Account { get; set; }
    public decimal Value { get; set; }
}

// Система обліку B з власним інтерфейсом
public class SystemB
{
    public Dictionary<string, double> GetDataB()
    {
        return new Dictionary<string, double>
        {
            { "Assets", 20000.50 },
            { "Liabilities", 15000.75 }
        };
    }
}

// Адаптер, який реалізує цільовий інтерфейс
public class AccountingAdapter : IAccountingReport
{
    private readonly SystemA _systemA;
    private readonly SystemB _systemB;

    public AccountingAdapter(SystemA systemA, SystemB systemB)
    {
        _systemA = systemA;
        _systemB = systemB;
    }

    public List<ReportData> GetReportData()
    {
        var report = new List<ReportData>();

        // Адаптуємо дані з SystemA
        foreach (var data in _systemA.FetchDataA())
            report.Add(new ReportData
            {
                AccountName = data.Account,
                Amount = data.Value
            });

        // Адаптуємо дані з SystemB
        foreach (var kvp in _systemB.GetDataB())
            report.Add(new ReportData
            {
                AccountName = kvp.Key,
                Amount = (decimal)kvp.Value
            });

        return report;
    }
}

// Клієнтський код
public class AccountingClient
{
    private readonly IAccountingReport _report;

    public AccountingClient(IAccountingReport report)
    {
        _report = report;
    }

    public void ShowReport()
    {
        var data = _report.GetReportData();
        Console.WriteLine("Accounting Report:");
        foreach (var item in data) Console.WriteLine($"Account: {item.AccountName}, Amount: {item.Amount}");
    }
}

public class Program
{
    public static void Main()
    {
        var systemA = new SystemA();
        var systemB = new SystemB();
        IAccountingReport adapter = new AccountingAdapter(systemA, systemB);
        var client = new AccountingClient(adapter);
        client.ShowReport();
    }
}

// Output
// Accounting Report:
// Account: Revenue, Amount: 10000
// Account: Expenses, Amount: 5000
// Account: Assets, Amount: 20000,5
// Account: Liabilities, Amount: 15000,75 