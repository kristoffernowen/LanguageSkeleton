
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


        public DbSet<VerbEntity> Verbs { get; set; }
        public DbSet<NounEntity> Nouns { get; set; }
        public DbSet<BaseVerb> BaseVerbs { get; set; }
        public DbSet<WeakVerb>  WeakVerbs { get; set; }
        public DbSet<ShortVerb> ShortVerbs { get; set; }
        public DbSet<StrongVerb> StrongVerbs { get; set; }
        public DbSet<IrregularVerb> IrregularVerbs { get; set; }

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
