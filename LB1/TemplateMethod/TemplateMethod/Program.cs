using System;
using TemplateMethod.Company;
using TemplateMethod.Monitor;
using TemplateMethod.Report;

namespace TemplateMethod
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            RunCompany();
            // Order received: Individual Order
            // Validated individual order
            // Payment was processed
            // Shipped individual order
            // =====================================
            // Order received: Corporate Order
            // Validated corporate order
            // Payment was processed
            // Shipped corporate order
            Console.WriteLine("*************************************");
            RunReport();
            // Data aggregated
            // Data formatted
            // Exported HTML report
            // =====================================
            // Data aggregated
            // Data formatted
            // Exported PDF report
            // =====================================
            // Data aggregated
            // Data formatted
            // Exported Excel report
            Console.WriteLine("*************************************");
            RunMonitor();
            // Collected web server data
            // RPS: 1000
            // CPU: 20%
            // Memory: 50%
            // Response time: 100ms
            // Analyzed web server data
            // Stored monitor report
            // =====================================
            // Collected database server data
            // Queries per second: 100
            // CPU: 50%
            // Memory: 70%
            // Disk usage: 80%
            // Analyzed database server data
            // Stored monitor report
            // =====================================
            // Collected file server data
            // Files: 1000
            // CPU: 10%
            // Memory: 30%
            // Disk usage: 90%
            // Analyzed file server data
            // Stored monitor report
        }

        private static void RunCompany()
        {
            var individualOrder = new Order(OrderType.Individual);
            OrderProcessor individualOrderProcessor = new IndividualOrderProcessor();
            individualOrderProcessor.ProcessOrder(individualOrder);
            
            Console.WriteLine("=====================================");
            
            var corporateOrder = new Order(OrderType.Corporate);
            OrderProcessor corporateOrderProcessor = new CorporateOrderProcessor();
            corporateOrderProcessor.ProcessOrder(corporateOrder);
        }
        
        private static void RunReport()
        {
            ReportGenerator html = new HTMLReportGenerator();
            html.GenerateReport();
            
            Console.WriteLine("=====================================");
            
            ReportGenerator pdf = new PDFReportGenerator();
            pdf.GenerateReport();
            
            Console.WriteLine("=====================================");
            
            ReportGenerator excel = new ExcelReportGenerator();
            excel.GenerateReport();
        }

        private static void RunMonitor()
        {
            ServerMonitor web = new WebServerMonitor();
            web.Monitor();
            
            Console.WriteLine("=====================================");
            
            ServerMonitor db = new DatabaseServerMonitor();
            db.Monitor();
            
            Console.WriteLine("=====================================");
            
            ServerMonitor app = new FileServerMonitor();
            app.Monitor();
        }
    }
}