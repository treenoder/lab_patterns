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
            Console.WriteLine("*************************************");
            RunReport();
            Console.WriteLine("*************************************");
            RunMonitor();
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