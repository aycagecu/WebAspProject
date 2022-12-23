using AuthorizationProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationProject.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDetails>
    { 
        public DbSet<Hayvan> Hayvanlar { get; set; }
        public DbSet<Basvuru> Basvurular { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
