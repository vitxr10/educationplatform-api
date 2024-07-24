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
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, ServiceResult>
    {
        private readonly ICourseRepository _courseRepository;
        public UpdateCourseCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<ServiceResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = await _courseRepository.GetByIdAsync(request.Id);

            if (course == null)
                return ServiceResult.Error("Curso não encontrado.", ErrorTypeEnum.NotFound);

            course.Update(request.Name, request.Description, request.Cover);

            await _courseRepository.SaveAsync();

            return ServiceResult.Success();
        }
    }
}
