using MagMediaReportGenerator.Business.MagMediaReports.Models;

namespace MagMediaReportGenerator.Business.MagMediaReports.Interfaces
{
    public interface IMagMediaReportName
    {
        string GetFileName(string name, string format, string tpeName);
        string GetArchiveName(MagMediaReportPeriodModel period);
    }
}
