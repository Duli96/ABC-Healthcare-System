using System.Collections.Generic;

namespace Shared.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } // Admin, Doctor, Nurse, Radiologist
        
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
