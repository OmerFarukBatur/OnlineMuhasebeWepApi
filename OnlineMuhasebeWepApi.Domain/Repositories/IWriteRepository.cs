using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeWepApi.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Domain.Repositories
{
    public interface IWriteRepository<T>: IRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entities);
        Task RemoveByIdAsync(string id);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);  
    }
}
