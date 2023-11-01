
using Data.PersistenceEntities;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<VerbEntity> Verbs { get; set; }
        public DbSet<NounEntity> Nouns { get; set; }
    }
}
