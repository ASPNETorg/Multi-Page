using Microsoft.EntityFrameworkCore;
using FullScaffold.Sample01.Models.DomainModels;

namespace FullScaffold.Sample01.Models
{
    public class ProjectDbContext  : DbContext
    {
        public ProjectDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Person>? Person { get; set; }
    }
}
