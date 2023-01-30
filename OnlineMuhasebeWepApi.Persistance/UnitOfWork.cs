using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeWepApi.Domain;
using OnlineMuhasebeWepApi.Persistance.Context;

namespace OnlineMuhasebeWepApi.Persistance
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private CompanyDbContext _context;
        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
        }

        public async Task<int> SaveChangesAsync()
        {
            int count = await _context.SaveChangesAsync();
            return count;
        }
    }
}
