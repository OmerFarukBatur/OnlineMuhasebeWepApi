using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Application.Features.CompanyFeatures.Commands.UCOA.CreateUCOA
{
    public sealed class CreateUCOACommandHandler : IRequestHandler<CreateUCOACommandRequest, CreateUCOACommandResponse>
    {
        public Task<CreateUCOACommandResponse> Handle(CreateUCOACommandRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
