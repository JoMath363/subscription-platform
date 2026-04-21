using Api.Solution.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Api.Solution.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}