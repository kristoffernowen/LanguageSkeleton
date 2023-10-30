using AutoMapper;
using Core.Models.Words;
using Data.PersistenceEntities;

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
