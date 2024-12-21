using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace UserService.Data
{
    public class UserServiceDbContextFactory : IDesignTimeDbContextFactory<UserServiceDbContext>
    {
        public UserServiceDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var optionsBuilder = new DbContextOptionsBuilder<UserServiceDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            
            optionsBuilder.UseMySql(
                connectionString, 
                new MySqlServerVersion(new Version(8, 0, 2)) 
            );

            return new UserServiceDbContext(optionsBuilder.Options);
        }
    }
}
