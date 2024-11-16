namespace LeaveApproval;

// Абстрактний клас обробника запитів
public abstract class LeaveRequestHandler
{
    protected LeaveRequestHandler _nextHandler;

    public void SetNext(LeaveRequestHandler nextHandler)
    {
        _nextHandler = nextHandler;
    }

    public abstract void ApproveLeave(LeaveRequest request);
}

// Конкретний обробник для безпосереднього менеджера
public class DirectManagerApproval : LeaveRequestHandler
{
    public override void ApproveLeave(LeaveRequest request)
    {
        if (request.Days <= 5)
        {
            Console.WriteLine(
                $"DirectManagerApproval: Запит на {request.Days} днів затверджено менеджером {request.EmployeeName}.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.ApproveLeave(request);
        }
    }
}

// Конкретний обробник для керівника відділу
public class DepartmentHeadApproval : LeaveRequestHandler
{
    public override void ApproveLeave(LeaveRequest request)
    {
        if (request.Days > 5 && request.Days <= 15)
        {
            Console.WriteLine(
                $"DepartmentHeadApproval: Запит на {request.Days} днів затверджено керівником відділу {request.EmployeeName}.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.ApproveLeave(request);
        }
    }
}

// Конкретний обробник для відділу HR
public class HRApproval : LeaveRequestHandler
{
    public override void ApproveLeave(LeaveRequest request)
    {
        if (request.Days > 15)
        {
            Console.WriteLine(
                $"HRApproval: Запит на {request.Days} днів затверджено відділом HR {request.EmployeeName}.");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.ApproveLeave(request);
        }
    }
}

// Клас запиту на відпустку
public class LeaveRequest
{
    public string EmployeeName { get; set; }
    public int Days { get; set; }

    public LeaveRequest(string employeeName, int days)
    {
        EmployeeName = employeeName;
        Days = days;
    }
}

public class LeaveRequestClient
{
    private LeaveRequestHandler _handlerChain;

    public LeaveRequestClient()
    {
        // Створюємо ланцюг обробників
        _handlerChain = new DirectManagerApproval();
        LeaveRequestHandler deptHead = new DepartmentHeadApproval();
        LeaveRequestHandler hr = new HRApproval();

        _handlerChain.SetNext(deptHead);
        deptHead.SetNext(hr);
    }

    public void SubmitRequest(LeaveRequest request)
    {
        _handlerChain.ApproveLeave(request);
    }
}

public class Program
{
    public static void Main()
    {
        LeaveRequestClient client = new LeaveRequestClient();

        LeaveRequest request1 = new LeaveRequest("Іван Іванов", 3);
        LeaveRequest request2 = new LeaveRequest("Марія Петрівна", 10);
        LeaveRequest request3 = new LeaveRequest("Олексій Сергійович", 20);
        LeaveRequest request4 = new LeaveRequest("Світлана Миколаївна", 15);

        client.SubmitRequest(request1);
        client.SubmitRequest(request2);
        client.SubmitRequest(request3);
        client.SubmitRequest(request4);
    }
}

// Output:
// DirectManagerApproval: Запит на 3 днів затверджено менеджером Іван Іванов.
// DepartmentHeadApproval: Запит на 10 днів затверджено керівником відділу Марія Петрівна.
// HRApproval: Запит на 20 днів затверджено відділом HR Олексій Сергійович.
// DepartmentHeadApproval: Запит на 15 днів затверджено керівником відділу Світлана Миколаївна.