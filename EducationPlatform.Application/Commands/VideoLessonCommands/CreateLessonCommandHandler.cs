using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.VideoLessonCommands
{
    public class CreateLessonCommandHandler : IRequestHandler<CreateLessonCommand, int>
    {
        private readonly IVideoLessonService _videoLessonService;
        private readonly IVideoLessonRepository _videoLessonRepository;
        public CreateLessonCommandHandler(IVideoLessonService videoLessonService, IVideoLessonRepository videoLessonRepository)
        {
            _videoLessonService = videoLessonService;
            _videoLessonRepository = videoLessonRepository;
        }

        public async Task<int> Handle(CreateLessonCommand request, CancellationToken cancellationToken)
        {
            var vimeoVideoDTO = await _videoLessonService.UploadVideo(request.Video);

            var videoLesson = new VideoLesson(vimeoVideoDTO.ClipId, request.Name, request.Description, vimeoVideoDTO.ClipUri, vimeoVideoDTO.Duration);

            return await _videoLessonRepository.CreateAsync(videoLesson);
        }
    }
}
