using Microsoft.EntityFrameworkCore;
using PatientService.Models;

namespace PatientService.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<MedicalProcedure> Procedures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalProcedure>()
                .HasOne(p => p.Patient)
                .WithMany(p => p.Procedures)
                .HasForeignKey(p => p.PatientId);

            modelBuilder.Entity<MedicalProcedure>()
                .HasOne(p => p.Condition)
                .WithMany(c => c.Procedures)
                .HasForeignKey(p => p.ConditionId);
        }
    }
}