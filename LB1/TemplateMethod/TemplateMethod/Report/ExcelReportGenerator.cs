namespace TemplateMethod.Report
{
    public class ExcelReportGenerator: ReportGenerator
    {
        protected override void ExportData(object data)
        {
            System.Console.WriteLine("Exported Excel report");
        }
    }
}