using MediatR;
using OnlineMuhasebeWepApi.Application.Services.AppServices;

namespace OnlineMuhasebeWepApi.Application.Features.AppFeatures.Commands.Company.MigrateCompanyDatabase
{
    public sealed class MigrateCompanyDatabaseCommandHandler : IRequestHandler<MigrateCompanyDatabaseCommandRequest, MigrateCompanyDatabaseCommandResponse>
    {
        private readonly ICompanyService _companyService;

        public MigrateCompanyDatabaseCommandHandler(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public async Task<MigrateCompanyDatabaseCommandResponse> Handle(MigrateCompanyDatabaseCommandRequest request, CancellationToken cancellationToken)
        {
            await _companyService.MigarteCompanyDatabase();
            return new();
        }
    }
}
