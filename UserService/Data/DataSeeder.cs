using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace UserService.Data
{
    public class DataSeeder
    {
        private readonly UserServiceDbContext _context;

        public DataSeeder(UserServiceDbContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            try
            {
                await _context.Database.EnsureCreatedAsync();

                if (!await _context.Roles.AnyAsync())
                {
                    var roles = new List<Role>
                    {
                       new Role { Name = "ADMIN", Description = "Administrator" },
                        new Role { Name = "DOCTOR", Description = "Medical Doctor" },
                        new Role { Name = "NURSE", Description = "Nurse" },
                        new Role { Name = "RADIOLOGIST", Description = "Radiologist" }
                    };

                    await _context.Roles.AddRangeAsync(roles);
                }

                if (!await _context.Permissions.AnyAsync())
                {
                    var permissions = new List<Permission>
                    {
                        new Permission { Name = "ManageUsers" },
                        new Permission { Name = "ViewPatients" },
                        new Permission { Name = "ManagePatients" },
                        new Permission { Name = "ViewImages" },
                        new Permission { Name = "ManageImages"}
                    };

                    await _context.Permissions.AddRangeAsync(permissions);
                }

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error seeding data", ex);
            }
        }
    }
}