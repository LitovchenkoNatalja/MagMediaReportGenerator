using MagMediaReportGenerator.Business.MagMediaReports.Interfaces;
using MagMediaReportGenerator.Business.MagMediaReports.Models;
using MagMediaReportGenerator.Common.Archiving.Models;
using MagMediaReportGenerator.Common.Enums;
using MagMediaReportGenerator.Common.Services;
using MagMediaReportGenerator.DAL.Repositories.Interfaces;
using MagMediaReportGenerator.Entity;

using System;
using System.Linq;
using System.Text;

namespace MagMediaReportGenerator.Business.MagMediaReports.Classes
{
    public class FileMagMediaReportsService : IMagMediaReportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceCollection<IMagMediaReportName> _reportNameServiceCollection;

        public FileMagMediaReportsService(IUnitOfWork unitOfWork, IServiceCollection<IMagMediaReportName> reportNameServiceCollection)
        {
            _unitOfWork = unitOfWork;
            _reportNameServiceCollection = reportNameServiceCollection;
        }

        public FileModel<string> ConvertReportFiles(MagMediaReportsData magMediaReportsData)
        {
            MagMediaReportFileInfoModel reportInfo = magMediaReportsData.MagMediaReportFilesInfo.FirstOrDefault();
            if (reportInfo == null) return null;

            string fileName = GetFileName(reportInfo.ReportType, reportInfo.TpeId, reportInfo.StateId, magMediaReportsData.ReportType);
            byte[] bytes = Encoding.ASCII.GetBytes(reportInfo.ReportContent);
            string file = Convert.ToBase64String(bytes);
            return new FileModel<string>(fileName, file);
        }

        private string GetFileName(TPEWithholdingType reportType, int tpeId, int? stateId, FragmentFormedReportType fragmentFormedReportType)
        {
            var reportFormat = _unitOfWork.RepositoryOf<MagMediaReportFormat>()
                .FirstOrDefault(format => format.ReportType == (int)reportType && format.StateId == stateId);
            if (reportFormat == null) return string.Empty;
            var taxPayerEntity = _unitOfWork.RepositoryOf<TaxPayerEntity>().FirstOrDefault(tpe => tpe.Id == tpeId);
            return _reportNameServiceCollection[fragmentFormedReportType.ToString()].GetFileName(reportFormat.FileName, reportFormat.Format, taxPayerEntity.Name);
        }
    }
}
