using AutoMapper;
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
    public class GetModulesByCourseIdQueryHandler : IRequestHandler<GetModulesByCourseIdQuery, List<ModuleViewModel>>
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;
        public GetModulesByCourseIdQueryHandler(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        public async Task<List<ModuleViewModel>> Handle(GetModulesByCourseIdQuery request, CancellationToken cancellationToken)
        {
            var modules = await _moduleRepository.GetByCourseIdAsync(request.Id);

            var modulesViewModel = _mapper.Map<List<ModuleViewModel>>(modules);

            return modulesViewModel;
        }
    }
}
