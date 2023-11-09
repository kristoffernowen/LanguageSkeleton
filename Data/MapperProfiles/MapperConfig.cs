using AutoMapper;
using Data.PersistenceEntities;
using Data.PersistenceEntities.Verbs;
using Domain.Models.Words;

namespace Data.MapperProfiles
{
    internal class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<NounEntity, Noun>().ReverseMap();
            CreateMap<VerbEntity, Verb>().ReverseMap();
            CreateMap<WeakVerb, Verb>().ReverseMap();
            CreateMap<ShortVerb, Verb>().ReverseMap();
            CreateMap<StrongVerb, Verb>().ReverseMap();
            CreateMap<IrregularVerb, Verb>().ReverseMap();
        }
    }
}
