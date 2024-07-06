using AutoMapper;
using EducationPlatform.Application.ViewModels;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Queries.SubscriptionQueries
{
    public class GetAllSubscriptionsByUserIdQueryHandler : IRequestHandler<GetAllSubscriptionsByUserIdQuery, List<SubscriptionViewModel>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        public GetAllSubscriptionsByUserIdQueryHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<List<SubscriptionViewModel>> Handle(GetAllSubscriptionsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.GetAllByUserIdAsync(request.UserId);

            var subscriptionsViewModel = _mapper.Map<List<SubscriptionViewModel>>(subscriptions);

            return subscriptionsViewModel;
        }
    }
}
