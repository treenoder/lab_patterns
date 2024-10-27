using System;

namespace TemplateMethod.Monitor
{
    public class DatabaseServerMonitor: ServerMonitor
    {
        protected override object CollectData()
        {
            Console.WriteLine("Collected database server data");
            Console.WriteLine("Queries per second: 100");
            Console.WriteLine("CPU: 50%");
            Console.WriteLine("Memory: 70%");
            Console.WriteLine("Disk usage: 80%");
            return new object();
        }
        
        protected override object AnalyzeData(object data)
        {
            Console.WriteLine("Analyzed database server data");
            return new object();
        }
    }
}