using AutoMapper;
using OnlineMuhasebeWepApi.Application.Features.CompanyFeatures.Commands.UCOA.CreateUCOA;
using OnlineMuhasebeWepApi.Application.Services.CompanyServices;
using OnlineMuhasebeWepApi.Domain;
using OnlineMuhasebeWepApi.Domain.CompanyEntities;
using OnlineMuhasebeWepApi.Domain.Repositories.UCOARepository;
using OnlineMuhasebeWepApi.Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMuhasebeWepApi.Persistance.Services.CompanyServices
{
    public sealed class UCOAService : IUCOAService
    {
        private readonly IUCOAWriteRepository _uCOAWriteRepository;
        private readonly IContextService _contextService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private CompanyDbContext _context;


        public UCOAService(IUCOAWriteRepository uCOAWriteRepository, IUnitOfWork unitOfWork, IContextService contextService, IMapper mapper)
        {
            _uCOAWriteRepository = uCOAWriteRepository;
            _unitOfWork = unitOfWork;
            _contextService = contextService;
            _mapper = mapper;
        }

        public async Task CreateUCOAAsync(CreateUCOACommandRequest request)
        {
            _context = (CompanyDbContext)_contextService.CreateDbContext(request.CompanyId);
            _uCOAWriteRepository.SetDbContextInstance(_context);
            _unitOfWork.SetDbContextInstance(_context);

            UCOA uCOA = _mapper.Map<UCOA>(request);
            uCOA.Id = Guid.NewGuid().ToString();

            await _uCOAWriteRepository.AddAsync(uCOA);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
