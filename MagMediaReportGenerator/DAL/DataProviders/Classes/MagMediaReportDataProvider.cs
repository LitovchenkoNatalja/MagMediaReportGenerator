//created as an example
using MagMediaReportGenerator.DAL.DataProviders.Interfaces;
using MagMediaReportGenerator.DAL.DataProviders.Models;
using MagMediaReportGenerator.Entity;

using System.Collections.Generic;

namespace MagMediaReportGenerator.DAL.DataProviders.Classes
{
    public class MagMediaReportDataProvider : IMagMediaReportDataProvider
    {
        public IEnumerable<ReportPathDataModel> GetReportsPathData(List<ReportTypeDataModel> reportsTypes)
        {
            return null;
        }
    }
}
