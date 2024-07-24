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

namespace EducationPlatform.Application.Queries.CourseQueries
{
    public class GetAllCoursesQueryHandler : IRequestHandler<GetAllCoursesQuery, ServiceResult<List<CourseViewModel>>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public GetAllCoursesQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<CourseViewModel>>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var courses = await _courseRepository.GetAllAsync(request.StringQuery);

            var coursesViewModel = _mapper.Map<List<CourseViewModel>>(courses);

            return ServiceResult<List<CourseViewModel>>.Success(coursesViewModel);
        }
    }
}
