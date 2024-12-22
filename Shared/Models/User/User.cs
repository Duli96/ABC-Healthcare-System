using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Shared.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [JsonIgnore] // Prevent exposing raw password hashes in API responses
        public string PasswordHash { get; set; }

        [Required]
        public int RoleId { get; set; }
        
        [JsonIgnore]
        public Role Role { get; set; }
    }
}
