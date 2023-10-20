using Core.Models.Words;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Verb> Verbs { get; set; }
        public DbSet<Noun> Nouns { get; set; }
    }
}
