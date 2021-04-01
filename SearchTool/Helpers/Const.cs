namespace SearchTool.Helpers
{
    public class Const
    {
        #region Variable Name
        public const string Pattern = "Pattern";
        public const string FolderPath = "FolderPath";
        public const string FileName = "FileName";
        public const string Delimiter = "Delimiter";
        public const string MaxContentLength = "MaxContentLength";
        public const string MinContentLength = "MinContentLength";
        public const string TotalRows = "TotalRows";
        #endregion

        #region Error Type
        public const string IOException = "System.IO.IOException";
        #endregion

        #region Error
        public const string FileIsUse = "Unable to open the file: being used by another person or program, please close it first!";
        public const string CreateFileSuccessfully = "Create Csv File Successfully";
        public const string CreateFileUnSuccessfully = "There was a problem when create file please try again!";
        public const string MissingRequiredInfo = "Please provide the values of FolderUrl, FileName, Delimiter, MinContentLength, MaxContentLength, and Pattern before using in the function.";
        #endregion
    }
}