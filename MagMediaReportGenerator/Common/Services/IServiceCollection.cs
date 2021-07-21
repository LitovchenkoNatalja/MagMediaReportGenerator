using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagMediaReportGenerator.Common.Services
{
    public interface IServiceCollection<TDependency>
    {
        TDependency this[string key] { get; }
    }
}
