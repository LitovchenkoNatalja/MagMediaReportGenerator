using MagMediaReportGenerator.Common.Enums;

namespace MagMediaReportGenerator.Business.MagMediaReports.Models
{
    public class MagMediaReportFileInfoModel
    {
        public TPEWithholdingType ReportType { get; }
        public int? StateId { get; }
        public int TpeId { get; }
        public string ReportContent { get; }

        public MagMediaReportFileInfoModel(TPEWithholdingType reportType, int? stateId, int tpeId, string reportContent)
        {
            ReportType = reportType;
            StateId = stateId;
            TpeId = tpeId;
            ReportContent = reportContent;
        }
    }
}
