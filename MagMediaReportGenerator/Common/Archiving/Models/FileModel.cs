namespace MagMediaReportGenerator.Common.Archiving.Models
{
    public class FileModel<TFileContent>
    {
        public string FileName { get; }
        public TFileContent FileContent { get; }

        public FileModel(string fileName, TFileContent fileContent)
        {
            FileName = fileName;
            FileContent = fileContent;
        }
    }
}
