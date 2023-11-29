using Data.PersistenceEntities.Verbs;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PersistenceEntities.EntityConfiguration
{
    public class IrregularVerbConfiguration : IEntityTypeConfiguration<IrregularVerb>
    {
        public void Configure(EntityTypeBuilder<IrregularVerb> builder)
        {
            builder.HasData
            (
                new IrregularVerb
                {
                    Id = "fe7fc830-0d37-4f0f-a96d-be258253cee0",
                    Imperative = "ska",
                    Infinitive = "skola",
                    PresentTense = "ska",
                    PastTense = "skulle",
                    Supine = "skolat",
                    VerbConjugation = VerbConjugation.IrregularVerb.ToString()
                },
                new IrregularVerb
                {
                    Id = "99eaf871-c042-4fec-9440-384f00e3f54d",
                    Imperative = "var",
                    Infinitive = "vara",
                    PresentTense = "är",
                    PastTense = "var",
                    Supine = "varit",
                    VerbConjugation = VerbConjugation.IrregularVerb.ToString()
                },
                new IrregularVerb
                {
                    Id = "cfc483f6-ce2b-49cf-bc8b-d092dcc83027",
                    Imperative = "ha",
                    Infinitive = "ha",
                    PresentTense = "har",
                    PastTense = "hade",
                    Supine = "haft",
                    VerbConjugation = VerbConjugation.IrregularVerb.ToString()
                }
            );
        }
    }
}
