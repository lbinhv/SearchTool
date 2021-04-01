namespace SearchTool.Service.Models
{
    public class FileParameterModel
    {
        public int TotalRows { get; set; }
        public int MinContentLength { get; set; }
        public int MaxContentLength { get; set; }
        public string Pattern { get; set; }
        public string Delimiter { get; set; }
        public string FolderUrl { get; set; }
        public string FileName { get; set; }
    }
}
