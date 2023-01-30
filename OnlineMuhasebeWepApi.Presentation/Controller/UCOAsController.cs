using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeWepApi.Application.Features.CompanyFeatures.Commands.UCOA.CreateUCOA;
using OnlineMuhasebeWepApi.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Presentation.Controller
{
    public sealed class UCOAsController : ApiController
    {
        public UCOAsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUCOA(CreateUCOACommandRequest createUCOACommandRequest)
        {
            CreateUCOACommandResponse response = await _mediator.Send(createUCOACommandRequest);  
            return Ok(response);
        }
    }
}
