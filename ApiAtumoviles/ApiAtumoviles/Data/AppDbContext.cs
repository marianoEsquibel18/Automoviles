using Microsoft.EntityFrameworkCore;
using ApiAutomoviles.Models;
namespace ApiAutomoviles.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Automovil> Automoviles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Automovil>()
                .HasIndex(a => a.NumeroMotor)
                .IsUnique();

            modelBuilder.Entity<Automovil>()
                .HasIndex(a => a.NumeroChasis)
                .IsUnique();
        }
    }
}
