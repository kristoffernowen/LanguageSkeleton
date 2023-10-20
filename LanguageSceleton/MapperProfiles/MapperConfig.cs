using AutoMapper;
using Core.Models.Words;
using LanguageSceleton.Api.Dtos.Verb;

namespace LanguageSceleton.Api.MapperProfiles
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateVerbInputDto, Verb>();
        }
    }
}
