namespace TemplateMethod.Monitor
{
    public abstract class ServerMonitor
    {
        public void Monitor()
        {
            object data = CollectData();
            object report = AnalyzeData(data);
            Strore(report);
        }
        
        private void Strore(object report)
        {
            System.Console.WriteLine("Stored monitor report");
        }
        
        protected abstract object CollectData();
        
        protected abstract object AnalyzeData(object data);
    }
}