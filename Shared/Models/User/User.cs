namespace Shared.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; } // Example: Doctor, Radiologist, Administrator
        public string PasswordHash { get; set; } // Secure password storage
    }
}
