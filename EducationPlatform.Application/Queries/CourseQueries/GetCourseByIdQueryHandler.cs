﻿using AutoMapper;
using EducationPlatform.Application.Common;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.CourseQueries
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, ServiceResult<CourseDetailsViewModel>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public GetCourseByIdQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<CourseDetailsViewModel>> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id);

            if (course == null)
                return ServiceResult<CourseDetailsViewModel>.Error("Curso não encontrado.", ErrorTypeEnum.NotFound);

            var courseDetailsViewModel = _mapper.Map<CourseDetailsViewModel>(course);

            return ServiceResult<CourseDetailsViewModel>.Success(courseDetailsViewModel);
        }
    }
}
