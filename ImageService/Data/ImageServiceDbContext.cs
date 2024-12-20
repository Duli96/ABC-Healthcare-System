using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace ImageService.Data
{
    public class ImageServiceDbContext : DbContext
    {
        public ImageServiceDbContext(DbContextOptions<ImageServiceDbContext> options) : base(options) { }

        public DbSet<Image> Images { get; set; }
        public DbSet<ScanType> ScanTypes { get; set; }
        public DbSet<DiseaseType> DiseaseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>()
                .HasOne(i => i.Patient)
                .WithMany(p => p.Images)
                .HasForeignKey(i => i.PatientId);

            modelBuilder.Entity<ScanType>()
                .HasMany(st => st.Images)
                .WithOne()
                .HasForeignKey(i => i.ImageTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<DiseaseType>()
                .HasMany(dt => dt.Images)
                .WithOne()
                .HasForeignKey(i => i.ImageTypeId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
