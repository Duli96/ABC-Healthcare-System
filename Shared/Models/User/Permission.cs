using System.Collections.Generic;

namespace Shared.Models
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; } // e.g., ManageUsers, ViewPatientRecords
        public ICollection<RolePermission> RolePermissions { get; set; } = new List<RolePermission>();
    }
}
