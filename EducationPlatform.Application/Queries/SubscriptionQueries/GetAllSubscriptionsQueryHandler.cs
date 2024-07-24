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

namespace EducationPlatform.Application.Queries.SubscriptionQueries
{
    public class GetAllSubscriptionsQueryHandler : IRequestHandler<GetAllSubscriptionsQuery, ServiceResult<List<SubscriptionViewModel>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        public GetAllSubscriptionsQueryHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<SubscriptionViewModel>>> Handle(GetAllSubscriptionsQuery request, CancellationToken cancellationToken)
        {
            var subscriptions = await _subscriptionRepository.GetAllAsync(request.StringQuery);

            var subscriptionsViewModel = _mapper.Map<List<SubscriptionViewModel>>(subscriptions);

            return ServiceResult<List<SubscriptionViewModel>>.Success(subscriptionsViewModel);
        }
    }
}
