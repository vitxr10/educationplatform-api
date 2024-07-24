using EducationPlatform.Application.Common;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.CourseCommands
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, ServiceResult>
    {
        private readonly ICourseRepository _courseRepository;
        public DeleteCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ServiceResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id);

            if (course == null)
                return ServiceResult.Error("Curso não encontrado.", ErrorTypeEnum.NotFound);

            course.Delete();

            await _courseRepository.SaveAsync();

            return ServiceResult.Success();
        }
    }
}
