using MediatR;
using OnlineMuhasebeWepApi.Application.Services.CompanyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Application.Features.CompanyFeatures.Commands.UCOA.CreateUCOA
{
    public sealed class CreateUCOACommandHandler : IRequestHandler<CreateUCOACommandRequest, CreateUCOACommandResponse>
    {
        private readonly IUCOAService _uCOAService;

        public CreateUCOACommandHandler(IUCOAService uCOAService)
        {
            _uCOAService = uCOAService;
        }

        public async Task<CreateUCOACommandResponse> Handle(CreateUCOACommandRequest request, CancellationToken cancellationToken)
        {
            await _uCOAService.CreateUCOAAsync(request);
            return new();
        }
    }
}
