using MediatR;
using OnlineMuhasebeWepApi.Application;

namespace OnlineMuhasebeWepApi.WebAPI.Configurations
{
    public class ApplicationServicesInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(typeof(AssemblyReference).Assembly);
        }
    }
}
