
//created as an example
using System.ComponentModel.DataAnnotations;

namespace MagMediaReportGenerator.Entity
{
    class TaxPayerEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
