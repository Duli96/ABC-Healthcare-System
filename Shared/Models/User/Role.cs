using System.Collections.Generic;

namespace Shared.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; } // Admin, Doctor, Nurse, Radiologist
        public string Description { get; set; }
        
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
