using AutoMapper;
using Domain.Models.Words;
using LanguageSkeleton.Api.Dtos.Verb;

namespace LanguageSkeleton.Api.MapperProfiles
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateVerbInputDto, Verb>();
        }
    }
}
