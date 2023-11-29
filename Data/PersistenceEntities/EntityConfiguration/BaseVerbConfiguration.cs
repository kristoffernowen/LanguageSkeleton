using Data.PersistenceEntities.Verbs;
using Data.PersistenceEntities.Verbs.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.PersistenceEntities.EntityConfiguration
{
    public class BaseVerbConfiguration : IEntityTypeConfiguration<BaseVerb>
    {
        public void Configure(EntityTypeBuilder<BaseVerb> builder)
        {
            builder.HasDiscriminator<string>("verb_type")
                .HasValue<WeakVerb>("Weak")
                .HasValue<ShortVerb>("Short")
                .HasValue<StrongVerb>("Strong")
                .HasValue<IrregularVerb>("Irregular");
        }
    }
}
