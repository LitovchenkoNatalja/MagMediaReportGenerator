using MagMediaReportGenerator.Common.Enums;

using System;

namespace MagMediaReportGenerator.Business.MagMediaReports.Models
{
    public class MagMediaReportPeriodModel
    {
        public int Year { get; }
        public YearQuarter Quarter { get; }
        public DateTime CurrentDate { get; }

        public MagMediaReportPeriodModel(DateTime currentDate, int year, int quarter = 0)
        {
            Year = year;
            CurrentDate = currentDate;
            Quarter = (YearQuarter)quarter;
        }
    }
}
