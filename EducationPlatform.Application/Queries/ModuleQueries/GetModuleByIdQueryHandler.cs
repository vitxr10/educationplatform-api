using AutoMapper;
using EducationPlatform.Application.Common;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.ModuleQueries
{
    public class GetModuleByIdQueryHandler : IRequestHandler<GetModuleByIdQuery, ServiceResult<ModuleDetailsViewModel>>
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;
        public GetModuleByIdQueryHandler(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<ModuleDetailsViewModel>> Handle(GetModuleByIdQuery request, CancellationToken cancellationToken)
        {
            var module = await _moduleRepository.GetByIdAsync(request.Id);

            if (module == null)
                return ServiceResult<ModuleDetailsViewModel>.Error("Módulo não encontrado.", ErrorTypeEnum.NotFound);

            var moduleDetailsViewModel = _mapper.Map<ModuleDetailsViewModel>(module);

            return ServiceResult<ModuleDetailsViewModel>.Success(moduleDetailsViewModel);
        }
    }
}
