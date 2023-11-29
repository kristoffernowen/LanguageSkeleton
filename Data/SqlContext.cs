using Data.PersistenceEntities;
using Data.PersistenceEntities.EntityConfiguration;
using Data.PersistenceEntities.Verbs.Shared;
using Microsoft.EntityFrameworkCore;

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
            modelBuilder.ApplyConfiguration(new BaseVerbConfiguration());
            modelBuilder.ApplyConfiguration(new WeakVerbConfiguration());
            modelBuilder.ApplyConfiguration(new ShortVerbConfiguration());
            modelBuilder.ApplyConfiguration(new IrregularVerbConfiguration());
            modelBuilder.ApplyConfiguration(new NounEntityConfiguration());
        }
    }
}
