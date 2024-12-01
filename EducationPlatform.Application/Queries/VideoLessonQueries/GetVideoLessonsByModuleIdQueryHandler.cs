using AutoMapper;
using EducationPlatform.Application.Common;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.VideoLessonQueries
{
    public class GetVideoLessonsByModuleIdQueryHandler : IRequestHandler<GetVideoLessonsByModuleIdQuery, ServiceResult<List<VideoLessonDetailsViewModel>>>
    {
        private readonly IVideoLessonRepository _videoLessonRepository;
        private readonly IMapper _mapper;
        public GetVideoLessonsByModuleIdQueryHandler(IVideoLessonRepository videoLessonRepository, IMapper mapper)
        {
            _videoLessonRepository = videoLessonRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<VideoLessonDetailsViewModel>>> Handle(GetVideoLessonsByModuleIdQuery request, CancellationToken cancellationToken)
        {
            var videoLessons = await _videoLessonRepository.GetByModuleIdAsync(request.ModuleId);

            var videoLessonsDetailsViewModel = _mapper.Map<List<VideoLessonDetailsViewModel>>(videoLessons);

            return ServiceResult<List<VideoLessonDetailsViewModel>>.Success(videoLessonsDetailsViewModel);
        }
    }
}
