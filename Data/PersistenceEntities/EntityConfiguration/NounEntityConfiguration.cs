using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PersistenceEntities.EntityConfiguration
{
    public class NounEntityConfiguration : IEntityTypeConfiguration<NounEntity>
    {
        public void Configure(EntityTypeBuilder<NounEntity> builder)
        {
            builder.ToTable("Nouns");

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
        }
    }
}
