using Microsoft.EntityFrameworkCore;

namespace StataHelper.Model.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public virtual DbSet<Projects> Projects { get; set; }

        public virtual DbSet<Labels> Labels { get; set; }

        public virtual DbSet<Variables> Variables { get; set; }

        public virtual DbSet<Varlabs> Varlabs { get; set; }
    }
}
