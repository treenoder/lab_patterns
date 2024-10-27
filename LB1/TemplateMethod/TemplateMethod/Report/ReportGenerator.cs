using System;

namespace TemplateMethod.Report
{
    public abstract class ReportGenerator
    {
        public void GenerateReport()
        {
            object data = AggregateData();
            Console.WriteLine("Data aggregated");
            object formattedData = FormatData(data);
            Console.WriteLine("Data formatted");
            ExportData(formattedData);
        }
        
        private object AggregateData()
        {
            return new object();
        }
        
        private object FormatData(object data)
        {
            return new object();
        }

        protected abstract void ExportData(object data);
    }
}