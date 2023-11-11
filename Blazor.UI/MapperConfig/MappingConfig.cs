using AutoMapper;
using Blazor.UI.Models.BasicSentence;
using LanguageSkeleton.Blazor.UI.Services.Base;

namespace Blazor.UI.MapperConfig
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<DisplayBasicSentenceDto, DisplayBasicSentenceVm>().ReverseMap();
            CreateMap<DisplayBasicSentenceVm, DisplayBasicSentenceQuery>();
        }
    }
}
