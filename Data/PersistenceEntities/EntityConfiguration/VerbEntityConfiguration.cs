using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PersistenceEntities.EntityConfiguration;

public class VerbEntityConfiguration : IEntityTypeConfiguration<VerbEntity>
{
    public void Configure(EntityTypeBuilder<VerbEntity> builder)
    {
        builder.ToTable("Verbs");

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
    }
}