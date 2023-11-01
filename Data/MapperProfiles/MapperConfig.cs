using AutoMapper;
using Data.PersistenceEntities;
using Domain.Models.Words;

namespace Data.MapperProfiles
{
    internal class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<NounEntity, Noun>().ReverseMap();
            CreateMap<VerbEntity, Verb>().ReverseMap();
        }
    }
}
