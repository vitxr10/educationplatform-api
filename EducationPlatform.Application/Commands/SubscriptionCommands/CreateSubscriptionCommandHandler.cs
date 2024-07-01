using AutoMapper;
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
    public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, int>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        public CreateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = _mapper.Map<Subscription>(request);

            return await _subscriptionRepository.CreateAsync(subscription);
        }
    }
}
