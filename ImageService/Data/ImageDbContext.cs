using Microsoft.EntityFrameworkCore;
using ImageService.Models;

namespace ImageService.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }

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
