using Data.PersistenceEntities.Verbs;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PersistenceEntities.EntityConfiguration
{
    public class WeakVerbConfiguration : IEntityTypeConfiguration<WeakVerb>
    {
        public void Configure(EntityTypeBuilder<WeakVerb> builder)
        {
            builder.HasData(
                new WeakVerb
                {
                    Id = "5d4385e4-39ab-458f-bad9-f217c08bdb86",
                    Imperative = "prata",
                    PresentTense = "pratar",
                    VerbConjugation = VerbConjugation.ArVerb.ToString(),
                },
                new WeakVerb
                {
                    Id = "f61fa1fa-b3ea-4c02-ad5f-9da466c07d11",
                    Imperative = "läs",
                    PresentTense = "läser",
                    VerbConjugation = VerbConjugation.ErVerb.ToString()
                }
            );
        }
    }
}
