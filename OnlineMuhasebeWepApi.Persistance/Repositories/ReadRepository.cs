using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeWepApi.Domain.Abstractions;
using OnlineMuhasebeWepApi.Domain.Repositories;
using OnlineMuhasebeWepApi.Persistance.Context;
using System.Linq.Expressions;

namespace OnlineMuhasebeWepApi.Persistance.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : Entity
    {
        private static readonly Func<CompanyDbContext, string, Task<T>> GetByIdCompiled = EF.CompileAsyncQuery((CompanyDbContext context, string id
            ) => context.Set<T>().FirstOrDefault(p => p.Id == id));

        private static readonly Func<CompanyDbContext, Task<T>> GetFirstCompiled = EF.CompileAsyncQuery((CompanyDbContext context
        ) => context.Set<T>().FirstOrDefault());

        private static readonly Func<CompanyDbContext, Expression<Func<T, bool>> , Task<T>> GetFirstByExpressionCompiled = EF.CompileAsyncQuery((CompanyDbContext context,Expression<Func<T, bool>> expression
           ) => context.Set<T>().FirstOrDefault(expression));

        private CompanyDbContext _context;
        public DbSet<T> Entity { get; set; }

        public void SetDbContextInstance(DbContext context)
        {
            _context = (CompanyDbContext)context;
            Entity = _context.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return Entity.AsQueryable();
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await GetByIdCompiled(_context,id);
        }

        public async Task<T> GetFirstAsync()
        {
            return await GetFirstCompiled(_context);
        }

        public async Task<T> GetFirstByExpressionAsync(Expression<Func<T, bool>> expression)
        {
            return await GetFirstByExpressionCompiled(_context,expression);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> expression)
        {
            return Entity.Where(expression);
        }
    }
}
