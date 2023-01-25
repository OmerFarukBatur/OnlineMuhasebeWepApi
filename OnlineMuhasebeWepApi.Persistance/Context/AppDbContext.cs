using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeWepApi.Domain.AppEntities;
using OnlineMuhasebeWepApi.Domain.AppEntities.Identity;

namespace OnlineMuhasebeWepApi.Persistance.Context
{
    public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<AppUserCompany> AppUserCompanies { get; set; }

    }
}
