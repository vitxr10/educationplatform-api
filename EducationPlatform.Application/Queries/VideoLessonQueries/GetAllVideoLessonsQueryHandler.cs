using AutoMapper;
using EducationPlatform.Application.Common;
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
    public class GetAllVideoLessonsQueryHandler : IRequestHandler<GetAllVideoLessonsQuery, ServiceResult<List<VideoLessonViewModel>>>
    {
        private readonly IVideoLessonRepository _videoLessonRepository;
        private readonly IMapper _mapper;
        public GetAllVideoLessonsQueryHandler(IVideoLessonRepository videoLessonRepository, IMapper mapper)
        {
            _videoLessonRepository = videoLessonRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<VideoLessonViewModel>>> Handle(GetAllVideoLessonsQuery request, CancellationToken cancellationToken)
        {
            var videoLessons = await _videoLessonRepository.GetAllAsync();

            var videoLessonsViewModel = _mapper.Map<List<VideoLessonViewModel>>(videoLessons);

            return ServiceResult<List<VideoLessonViewModel>>.Success(videoLessonsViewModel);
        }
    }
}
