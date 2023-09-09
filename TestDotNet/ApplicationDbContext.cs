using Microsoft.EntityFrameworkCore;
using TestDotNet.Entities;

namespace TestDotNet
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Ward> Wards { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            // Configure relationships between entities
            modelBuilder.Entity<District>()
                .HasOne<City>()
                .WithMany()
                .HasForeignKey(d => d.CityId);

            modelBuilder.Entity<Ward>()
                .HasOne<District>()
                .WithMany()
                .HasForeignKey(w => w.DistrictId);
        }
    }
}
