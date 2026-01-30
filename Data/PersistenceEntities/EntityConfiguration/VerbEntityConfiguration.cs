using Domain.Enums.Verb;
using Domain.Models.Words;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PersistenceEntities.EntityConfiguration;

public class VerbEntityConfiguration : IEntityTypeConfiguration<VerbEntity>
{
    public void Configure(EntityTypeBuilder<VerbEntity> builder)
    {
        builder.ToTable("Verbs", t =>
        {
            t.HasCheckConstraint(
                "CK_Verbs_Infinitive_NotEmpty",
                "LEN([Infinitive]) > 0");
            t.HasCheckConstraint(
                "CK_Verbs_PresentTense_NotEmpty",
                "LEN([PresentTense]) > 0");
            t.HasCheckConstraint(
                "CK_Verbs_Imperative_NotEmpty",
                "LEN([Infinitive]) > 0");
            t.HasCheckConstraint(
                "CK_Verbs_Supine_NotEmpty",
                "LEN([Infinitive]) > 0");
            t.HasCheckConstraint(
                "CK_Verbs_PastTense_NotEmpty",
                "LEN([Infinitive]) > 0");
        });

        builder.HasKey(v => v.Id);

        builder.Property(v => v.Id)
            .IsRequired()
            .HasMaxLength(36)
            .IsFixedLength();

        builder.Property(v => v.VerbConjugation)
            .IsRequired()
            .HasConversion<string>()
            .HasMaxLength(20);

        builder.Property(v => v.Infinitive)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode();

        builder.Property(v => v.Imperative)
            .HasMaxLength(50)
            .IsUnicode();

        builder.Property(v => v.PresentTense)
            .IsRequired()
            .HasMaxLength(50)
            .IsUnicode();

        builder.Property(v => v.PastTense)
            .HasMaxLength(50)
            .IsUnicode();

        builder.Property(v => v.Supine)
            .HasMaxLength(50)
            .IsUnicode();

        builder.HasIndex(v => v.Infinitive);

        builder.HasData( //must contain har and ska
            new VerbEntity
            {
                Id = "8e87ea09-a6bf-431c-9559-b5221b14e81b",
                Infinitive = "ha",
                Imperative = "ha",
                PresentTense = "har",
                PastTense = "hade",
                Supine = "haft",
                VerbConjugation = VerbConjugation.Irregular
            },
            new VerbEntity()
            {
                Id = "3c9d5f4e-2b6a-4f8e-9c3d-1e2f3a4b5c6d",
                Infinitive = "skola",
                Imperative = VerbConstants.NotApplicable,
                PresentTense = "ska",
                PastTense = "skulle",
                Supine = "skolat",
                VerbConjugation = VerbConjugation.Irregular
            },
            new VerbEntity()
            {
                Id = "8b0e7e1a-13fb-45b3-9667-ebfbb938e6c6",
                Infinitive = "prata",
                Imperative = "prata",
                PresentTense = "pratar",
                PastTense = "pratade",
                Supine = "pratat",
                VerbConjugation = VerbConjugation.WeakOne
            },
            new VerbEntity()
            {
                Id = "abcdef12-3456-7890-abcd-ef1234567890",
                Infinitive = "läsa",
                Imperative = "läs",
                PresentTense = "läser",
                PastTense = "läste",
                Supine = "läst",
                VerbConjugation = VerbConjugation.WeakTwo
            },
            new VerbEntity()
            {
                Id = "a1b2c3d4-e5f6-7a8b-9c0d-1e2f3a4b5c6d",
                Infinitive = "bo",
                Imperative = "bo",
                PresentTense = "bor",
                PastTense = "bodde",
                Supine = "bott",
                VerbConjugation = VerbConjugation.WeakThree
            },
            new VerbEntity()
            {
                Id = "f4e5d6c7-b8a9-0b1c-2d3e-4f5a6b7c8d9e",
                Infinitive = "springa",
                Imperative = "spring",
                PresentTense = "springer",
                PastTense = "sprang",
                Supine = "sprungit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "12345678-90ab-cdef-1234-567890abcdef",
                Infinitive = "skriva",
                Imperative = "skriv",
                PresentTense = "skriver",
                PastTense = "skrev",
                Supine = "skrivit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "9abcdef0-1234-5678-9abc-def012345678",
                Infinitive = "ljuga",
                Imperative = "ljug",
                PresentTense = "ljuger",
                PastTense = "ljög",
                Supine = "ljugit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "23456789-0abc-def1-2345-67890abcdef1",
                Infinitive = "flyga",
                Imperative = "flyg",
                PresentTense = "flyger",
                PastTense = "flög",
                Supine = "flugit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "8217bd0f-d1df-4660-b07b-063c33d7f559",
                Infinitive = "ta",
                Imperative = "ta",
                PresentTense = "tar",
                PastTense = "tog",
                Supine = "tagit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "34567890-1bcd-ef23-4567-890abcdef123",
                Infinitive = "bära",
                Imperative = "bär",
                PresentTense = "bär",
                PastTense = "bar",
                Supine = "burit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "45678901-2cde-f345-6789-0abcdef12345",
                Infinitive = "gråta",
                Imperative = "gråt",
                PresentTense = "gråter",
                PastTense = "grät",
                Supine = "gråtit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "d3f5c4e2-2c4b-4f3a-9f3e-2e5f6c7d8e9f",
                Infinitive = "äta",
                PresentTense = "äter",
                Imperative = "ät",
                PastTense = "åt",
                Supine = "ätit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "5713f1ff-9e9e-40c7-901c-ba992a91608e",
                Infinitive = "hålla",
                Imperative = "håll",
                PresentTense = "håller",
                PastTense = "höll",
                Supine = "hållit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "56789012-3def-4567-890a-bcdef1234567",
                Infinitive = "dricka",
                Imperative = "drick",
                PresentTense = "dricker",
                PastTense = "drack",
                Supine = "druckit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "346bcffa-9f2c-498c-8c5a-0394293b4e4e",
                Infinitive = "ge",
                Imperative = "ge",
                PresentTense = "ger",
                PastTense = "gav",
                Supine = "gett",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity() {
                Id = "67890123-4ef5-6789-0abc-def123456789",
                Infinitive = "komma",
                Imperative = "kom",
                PresentTense = "kommer",
                PastTense = "kom",
                Supine = "kommit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "fedcba98-7654-3210-fedc-ba9876543210",
                Infinitive = "sova",
                Imperative = "sov",
                PresentTense = "sover",
                PastTense = "sov",
                Supine = "sovit",
                VerbConjugation = VerbConjugation.StrongFour
            },
            new VerbEntity()
            {
                Id = "78901234-5f67-890a-bcde-f1234567890a",
                Infinitive = "vara",
                Imperative = "var",
                PresentTense = "är",
                PastTense = "var",
                Supine = "varit",
                VerbConjugation = VerbConjugation.Irregular
            },
            new VerbEntity()
            {
                Id = "0fedcba9-8765-4321-0fed-cba987654321",
                Infinitive = "få",
                PresentTense = "får",
                Imperative = "få",
                PastTense = "fick",
                Supine = "fått",
                VerbConjugation = VerbConjugation.Irregular
            }
        );
    }
}