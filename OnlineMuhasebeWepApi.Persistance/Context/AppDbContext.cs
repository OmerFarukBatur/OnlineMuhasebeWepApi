using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineMuhasebeWepApi.Domain.Abstractions;
using OnlineMuhasebeWepApi.Domain.AppEntities;
using OnlineMuhasebeWepApi.Domain.AppEntities.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OnlineMuhasebeWepApi.Persistance.Context
{
    public sealed class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<AppUserCompany> AppUserCompanies { get; set; }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                //if (entry.State == EntityState.Added)
                //{
                //    entry.Property(p => p.Id)
                //        .CurrentValue = Guid.NewGuid().ToString();
                //    entry.Property(p => p.CreatedDate)
                //        .CurrentValue = DateTime.Now;
                //}
                //else if (entry.State == EntityState.Modified)
                //{
                //    entry.Property(p => p.UpdateDate)
                //        .CurrentValue = DateTime.Now;
                //}

                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.UpdateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };

                //switch (entry.State)
                //{
                //    case EntityState.Modified:
                //        entry.Entity.UpdateDate = DateTime.Now;
                //        break;
                //    case EntityState.Added:
                //        entry.Entity.CreatedDate = DateTime.Now;
                //        break;
                //    default:
                //        _ = DateTime.Now;
                //        break;
                //}
            }
            return base.SaveChangesAsync(cancellationToken);
        }


        public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            public AppDbContext CreateDbContext(string[] args)
            {
                var builder = new DbContextOptionsBuilder();
                var connectionString = "Data Source=OMERB;Initial Catalog=MuhasebeMasterDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                builder.UseSqlServer(connectionString);
                return new AppDbContext(builder.Options);
            }
        }
    }
}
