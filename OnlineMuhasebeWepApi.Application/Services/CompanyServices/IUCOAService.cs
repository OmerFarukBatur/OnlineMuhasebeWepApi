using OnlineMuhasebeWepApi.Application.Features.CompanyFeatures.Commands.UCOA.CreateUCOA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Application.Services.CompanyServices
{
    public interface IUCOAService
    {
        Task CreateUCOAAsync(CreateUCOACommandRequest request);
    }
}
