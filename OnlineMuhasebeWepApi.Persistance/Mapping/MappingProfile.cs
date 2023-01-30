using AutoMapper;
using OnlineMuhasebeWepApi.Application.Features.AppFeatures.Commands.Company.CreateCompany;
using OnlineMuhasebeWepApi.Application.Features.CompanyFeatures.Commands.UCOA.CreateUCOA;
using OnlineMuhasebeWepApi.Domain.AppEntities;
using OnlineMuhasebeWepApi.Domain.CompanyEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Persistance.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateCompanyCommandRequest,Company>().ReverseMap();
            CreateMap<CreateUCOACommandRequest,UCOA>().ReverseMap();
        }
    }
}
