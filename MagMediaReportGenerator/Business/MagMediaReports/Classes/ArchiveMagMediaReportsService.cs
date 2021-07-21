using MagMediaReportGenerator.Business.MagMediaReports.Interfaces;
using MagMediaReportGenerator.Business.MagMediaReports.Models;
using MagMediaReportGenerator.Common.Archiving;
using MagMediaReportGenerator.Common.Archiving.Models;
using MagMediaReportGenerator.Common.Enums;
using MagMediaReportGenerator.Common.Services;
using MagMediaReportGenerator.DAL.DataProviders.Interfaces;
using MagMediaReportGenerator.DAL.DataProviders.Models;
using MagMediaReportGenerator.DAL.Repositories.Interfaces;
using MagMediaReportGenerator.Entity;

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MagMediaReportGenerator.Business.MagMediaReports.Classes
{
    public class ArchiveMagMediaReportsService : IMagMediaReportService
    {
        private readonly IMagMediaReportDataProvider _reportDataProvider;
        private readonly IArchivator<string> _archivator;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceCollection<IMagMediaReportName> _reportNameServiceCollection;
        private readonly StringBuilder _stringBuilder = new StringBuilder();

        public ArchiveMagMediaReportsService(IMagMediaReportDataProvider reportDataProvider, IArchivator<string> archivator, IUnitOfWork unitOfWork,
            IServiceCollection<IMagMediaReportName> reportNameServiceCollection)
        {
            _reportDataProvider = reportDataProvider;
            _archivator = archivator;
            _unitOfWork = unitOfWork;
            _reportNameServiceCollection = reportNameServiceCollection;
        }

        public FileModel<string> ConvertReportFiles(MagMediaReportsData magMediaReportsData)
        {
            IEnumerable<FileModel<string>> files = GetFullFileInfo(magMediaReportsData);

            byte[] archiveBytes = _archivator.ArchiveFiles(files);
            string archive = Convert.ToBase64String(archiveBytes);

            string archiveName = _reportNameServiceCollection[magMediaReportsData.ReportType.ToString()].GetArchiveName(magMediaReportsData.Period);
            var fileModel = new FileModel<string>(archiveName, archive);

            return fileModel;
        }
        private IEnumerable<FileModel<string>> GetFullFileInfo(MagMediaReportsData magMediaReportsData)
        {
            IEnumerable<int> tpeIds = magMediaReportsData.MagMediaReportFilesInfo.Select(info => (int)info.TpeId).Distinct();
            IEnumerable<TaxPayerEntity> tpes = _unitOfWork.RepositoryOf<TaxPayerEntity>().FindBy(tpe => tpeIds.Contains(tpe.Id)).ToList();

            IEnumerable<ReportPathDataModel> partialFilesPathData = GetpartialFilesPath(magMediaReportsData);

            var fullFilePath = (from partialFilePathData in partialFilesPathData
                                join reportInfo in magMediaReportsData.MagMediaReportFilesInfo
                                    on new { partialFilePathData.ReportType, partialFilePathData.StateId }
                                    equals new { reportInfo.ReportType, reportInfo.StateId }
                                join tpe in tpes on (int)reportInfo.TpeId equals tpe.Id
                                select (partialFilePathData, tpe.Name, reportInfo.ReportContent)).ToList();

            IEnumerable<FileModel<string>> files = fullFilePath.Select(fileNameData =>
            {
                var (partialFilePathData, tpeName, file) = fileNameData;
                string fileName = CreateFilePath(partialFilePathData, tpeName, magMediaReportsData.ReportType);
                return new FileModel<string>(fileName, file);
            });

            return files;
        }

        private IEnumerable<ReportPathDataModel> GetpartialFilesPath(MagMediaReportsData magMediaReportsData)
        {
            List<ReportTypeDataModel> reportsTypes = magMediaReportsData.MagMediaReportFilesInfo
               .Select(info => new ReportTypeDataModel
               {
                   ReportType = info.ReportType,
                   StateId = info.StateId
               }).ToList();
            return _reportDataProvider.GetReportsPathData(reportsTypes);
        }

        private string CreateFilePath(ReportPathDataModel partialFilePathData, string tpeName, FragmentFormedReportType reportType)
        {
            _stringBuilder.Clear();
            _stringBuilder.Append(tpeName);
            _stringBuilder.Append(Path.DirectorySeparatorChar);
            _stringBuilder.Append(partialFilePathData.State ?? "Federal");
            _stringBuilder.Append(Path.DirectorySeparatorChar);
            _stringBuilder.Append(_reportNameServiceCollection[reportType.ToString()].GetFileName(partialFilePathData.FileName, partialFilePathData.Format, tpeName));
            return _stringBuilder.ToString();
        }

    }
}
