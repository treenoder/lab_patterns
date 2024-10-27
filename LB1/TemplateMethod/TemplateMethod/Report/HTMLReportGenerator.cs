namespace TemplateMethod.Report
{
    public class HTMLReportGenerator: ReportGenerator
    {
        protected override void ExportData(object data)
        {
            System.Console.WriteLine("Exported HTML report");
        }
    }
}