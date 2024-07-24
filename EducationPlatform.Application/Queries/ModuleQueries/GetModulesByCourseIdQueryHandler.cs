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
    public class GetModulesByCourseIdQueryHandler : IRequestHandler<GetModulesByCourseIdQuery, ServiceResult<List<ModuleViewModel>>>
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public GetModulesByCourseIdQueryHandler(IModuleRepository moduleRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<ModuleViewModel>>> Handle(GetModulesByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id);

            if (course == null)
                return ServiceResult<List<ModuleViewModel>>.Error("Curso não encontrado.", ErrorTypeEnum.NotFound);

            var modules = await _moduleRepository.GetByCourseIdAsync(request.Id);

            var modulesViewModel = _mapper.Map<List<ModuleViewModel>>(modules);

            return ServiceResult<List<ModuleViewModel>>.Success(modulesViewModel);
        }
    }
}
