using MagMediaReportGenerator.Common.Archiving.Models;

using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;

namespace MagMediaReportGenerator.Common.Archiving
{
    public class Zipper : IArchivator<string>
    {
        public byte[] ArchiveFiles(IEnumerable<FileModel<string>> files)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (var archive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    files.ToList().ForEach(file =>
                    {
                        var archiveEntry = archive.CreateEntry(file.FileName);
                        using (var entryStream = archiveEntry.Open())
                        using (var streamWriter = new StreamWriter(entryStream))
                        {
                            streamWriter.Write(file.FileContent, Encoding.ASCII);
                        }
                    });
                }

                return ConvertToBytes(memoryStream);
            }
        }

        private byte[] ConvertToBytes(MemoryStream stream)
        {
            byte[] zipArch = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(zipArch, 0, zipArch.Length);

            return zipArch;
        }
    }
}
