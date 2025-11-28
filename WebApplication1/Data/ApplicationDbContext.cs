using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<WebApplication1.Models.Exercise> Exercise { get; set; } = default!;
        public DbSet<WebApplication1.Models.Workout> Workout { get; set; } = default!;
        public DbSet<WebApplication1.Models.Entry> Entry { get; set; } = default!;
    }
}
