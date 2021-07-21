//created as an example
using MagMediaReportGenerator.DAL.DataProviders.Models;

using System.Collections.Generic;

namespace MagMediaReportGenerator.DAL.DataProviders.Interfaces
{
    public interface IMagMediaReportDataProvider
    {
        IEnumerable<ReportPathDataModel> GetReportsPathData(List<ReportTypeDataModel> reportsTypes);
    }
}
