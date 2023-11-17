
using System.Diagnostics;
using Data.PersistenceEntities;
using Data.PersistenceEntities.Verbs;
using Data.PersistenceEntities.Verbs.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<NounEntity> Nouns { get; set; }
        public DbSet<BaseVerb> Verbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BaseVerb>()
                .HasDiscriminator<string>("verb_type")
                .HasValue<WeakVerb>("Weak")
                .HasValue<ShortVerb>("Short")
                .HasValue<StrongVerb>("Strong")
                .HasValue<IrregularVerb>("Irregular");
        }
    }
}
