using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnlineMuhasebeWepApi.Application.Features.AppFeatures.Commands.Company.CreateCompany;
using OnlineMuhasebeWepApi.Application.Features.AppFeatures.Commands.Company.MigrateCompanyDatabase;
using OnlineMuhasebeWepApi.Presentation.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Presentation.Controller
{
    public class CompaniesController : ApiController
    {
        public CompaniesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> CreateCompany(CreateCompanyCommandRequest createCompanyCommandRequest)
        {
            CreateCompanyCommandResponse response = await _mediator.Send(createCompanyCommandRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> MigrateCompanyDatabase()
        {
            MigrateCompanyDatabaseCommandRequest migrateCompanyDatabaseCommandRequest = new();
            MigrateCompanyDatabaseCommandResponse response = await _mediator.Send(migrateCompanyDatabaseCommandRequest);
            return Ok(response);
        }
    }
}
