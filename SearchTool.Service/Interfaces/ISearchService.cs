using SearchTool.Service.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SearchTool.Service.Interfaces
{
    public interface ISearchService
    {
        Task<IList<SearchDataModel>> GetSearchData(string filePath, string searchValue, char delimiter);
    }
}
