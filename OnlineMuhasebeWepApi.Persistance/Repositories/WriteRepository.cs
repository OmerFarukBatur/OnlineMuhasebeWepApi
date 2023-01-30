using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeWepApi.Domain.Abstractions;
using OnlineMuhasebeWepApi.Domain.Repositories;
using OnlineMuhasebeWepApi.Persistance.Context;

namespace OnlineMuhasebeWepApi.Persistance.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : Entity
    {
        private static readonly Func<CompanyDbContext, string, Task<T>> GetByIdCompiled = EF.CompileAsyncQuery((CompanyDbContext context, string id
            ) => context.Set<T>().FirstOrDefault(p => p.Id == id));

        private CompanyDbContext _context;

        public DbSet<T> Entity { get; set; }

        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
            Entity = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await Entity.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Entity.AddRangeAsync(entities);
        }

        
        public void Remove(T entity)
        {
            Entity.Remove(entity);
        }

        public async Task RemoveByIdAsync(string id)
        {
            T entity = await GetByIdCompiled(_context,id);
            Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Entity.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            Entity.Update(entity);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Entity.UpdateRange(entities);
        }
    }
}
