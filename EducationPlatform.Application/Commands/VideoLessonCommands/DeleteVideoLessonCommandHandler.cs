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
    public class DeleteVideoLessonCommandHandler : IRequestHandler<DeleteVideoLessonCommand>
    {
        private readonly IVideoLessonRepository _videoLessonRepository;
        public DeleteVideoLessonCommandHandler(IVideoLessonRepository videoLessonRepository)
        {
            _videoLessonRepository = videoLessonRepository;
        }
        public async Task Handle(DeleteVideoLessonCommand request, CancellationToken cancellationToken)
        {
            var videoLesson = await _videoLessonRepository.GetByIdAsync(request.Id);

            if (videoLesson == null)
                throw new NotFoundException("Videoaula não encontrada.");

            videoLesson.Delete();

            await _videoLessonRepository.SaveAsync();
        }
    }
}
