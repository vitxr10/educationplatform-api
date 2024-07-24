using EducationPlatform.Application.Common;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.VideoLessonCommands
{
    public class DeleteVideoLessonCommandHandler : IRequestHandler<DeleteVideoLessonCommand, ServiceResult>
    {
        private readonly IVideoLessonRepository _videoLessonRepository;
        public DeleteVideoLessonCommandHandler(IVideoLessonRepository videoLessonRepository)
        {
            _videoLessonRepository = videoLessonRepository;
        }
        public async Task<ServiceResult> Handle(DeleteVideoLessonCommand request, CancellationToken cancellationToken)
        {
            var videoLesson = await _videoLessonRepository.GetByIdAsync(request.Id);

            if (videoLesson == null)
                return ServiceResult.Error("Videoaula não encontrada.", ErrorTypeEnum.NotFound);

            videoLesson.Delete();

            await _videoLessonRepository.SaveAsync();

            return ServiceResult.Success();
        }
    }
}
