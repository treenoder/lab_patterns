namespace TemplateMethod.Monitor
{
    public class FileServerMonitor: ServerMonitor
    {
        protected override object CollectData()
        {
            System.Console.WriteLine("Collected file server data");
            System.Console.WriteLine("Files: 1000");
            System.Console.WriteLine("CPU: 10%");
            System.Console.WriteLine("Memory: 30%");
            System.Console.WriteLine("Disk usage: 90%");
            return new object();
        }

        protected override object AnalyzeData(object data)
        {
            System.Console.WriteLine("Analyzed file server data");
            return new object();
        }
    }
}