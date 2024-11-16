namespace Reports;

// Елемент, який буде відвідуватись
public interface IFinancialReport
{
    void Accept(IFinancialReportVisitor visitor);
}

// Конкретні елементи
public class IncomeStatement : IFinancialReport
{
    public double Revenue { get; set; }
    public double Expenses { get; set; }

    public void Accept(IFinancialReportVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class BalanceSheet : IFinancialReport
{
    public double Assets { get; set; }
    public double Liabilities { get; set; }

    public void Accept(IFinancialReportVisitor visitor)
    {
        visitor.Visit(this);
    }
}

// Відвідувачі
public interface IFinancialReportVisitor
{
    void Visit(IncomeStatement incomeStatement);
    void Visit(BalanceSheet balanceSheet);
}

public class TaxAuditVisitor : IFinancialReportVisitor
{
    public void Visit(IncomeStatement incomeStatement)
    {
        double taxableIncome = incomeStatement.Revenue - incomeStatement.Expenses;
        Console.WriteLine($"Taxable Income: {taxableIncome}");
    }

    public void Visit(BalanceSheet balanceSheet)
    {
        // Можлива додаткова логіка
        Console.WriteLine($"Assets: {balanceSheet.Assets}, Liabilities: {balanceSheet.Liabilities}");
    }
}

public class InvestmentAnalysisVisitor : IFinancialReportVisitor
{
    public void Visit(IncomeStatement incomeStatement)
    {
        double profitMargin = (incomeStatement.Revenue - incomeStatement.Expenses) / incomeStatement.Revenue;
        Console.WriteLine($"Profit Margin: {profitMargin:P}");
    }

    public void Visit(BalanceSheet balanceSheet)
    {
        double debtRatio = balanceSheet.Liabilities / balanceSheet.Assets;
        Console.WriteLine($"Debt Ratio: {debtRatio:P}");
    }
}

public class Program
{
    public static void Main()
    {
        List<IFinancialReport> reports = new List<IFinancialReport>
        {
            new IncomeStatement { Revenue = 100000, Expenses = 70000 },
            new BalanceSheet { Assets = 150000, Liabilities = 50000 }
        };

        IFinancialReportVisitor taxVisitor = new TaxAuditVisitor();
        IFinancialReportVisitor investmentVisitor = new InvestmentAnalysisVisitor();

        Console.WriteLine("Tax Audit:");
        foreach (var report in reports)
        {
            report.Accept(taxVisitor);
        }

        Console.WriteLine("\nInvestment Analysis:");
        foreach (var report in reports)
        {
            report.Accept(investmentVisitor);
        }
    }
}

// Output:
// Tax Audit:
// Taxable Income: 30000
// Assets: 150000, Liabilities: 50000
// 
// Investment Analysis:
// Profit Margin: 30,000 %
// Debt Ratio: 33,333 %