using MagMediaReportGenerator.Common.Enums;

namespace MagMediaReportGenerator.DAL.DataProviders.Models
{
    public class ReportTypeDataModel
    {
        public TPEWithholdingType ReportType { get; set; }
        public int? StateId { get; set; }
    }
}
