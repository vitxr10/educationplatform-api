using AutoMapper;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.VideoLessonQueries
{
    public class GetVideoLessonByIdQueryHandler : IRequestHandler<GetVideoLessonByIdQuery, VideoLessonDetailsViewModel>
    {
        private readonly IVideoLessonRepository _videoLessonRepository;
        private readonly IMapper _mapper;
        public GetVideoLessonByIdQueryHandler(IVideoLessonRepository videoLessonRepository, IMapper mapper)
        {
            _videoLessonRepository = videoLessonRepository;
            _mapper = mapper;
        }
        public async Task<VideoLessonDetailsViewModel> Handle(GetVideoLessonByIdQuery request, CancellationToken cancellationToken)
        {
            var videoLesson = await _videoLessonRepository.GetByIdAsync(request.Id);

            if (videoLesson == null)
                throw new NotFoundException("Videoaula não encontrada.");

            var videoLessonDetailsViewModel = _mapper.Map<VideoLessonDetailsViewModel>(videoLesson);

            return videoLessonDetailsViewModel;
        }
    }
}
