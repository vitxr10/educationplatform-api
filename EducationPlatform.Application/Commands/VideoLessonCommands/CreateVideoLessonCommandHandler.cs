using EducationPlatform.Application.Common;
using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using EducationPlatform.Infrastructure.Persistence.Repositories;
using EducationPlatform.Infrastructure.Services.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.VideoLessonCommands
{
    public class CreateVideoLessonCommandHandler : IRequestHandler<CreateVideoLessonCommand, ServiceResult<int>>
    {
        private readonly IVideoLessonService _videoLessonService;
        private readonly IVideoLessonRepository _videoLessonRepository;
        private readonly IModuleRepository _moduleRepository;
        public CreateVideoLessonCommandHandler(IVideoLessonService videoLessonService, IVideoLessonRepository videoLessonRepository, IModuleRepository moduleRepository)
        {
            _videoLessonService = videoLessonService;
            _videoLessonRepository = videoLessonRepository;
            _moduleRepository = moduleRepository;
        }

        public async Task<ServiceResult<int>> Handle(CreateVideoLessonCommand request, CancellationToken cancellationToken)
        {
            var module = await _moduleRepository.GetByIdAsync(request.ModuleId);

            if (module == null)
                return ServiceResult<int>.Error("Módulo não encontrado.", ErrorTypeEnum.NotFound);

            var vimeoVideoDTO = await _videoLessonService.GetVideoInfo(request.Video);

            var videoLesson = new VideoLesson(vimeoVideoDTO.ClipId, request.Name, request.Description, vimeoVideoDTO.ClipUri, vimeoVideoDTO.Duration, request.ModuleId);

            var id = await _videoLessonRepository.CreateAsync(videoLesson);

            return ServiceResult<int>.Success(id);
        }
    }
}
