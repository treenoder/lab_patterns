using System;

namespace TemplateMethod.Monitor
{
    public class WebServerMonitor: ServerMonitor
    {
        protected override object CollectData()
        {
            Console.WriteLine("Collected web server data");
            Console.WriteLine("RPS: 1000");
            Console.WriteLine("CPU: 20%");
            Console.WriteLine("Memory: 50%");
            Console.WriteLine("Response time: 100ms");
            return new object();
        }
        
        protected override object AnalyzeData(object data)
        {
            Console.WriteLine("Analyzed web server data");
            return new object();
        }
    }
}