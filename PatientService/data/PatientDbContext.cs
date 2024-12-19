using Microsoft.EntityFrameworkCore;
using PatientService.Models;

namespace PatientService.Data
{
    public class PatientDbContext : DbContext
    {
        public PatientDbContext(DbContextOptions<PatientDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Task> Tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Patient)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.PatientId);

            modelBuilder.Entity<Task>()
                .HasOne(t => t.Condition)
                .WithMany(c => c.Tasks)
                .HasForeignKey(t => t.ConditionId);
        }
    }
}