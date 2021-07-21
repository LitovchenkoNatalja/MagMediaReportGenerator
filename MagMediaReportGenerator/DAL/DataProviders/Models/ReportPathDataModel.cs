using MagMediaReportGenerator.Common.Enums;

namespace MagMediaReportGenerator.DAL.DataProviders.Models
{
    public class ReportPathDataModel
    {
        public TPEWithholdingType ReportType { get; set; }
        public string Format { get; set; }
        public int? StateId { get; set; }
        public string FileName { get; set; }
        public string State { get; set; }
    }
}
