using AutoMapper;
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
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, ServiceResult<int>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        public CreateCourseCommandHandler(ICourseRepository courseRepository, ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<int>> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(request.SubscriptionId);

            if (subscription == null)
                return ServiceResult<int>.Error("Assinatura não encontrada.", ErrorTypeEnum.NotFound);

            var course = _mapper.Map<Course>(request);

            var id = await _courseRepository.CreateAsync(course);

            return ServiceResult<int>.Success(id);
        }
    }
}
