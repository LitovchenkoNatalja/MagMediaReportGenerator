using MagMediaReportGenerator.Business.MagMediaReports.Interfaces;
using MagMediaReportGenerator.Business.MagMediaReports.Models;

namespace MagMediaReportGenerator.Business.MagMediaReports.Classes
{
    public class MagMediaReportName: IMagMediaReportName
    {
        private const int TPE_NAME_LENGTH = 4;

        public string GetFileName(string name, string format, string tpeName)
        {
            string tpeNameCut = TPE_NAME_LENGTH < tpeName.Length
                ? tpeName.Substring(0, TPE_NAME_LENGTH)
                : tpeName.Substring(0, tpeName.Length);
            return $"{name}{tpeNameCut}{format}";
        }

        public string GetArchiveName(MagMediaReportPeriodModel period)
        {
            string formattedDate = $"{period.CurrentDate.ToString("MM-dd-yyyy")}_{period.CurrentDate.ToString("HH-mm")}";
            return $"MagMedia_{period.Year}_{period.Quarter.ToString()}_{formattedDate}.zip";
        }
    }
}
