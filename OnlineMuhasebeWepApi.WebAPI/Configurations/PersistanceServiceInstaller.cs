using Microsoft.EntityFrameworkCore;
using OnlineMuhasebeWepApi.Domain.AppEntities.Identity;
using OnlineMuhasebeWepApi.Persistance;
using OnlineMuhasebeWepApi.Persistance.Context;

namespace OnlineMuhasebeWepApi.WebAPI.Configurations
{
    public class PersistanceServiceInstaller : IServiceInstaller
    {
        private const string SectionName = "SqlServer";
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(SectionName)));

            services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AppDbContext>();

            services.AddAutoMapper(typeof(AssemblyReference).Assembly);
        }
    }
}
