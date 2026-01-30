using Data.PersistenceEntities;
using Data.PersistenceEntities.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SqlContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<NounEntity> Nouns { get; set; }
        public DbSet<VerbEntity> Verbs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new NounEntityConfiguration());
            modelBuilder.ApplyConfiguration(new VerbEntityConfiguration());
        }
    }
}
