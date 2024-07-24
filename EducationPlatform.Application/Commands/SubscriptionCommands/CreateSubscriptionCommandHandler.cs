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

namespace EducationPlatform.Application.Commands.SubscriptionCommands
{
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ServiceResult<int>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<int>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = _mapper.Map<Subscription>(request);

            var id = await _subscriptionRepository.CreateAsync(subscription);

            return ServiceResult<int>.Success(id);
        }
    }
}
