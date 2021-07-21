//created as an example
using System.ComponentModel.DataAnnotations;

namespace MagMediaReportGenerator.Entity
{
    public partial class MagMediaReportFormat
    {
        [Key]
        public int Id { get; set; }
        public int ReportType { get; set; }
        public string FileName { get; set; }
        public string Format { get; set; }
        public int? StateId { get; set; }
    }
}
