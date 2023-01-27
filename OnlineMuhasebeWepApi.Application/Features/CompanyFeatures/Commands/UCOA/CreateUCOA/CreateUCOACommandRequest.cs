using MediatR;

namespace OnlineMuhasebeWepApi.Application.Features.CompanyFeatures.Commands.UCOA.CreateUCOA
{
    public sealed class CreateUCOACommandRequest : IRequest<CreateUCOACommandResponse>
    {
        public string CompanyId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public char Type { get; set; }

    }
}