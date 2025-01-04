using Microsoft.EntityFrameworkCore;

namespace Reporto.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Report> Reports { get; set; } = null!;
    }

    public class User
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }

    public class Report
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public User? Author { get; set; }
    }
}