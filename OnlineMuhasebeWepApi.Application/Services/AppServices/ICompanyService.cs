using OnlineMuhasebeWepApi.Application.Features.AppFeatures.Commands.Company.CreateCompany;
using OnlineMuhasebeWepApi.Domain.AppEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Application.Services.AppServices
{
    public interface ICompanyService
    {
        Task CreateCompany(CreateCompanyCommandRequest request);
        Task<Company?> GetCompanyByName(string name);
        Task MigarteCompanyDatabase();
    }
}
