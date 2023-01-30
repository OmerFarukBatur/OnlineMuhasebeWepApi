using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeWepApi.Domain;
using OnlineMuhasebeWepApi.Domain.AppEntities;
using OnlineMuhasebeWepApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Persistance
{
    public sealed class ContextService : IContextService
    {
        private readonly AppDbContext _appContext;

        public ContextService(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public DbContext CreateDbContext(string companyId)
        {
            Company company = _appContext.Set<Company>().Find(companyId);
            return new CompanyDbContext(company);
        }
    }
}
