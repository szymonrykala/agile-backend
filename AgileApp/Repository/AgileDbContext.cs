using AgileApp.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace AgileApp
{
    public class AgileDbContext : DbContext
    {
        public DbSet<UserDb>? Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(@"Host=localhost;Username=postgres;Password=student;Database=AgileDb");
    }
}
