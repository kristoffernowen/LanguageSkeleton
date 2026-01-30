using Domain.Enums.Noun;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PersistenceEntities.EntityConfiguration
{
    public class NounEntityConfiguration : IEntityTypeConfiguration<NounEntity>
    {
        public void Configure(EntityTypeBuilder<NounEntity> builder)
        {
            builder.ToTable("Nouns", t =>
            {
                t.HasCheckConstraint(
                    "CK_Nouns_SingularForm_NotEmpty",
                    "LEN([SingularForm]) > 0");
                t.HasCheckConstraint(
                    "CK_Nouns_PluralForm_NotEmpty",
                    "LEN([PluralForm]) > 0");
            });

            builder.HasKey(n => n.Id);

            builder.Property(n => n.Id)
                .IsRequired()
                .HasMaxLength(36)
                .IsFixedLength();

            builder.Property(n => n.NounArticle)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(n => n.SingularForm)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(n => n.PluralForm)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode();

            builder.Property(n => n.NounDeclension)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.Property(n => n.GrammaticalGender)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            builder.HasIndex(n => n.SingularForm);
            
            builder.HasIndex(n => new { n.SingularForm, n.PluralForm })
                .IsUnique();

            builder.HasIndex(n => n.NounDeclension);

            builder.HasIndex(n => n.GrammaticalGender);

            builder.HasData(
                new NounEntity
                {
                    Id = "b73f8789-958b-4752-9f70-6d1a73794b03",
                    NounArticle = NounArticle.en,
                    SingularForm = "pojke",
                    PluralForm = "pojkar",
                    GrammaticalGender = GrammaticalGender.Masculine,
                    NounDeclension = NounDeclension.Two
                },
                new NounEntity
                {
                    Id = "a163d3d1-70c1-4dbf-872c-8ebad193d3ef",
                    NounArticle = NounArticle.en,
                    SingularForm = "flicka",
                    PluralForm = "flickor",
                    GrammaticalGender = GrammaticalGender.Feminine,
                    NounDeclension = NounDeclension.One
                },
                new NounEntity
                {
                    Id = "cca1e103-c140-4acf-a7bf-32b14adab539",
                    NounArticle = NounArticle.en,
                    SingularForm = "bil",
                    PluralForm = "bilar",
                    GrammaticalGender = GrammaticalGender.CommonGender,
                    NounDeclension = NounDeclension.Two
                },
                new NounEntity
                {
                    Id = "7357f66f-f38e-4f15-b949-3caa228d0b1f",
                    NounArticle = NounArticle.en,
                    SingularForm = "fisk",
                    PluralForm = "fiskar",
                    GrammaticalGender = GrammaticalGender.CommonGender,
                    NounDeclension = NounDeclension.Two
                },
                new NounEntity
                {
                    Id = "d42ae057-05ce-4f93-9b17-75d2689c06e7",
                    NounArticle = NounArticle.en,
                    SingularForm = "bok",
                    PluralForm = "böcker",
                    GrammaticalGender = GrammaticalGender.CommonGender,
                    NounDeclension = NounDeclension.Two
                },
                new NounEntity {
                    Id = "9e1c3f4a-8f4e-4d2a-9f3e-2b6c5d7e8f9a",
                    NounArticle = NounArticle.en,
                    SingularForm = "stad",
                    PluralForm = "städer",
                    GrammaticalGender = GrammaticalGender.CommonGender,
                    NounDeclension = NounDeclension.Three
                },
                new NounEntity
                {
                    Id = "f38485c6-be45-4d52-a043-a561ff09467d",
                    NounArticle = NounArticle.ett,
                    SingularForm = "hus",
                    PluralForm = "hus",
                    GrammaticalGender = GrammaticalGender.Neuter,
                    NounDeclension = NounDeclension.Four
                },
                new NounEntity()
                {
                    Id = "8a9bb56c-2604-4ae6-8462-f044fa5239dc",
                    NounArticle = NounArticle.ett,
                    SingularForm = "brev",
                    PluralForm = "brev",
                    GrammaticalGender = GrammaticalGender.Neuter,
                    NounDeclension = NounDeclension.Five
                }
            );
        }
    }
}
