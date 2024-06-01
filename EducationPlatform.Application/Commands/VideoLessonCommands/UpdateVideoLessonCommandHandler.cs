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
    public class UpdateVideoLessonCommandHandler : IRequestHandler<UpdateVideoLessonCommand>
    {
        private readonly IVideoLessonRepository _videoLessonRepository;
        public UpdateVideoLessonCommandHandler(IVideoLessonRepository videoLessonRepository)
        {
            _videoLessonRepository = videoLessonRepository;
        }

        public async Task Handle(UpdateVideoLessonCommand request, CancellationToken cancellationToken)
        {
            var videoLesson = await _videoLessonRepository.GetByIdAsync(request.Id);

            if (videoLesson == null)
                throw new NotFoundException("Videoaula não encontrada.");

            videoLesson.Update(request.Name, request.Description);

            await _videoLessonRepository.SaveAsync();
        }
    }
}
