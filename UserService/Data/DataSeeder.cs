using UserService.Data;
using Shared.Models;

namespace UserService.Services
{
    public class DataSeeder
    {
        private readonly UserServiceDbContext _context;

        public DataSeeder(UserServiceDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (!_context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role { Name = "ADMIN" },
                    new Role { Name = "DOCTOR" },
                    new Role { Name = "NURSE" },
                    new Role { Name = "RADILOGIST" }
                };

                _context.Roles.AddRange(roles);
                _context.SaveChanges();
            }

            if (!_context.Permissions.Any())
            {
                var permissions = new List<Permission>
                {
                    new Permission { Name = "ManageUsers" },
                    new Permission { Name = "ViewPatientRecords" },
                    new Permission { Name = "UploadMedicalImages" },
                    new Permission { Name = "ClassifyMedicalImages" },
                    new Permission { Name = "GenerateDiagnosticReports" },
                    new Permission { Name = "RetrieveMedicalImages" }
                };

                _context.Permissions.AddRange(permissions);
                _context.SaveChanges();
            }

            if (!_context.RolePermissions.Any())
            {
                var adminRole = _context.Roles.First(r => r.Name == "ADMIN");
                var doctorRole = _context.Roles.First(r => r.Name == "DOCTOR");
                var nurseRole = _context.Roles.First(r => r.Name == "NURSE");
                var radiologistRole = _context.Roles.First(r => r.Name == "RADIOLOGIST");

                var permissions = _context.Permissions.ToList();

                var rolePermissions = new List<RolePermission>
                {
                    new RolePermission { RoleId = adminRole.Id, PermissionId = permissions.First(p => p.Name == "ManageUsers").Id },
                    new RolePermission { RoleId = adminRole.Id, PermissionId = permissions.First(p => p.Name == "ViewPatientRecords").Id },
                    new RolePermission { RoleId = doctorRole.Id, PermissionId = permissions.First(p => p.Name == "GenerateDiagnosticReports").Id },
                    new RolePermission { RoleId = nurseRole.Id, PermissionId = permissions.First(p => p.Name == "UploadMedicalImages").Id },
                    new RolePermission { RoleId = radiologistRole.Id, PermissionId = permissions.First(p => p.Name == "ClassifyMedicalImages").Id }
                };

                _context.RolePermissions.AddRange(rolePermissions);
                _context.SaveChanges();
            }
        }
    }
}
