using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PersistenceEntities.EntityConfiguration
{
    public class NounEntityConfiguration : IEntityTypeConfiguration<NounEntity>
    {
        public void Configure(EntityTypeBuilder<NounEntity> builder)
        {
            builder.HasData
            (
                new NounEntity
                {
                    Id = "b73f8789-958b-4752-9f70-6d1a73794b03",
                    SingularForm = "pojke",
                    PluralForm = "pojkar",
                    NounArticle = NounArticle.en,
                    NounDeclension = NounDeclension.Two
                },
                new NounEntity
                {
                    Id = "a163d3d1-70c1-4dbf-872c-8ebad193d3ef",
                    SingularForm = "flicka",
                    PluralForm = "flickor",
                    NounArticle = NounArticle.en,
                    NounDeclension = NounDeclension.One
                },
                new NounEntity
                {
                    Id = "cca1e103-c140-4acf-a7bf-32b14adab539",
                    SingularForm = "bil",
                    PluralForm = "bilar",
                    NounArticle = NounArticle.en,
                    NounDeclension = NounDeclension.Two
                },
                new NounEntity
                {
                    Id = "7357f66f-f38e-4f15-b949-3caa228d0b1f",
                    SingularForm = "fisk",
                    PluralForm = "fiskar",
                    NounArticle = NounArticle.en,
                    NounDeclension = NounDeclension.Two
                },
                new NounEntity
                {
                    Id = "d42ae057-05ce-4f93-9b17-75d2689c06e7",
                    SingularForm = "bok",
                    PluralForm = "böcker",
                    NounArticle = NounArticle.en,
                    NounDeclension = NounDeclension.Two
                }
            );
        }
    }
}
