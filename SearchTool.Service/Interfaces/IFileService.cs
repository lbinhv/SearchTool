using SearchTool.Service.Models;
using System.Threading.Tasks;

namespace SearchTool.Service.Interfaces
{
    public interface IFileService
    {
        Task<bool> CreateCsvFile(FileParameterModel fileParameter);
    }
}
