using MagMediaReportGenerator.Common.Archiving.Models;
using System.Collections.Generic;

namespace MagMediaReportGenerator.Common.Archiving
{
    public interface IArchivator<TFileType>
    {
        byte[] ArchiveFiles(IEnumerable<FileModel<TFileType>> files);
    }
}
