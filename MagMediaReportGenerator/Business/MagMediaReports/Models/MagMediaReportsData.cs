using MagMediaReportGenerator.Common.Enums;

using System.Collections.Generic;


namespace MagMediaReportGenerator.Business.MagMediaReports.Models
{
    public class MagMediaReportsData
    {
        public FragmentFormedReportType ReportType { get; }
        public MagMediaReportPeriodModel Period { get; }
        public IEnumerable<MagMediaReportFileInfoModel> MagMediaReportFilesInfo { get; }
        public MagMediaReportsData(IEnumerable<MagMediaReportFileInfoModel> magMediaReportFileInfo, MagMediaReportPeriodModel periodModel,
            FragmentFormedReportType reportType)
        {
            Period = periodModel;
            MagMediaReportFilesInfo = magMediaReportFileInfo;
            ReportType = reportType;
        }
    }
}
