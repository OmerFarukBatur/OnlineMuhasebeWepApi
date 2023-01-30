using OnlineMuhasebeWepApi.Application.Services.AppServices;
using OnlineMuhasebeWepApi.Application.Services.CompanyServices;
using OnlineMuhasebeWepApi.Domain.Repositories.UCOARepository;
using OnlineMuhasebeWepApi.Domain;
using OnlineMuhasebeWepApi.Persistance.Repositories.UCOARepositories;
using OnlineMuhasebeWepApi.Persistance.Services.AppServices;
using OnlineMuhasebeWepApi.Persistance.Services.CompanyServices;
using OnlineMuhasebeWepApi.Persistance;

namespace OnlineMuhasebeWepApi.WebAPI.Configurations
{
    public class PersistanceDIServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            #region Context and UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContextService, ContextService>();
            #endregion

            #region Services
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUCOAService, UCOAService>();
            #endregion


            #region Repositories
            services.AddScoped<IUCOAReadRepository, UCOAReadRepositry>();
            services.AddScoped<IUCOAWriteRepository, UCOAWriteRepositry>();

            #endregion

        }
    }
}
