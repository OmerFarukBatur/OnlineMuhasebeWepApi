using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeWepApi.Application.Features.AppFeatures.Commands.Company.CreateCompany;
using OnlineMuhasebeWepApi.Application.Services.AppServices;
using OnlineMuhasebeWepApi.Domain.AppEntities;
using OnlineMuhasebeWepApi.Persistance.Context;

namespace OnlineMuhasebeWepApi.Persistance.Services.AppServices
{
    public sealed class CompanyService : ICompanyService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        private static readonly Func<AppDbContext, string, Task<Company?>> GetCompanyByNameCompiled = EF.CompileAsyncQuery((AppDbContext context, string name) => context.Set<Company>().FirstOrDefault(p => p.Name == name));

        public CompanyService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateCompany(CreateCompanyCommandRequest request)
        {
            Company company = _mapper.Map<Company>(request);
            company.Id = Guid.NewGuid().ToString();
            await _context.Set<Company>().AddAsync(company);
            await _context.SaveChangesAsync();
        }

        public async Task<Company?> GetCompanyByName(string name)
        {
            return await GetCompanyByNameCompiled(_context,name);
        }

        public async Task MigarteCompanyDatabase()
        {
            var companies = await _context.Set<Company>().ToListAsync();
            foreach (var company in companies)
            {
                var db = new CompanyDbContext(company);
                db.Database.Migrate();
            }
        }
    }
}
