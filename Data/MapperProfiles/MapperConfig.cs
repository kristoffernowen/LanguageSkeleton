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
            CreateMap<WeakVerb, Verb>()
                .ForMember(dest => dest.BaseForm,
                    opt =>
                        opt.MapFrom(src => src.PresentTense));
            CreateMap<Verb, WeakVerb>();
            CreateMap<ShortVerb, Verb>()
                .ForMember(dest => dest.BaseForm,
                    opt =>
                        opt.MapFrom(src => src.PresentTense));
            CreateMap<Verb, ShortVerb>();
            CreateMap<StrongVerb, Verb>()
                .ForMember(dest => dest.BaseForm,
                    opt =>
                        opt.MapFrom(src => src.PresentTense));
            CreateMap<Verb, StrongVerb>();
            CreateMap<IrregularVerb, Verb>()
                .ForMember(dest => dest.BaseForm,
                    opt => 
                        opt.MapFrom(src => src.PresentTense));
            CreateMap<Verb, IrregularVerb>();
        }
    }
}
