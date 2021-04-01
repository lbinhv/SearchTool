using System.IO;

namespace SearchTool.Service.Helpers
{
    public class FileHelper
    {
        public static string CreateDirectory(string path)
        {
            // If the directory is exist
            if (Directory.Exists(path))
            {
                return path;
            }

            // Try to create the directory.
            return Directory.CreateDirectory(path).FullName;
        }
    }
}
