using SearchTool.Service.Helpers;
using SearchTool.Service.Interfaces;
using SearchTool.Service.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace SearchTool.Service.Services
{
    public class FileService : IFileService
    {
        /// <summary>
        /// This method will help to create the Csv file
        /// </summary>
        /// <param name="fileParameter"></param>
        /// <returns></returns>
        public async Task<bool> CreateCsvFile(FileParameterModel fileParameter)
        {
            //Check and create Directory If It Not Exist
            var filePath = await Task.Run(() => $"{FileHelper.CreateDirectory(fileParameter.FolderUrl)}//{fileParameter.FileName}");

            using (var writer = new CsvFileWriter(filePath))
            {
                //Config to get 100000 from App Setting
                for (int i = 0; i < fileParameter.TotalRows; i++)
                {
                    var row = new CsvRowModel
                    {
                        $"{ Guid.NewGuid()}{fileParameter.Delimiter}{RandomString(fileParameter.MinContentLength , fileParameter.MaxContentLength, fileParameter.Pattern)}"
                    };

                    await Task.Run(() => writer.WriteRow(row));
                }
            }

            return await Task.FromResult(true);
        }

        //The random characters (Alphanumeric & Blank space)
        private string RandomString(int minByteValue, int maxByteValue, string pattern)
        {
            byte[] testBute = BitConverter.GetBytes(1000);
            var tesst = BitConverter.ToInt32(testBute, 0);

            byte[] minByte = BitConverter.GetBytes(minByteValue);
            byte[] maxByte = BitConverter.GetBytes(maxByteValue);

            var random = new Random();
            var length = random.Next(BitConverter.ToInt32(minByte, 0), BitConverter.ToInt32(maxByte, 0));

            return new string(Enumerable.Range(1, length).Select(_ => pattern[random.Next(pattern.Length)]).ToArray());
        }
    }
}
