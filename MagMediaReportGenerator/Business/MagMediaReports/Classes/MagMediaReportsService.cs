using MagMediaReportGenerator.Business.MagMediaReports.Interfaces;
using MagMediaReportGenerator.Business.MagMediaReports.Models;
using MagMediaReportGenerator.Common.Archiving.Models;
using MagMediaReportGenerator.Common.Enums;
using MagMediaReportGenerator.Common.Services;

using System.Linq;

namespace MagMediaReportGenerator.Business.MagMediaReports.Classes
{
    public class MagMediaReportsService : IMagMediaReportService
    {
        private readonly IServiceCollection<IMagMediaReportService> _serviceCollection;

        public MagMediaReportsService(IServiceCollection<IMagMediaReportService> serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }
        public FileModel<string> ConvertReportFiles(MagMediaReportsData w2ReportsData)
        {
            if (!w2ReportsData.MagMediaReportFilesInfo.Any()) return null;
            if (w2ReportsData.MagMediaReportFilesInfo.Count() == 1) return _serviceCollection[ExportDocumentType.File.ToString()].ConvertReportFiles(w2ReportsData);
            return _serviceCollection[ExportDocumentType.Archive.ToString()].ConvertReportFiles(w2ReportsData);
        }
    }
}
