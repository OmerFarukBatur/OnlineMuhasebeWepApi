using MediatR;
using OnlineMuhasebeWepApi.Application.Services.AppServices;
using D = OnlineMuhasebeWepApi.Domain.AppEntities;

namespace OnlineMuhasebeWepApi.Application.Features.AppFeatures.Commands.Company.CreateCompany
{
    public sealed class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommandRequest, CreateCompanyCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public CreateCompanyCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<CreateCompanyCommandResponse> Handle(CreateCompanyCommandRequest request, CancellationToken cancellationToken)
        {
            D.Company company = await _companyService.GetCompanyByName(request.Name);
            if (company != null)
            {
                throw new Exception("Bu şirket adı daha önce kullanılmış!");
            }
            else
            {
                await _companyService.CreateCompany(request);
                return new();
            }
            
        }
    }
}
