using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OnlineMuhasebeWepApi.Domain.Abstractions;
using OnlineMuhasebeWepApi.Domain.AppEntities;

namespace OnlineMuhasebeWepApi.Persistance.Context
{
    public sealed class CompanyDbContext : DbContext
    {
        private string ConnectionString = "";
        public CompanyDbContext(Company company = null)
        {
            if (company != null)
            {
                if (company.UserId == "")
                {
                    ConnectionString = $" Data Source={company.ServerName};" +
                        $"Initial Catalog={company.DatabaseName};" +
                        $"Integrated Security=True;" +
                        $"Connect Timeout=30;" +
                        $"Encrypt=False;" +
                        $"TrustServerCertificate=False;" +
                        $"ApplicationIntent=ReadWrite;" +
                        $"MultiSubnetFailover=False";
                }
                else
                {
                    ConnectionString = $" Data Source={company.ServerName};" +
                        $"Initial Catalog={company.DatabaseName};" +
                        $"User Id={company.UserId};" +
                        $"Password = {company.Password};" +
                        $"Integrated Security=True;" +
                        $"Connect Timeout=30;" +
                        $"Encrypt=False;" +
                        $"TrustServerCertificate=False;" +
                        $"ApplicationIntent=ReadWrite;" +
                        $"MultiSubnetFailover=False";
                }
            }
             
           
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            => modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);

        public class CompanyDbContextFactory : IDesignTimeDbContextFactory<CompanyDbContext>
        {
            public CompanyDbContext CreateDbContext(string[] args)
            {
                return new CompanyDbContext();
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<Entity>();
            foreach (var entry in entries)
            {
                _ = entry.State switch
                {
                    EntityState.Added => entry.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => entry.Entity.UpdateDate = DateTime.UtcNow,
                    _ => DateTime.UtcNow
                };
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
