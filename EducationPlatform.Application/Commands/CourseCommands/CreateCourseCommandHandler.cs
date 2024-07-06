﻿using AutoMapper;
using EducationPlatform.Application.Exceptions;
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
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, int>
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

        public async Task<int> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(request.SubscriptionId);

            if (subscription == null)
                throw new NotFoundException("Assinatura");

            var course = _mapper.Map<Course>(request);

            return await _courseRepository.CreateAsync(course);
        }
    }
}
