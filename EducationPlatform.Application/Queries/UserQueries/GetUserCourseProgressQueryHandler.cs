using EducationPlatform.Application.Common;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.UserQueries
{
    public class GetUserCourseProgressQueryHandler : IRequestHandler<GetUserCourseProgressQuery, ServiceResult<decimal>>
    {
        private readonly IUserLessonsCompletedRepository _userLessonsCompletedRepository;
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        public GetUserCourseProgressQueryHandler(IUserLessonsCompletedRepository userLessonsCompletedRepository, IUserRepository userRepository, ICourseRepository courseRepository)
        {
            _userLessonsCompletedRepository = userLessonsCompletedRepository;
            _userRepository = userRepository;
            _courseRepository = courseRepository;
        }

        public async Task<ServiceResult<decimal>> Handle(GetUserCourseProgressQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
                return ServiceResult<decimal>.Error("Usuário não encontrado.", ErrorTypeEnum.NotFound);

            var course = await _courseRepository.GetByIdAsync(request.CourseId);

            if (course == null)
                return ServiceResult<decimal>.Error("Curso não encontrado.", ErrorTypeEnum.NotFound);

            var progress = await _userLessonsCompletedRepository.GetUserCourseProgressAsync(request.UserId, request.CourseId);

            return ServiceResult<decimal>.Success(progress);
        }
    }
}
