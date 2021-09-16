using Microsoft.EntityFrameworkCore;
using TesteTexoIT.Domain.Entities;

namespace TesteTexoIT.Domain.Context
{
    public class TexoContext : DbContext
    {
        public TexoContext(DbContextOptions<TexoContext> options) : base(options)
        { }

        public TexoContext()
        {

        }

        public DbSet<Award> Awards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Award>().HasKey(a => a.Id);
            base.OnModelCreating(modelBuilder);
        }
    }
}
