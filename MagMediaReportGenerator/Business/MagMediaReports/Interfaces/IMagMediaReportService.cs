using MagMediaReportGenerator.Business.MagMediaReports.Models;
using MagMediaReportGenerator.Common.Archiving.Models;

namespace MagMediaReportGenerator.Business.MagMediaReports.Interfaces
{
    public interface IMagMediaReportService
    {
        FileModel<string> ConvertReportFiles(MagMediaReportsData w2ReportsData);
    }
}
