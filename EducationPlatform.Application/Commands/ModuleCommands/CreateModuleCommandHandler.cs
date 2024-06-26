﻿using AutoMapper;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.ModuleCommands
{
    public class CreateModuleCommandHandler : IRequestHandler<CreateModuleCommand, int>
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CreateModuleCommandHandler(IModuleRepository moduleRepository, ICourseRepository courseRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateModuleCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.CourseId);

            if (course == null)
                throw new NotFoundException("Curso não encontrado.");

            var module = _mapper.Map<Module>(request);

            return await _moduleRepository.CreateAsync(module);
        }
    }
}
