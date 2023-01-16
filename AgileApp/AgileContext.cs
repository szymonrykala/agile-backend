using AgileApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AgileApp
{
    public class AgileContext : DbContext
    {
        public DbSet<User>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=student;Database=AgileDb");
    }
}
