using MagMediaReportGenerator.Business.MagMediaReports.Interfaces;
using MagMediaReportGenerator.Business.MagMediaReports.Models;

namespace MagMediaReportGenerator.Business.MagMediaReports.Classes
{
    public class W2ReportName : IMagMediaReportName
    {
        public string GetFileName(string name, string format, string tpeName)
        {
            return $"{name}{format}";
        }

        public string GetArchiveName(MagMediaReportPeriodModel period)
        {
            string formattedDate = $"{period.CurrentDate.ToString("MM-dd-yyyy")}_{period.CurrentDate.ToString("HH-mm")}";
            return $"W2_{period.Year}_{formattedDate}.zip";
        }
    }
}
