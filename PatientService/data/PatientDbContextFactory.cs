using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PatientService.Data
{
    public class PatientDbContextFactory : IDesignTimeDbContextFactory<PatientDbContext>
    {
        public PatientDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PatientDbContext>();
            optionsBuilder.UseMySql("server=localhost;port=3306;database=patient_db;user=root;password=;", 
                new MySqlServerVersion(new Version(9, 1, 0)));

            return new PatientDbContext(optionsBuilder.Options);
        }
    }
}