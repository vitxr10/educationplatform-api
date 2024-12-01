using EducationPlatform.Application.Common;
using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.CourseCommands
{
    public class GenerateCourseCertificateCommandHandler : IRequestHandler<GenerateCourseCertificateCommand, ServiceResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IUserLessonsCompletedRepository _userLessonsCompletedRepository;
        private readonly IPdfService _pdfService;
        private const decimal minimunCourseProgress = 0.70M;
        public GenerateCourseCertificateCommandHandler(IUserRepository userRepository, ICourseRepository courseRepository, IUserLessonsCompletedRepository userLessonsCompletedRepository, IPdfService pdfService)
        {
            _userRepository = userRepository;
            _courseRepository = courseRepository;
            _userLessonsCompletedRepository = userLessonsCompletedRepository;
            _pdfService = pdfService;
        }

        public async Task<ServiceResult> Handle(GenerateCourseCertificateCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);
            if (user == null)
                return ServiceResult.Error("Aluno não encontrado", ErrorTypeEnum.NotFound);

            var course = await _courseRepository.GetByIdAsync(request.CourseId);
            if (course == null)
                return ServiceResult.Error("Curso não encontrado", ErrorTypeEnum.NotFound);

            var userCourseProgress = await _userLessonsCompletedRepository.GetUserCourseProgressAsync(request.UserId, request.CourseId);

            if (userCourseProgress <  minimunCourseProgress)
                return ServiceResult.Error("Para retirar o certificado o aluno deve ter completado 70% do curso", ErrorTypeEnum.Failure);

            _pdfService.CreatePdf(user.FullName, course.Name);

            return ServiceResult.Success();
        }

    }
}
