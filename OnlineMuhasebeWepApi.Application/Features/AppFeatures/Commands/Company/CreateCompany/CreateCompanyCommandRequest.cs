using MediatR;

namespace OnlineMuhasebeWepApi.Application.Features.AppFeatures.Commands.Company.CreateCompany
{
    public sealed class CreateCompanyCommandRequest : IRequest<CreateCompanyCommandResponse>
    {
        public string Name { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}