using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace UserService.Data
{
    public class UserServiceDbContext : DbContext
    {
        public UserServiceDbContext(DbContextOptions<UserServiceDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
