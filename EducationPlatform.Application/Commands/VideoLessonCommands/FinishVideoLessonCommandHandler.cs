using AutoMapper;
using EducationPlatform.Application.Common;
using EducationPlatform.Application.Exceptions;
using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.VideoLessonCommands
{
    public class FinishVideoLessonCommandHandler : IRequestHandler<FinishVideoLessonCommand, ServiceResult>
    {
        private readonly IVideoLessonRepository _videoLessonRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserLessonsCompletedRepository _userLessonsCompletedRepository;
        private readonly IMapper _mapper;
        public FinishVideoLessonCommandHandler(IVideoLessonRepository videoLessonRepository, IUserRepository userRepository, IUserLessonsCompletedRepository userLessonsCompletedRepository, IMapper mapper)
        {
            _videoLessonRepository = videoLessonRepository;
            _userRepository = userRepository;
            _userLessonsCompletedRepository = userLessonsCompletedRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult> Handle(FinishVideoLessonCommand request, CancellationToken cancellationToken)
        {
            var videoLesson = await _videoLessonRepository.GetByIdAsync(request.VideoLessonId);

            if (videoLesson == null)
                return ServiceResult.Error("Videoaula não encontrada.", ErrorTypeEnum.NotFound);

            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
                return ServiceResult.Error("Usuário não encontrado.", ErrorTypeEnum.NotFound);

            var userLessonsCompleted = _mapper.Map<UserLessonsCompleted>(request);
            await _userLessonsCompletedRepository.CreateAsync(userLessonsCompleted);

            return ServiceResult.Success();
        }
    }
}
