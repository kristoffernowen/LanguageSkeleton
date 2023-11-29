using Data.PersistenceEntities.Verbs;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PersistenceEntities.EntityConfiguration
{
    public class ShortVerbConfiguration : IEntityTypeConfiguration<ShortVerb>
    {
        public void Configure(EntityTypeBuilder<ShortVerb> builder)
        {
            builder.HasData
            (
                new ShortVerb
                {
                    Id = "81fbd7fb-0bff-4905-9ede-98290b3e0485",
                    Imperative = "bo",
                    PresentTense = "bor",
                    VerbConjugation = VerbConjugation.RVerb.ToString()
                }
            );
        }
    }
}
