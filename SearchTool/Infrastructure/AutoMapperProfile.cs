using AutoMapper;
using SearchTool.Models;
using SearchTool.Service.Models;

namespace SearchTool.Mapping.Infrastructure
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SearchDataModel, SearchResultViewModel>();
        }
    }
}