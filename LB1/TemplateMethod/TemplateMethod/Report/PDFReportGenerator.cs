namespace TemplateMethod.Report
{
    public class PDFReportGenerator: ReportGenerator
    {
        protected override void ExportData(object data)
        {
            System.Console.WriteLine("Exported PDF report");
        }
    }
}