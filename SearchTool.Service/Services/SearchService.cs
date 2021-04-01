using SearchTool.Service.Interfaces;
using SearchTool.Service.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace SearchTool.Service.Services
{
    public class SearchService : ISearchService
    {
        /// <summary>
        /// This method will help to finding the string value using the Native Search String Algorithm 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="searchValue"></param>
        /// <param name="delimiter"></param>
        /// <returns></returns>
        public async Task<IList<SearchDataModel>> GetSearchData(string filePath, string searchValue, char delimiter)
        {
            var searchData = new List<SearchDataModel>();
            SearchDataModel row;
            Stopwatch searchTime;

            //Read Csv file
            using (var rd = new StreamReader(filePath))
            {
                while (!rd.EndOfStream)
                {
                    var splits = rd.ReadLine().Split(delimiter);

                    searchTime = new Stopwatch();
                    searchTime.Start();

                    //Call Native Search String Method
                    if (await NativeSearchString(splits[1], searchValue))
                    {
                        searchTime.Stop();
                        row = new SearchDataModel
                        {
                            Id = splits[0],
                            Content = splits[1].Substring(0, 300),
                            SearchTime = searchTime.Elapsed.TotalMilliseconds.ToString()
                        };
                        searchData.Add(row);
                    }
                    searchTime.Stop();
                }
            }
            return await Task.FromResult(searchData);
        }

        private async Task<bool> NativeSearchString(string txt, string pat)
        {
            int M = pat.Length;
            int N = txt.Length;
            int i = 0;

            while (i <= N - M)
            {
                int j;

                /* For current index i, check for pattern match */
                for (j = 0; j < M; j++)
                {
                    if (txt[i + j] != pat[j])
                        break;
                }

                // if pat[0...M-1] = txt[i, i+1, ...i+M-1] 
                if (j == M)
                {
                    //Pattern found
                    return await Task.FromResult(true);
                }
                else if (j == 0)
                    i = i + 1;
                else
                    i = i + j; // slide the pattern by j 
            }
            return await Task.FromResult(false);
        }
    }
}
