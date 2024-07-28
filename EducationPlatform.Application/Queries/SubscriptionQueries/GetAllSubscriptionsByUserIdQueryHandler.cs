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
    public class GetAllSubscriptionsByUserIdQueryHandler : IRequestHandler<GetAllSubscriptionsByUserIdQuery, ServiceResult<List<SubscriptionViewModel>>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetAllSubscriptionsByUserIdQueryHandler(ISubscriptionRepository subscriptionRepository, IUserRepository userRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<List<SubscriptionViewModel>>> Handle(GetAllSubscriptionsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.UserId);

            if (user == null)
                return ServiceResult<List<SubscriptionViewModel>>.Error("Usuário não encontrado.", ErrorTypeEnum.NotFound);

            var subscriptions = await _subscriptionRepository.GetAllByUserIdAsync(request.UserId);

            var subscriptionsViewModel = _mapper.Map<List<SubscriptionViewModel>>(subscriptions);

            return ServiceResult<List<SubscriptionViewModel>>.Success(subscriptionsViewModel);
        }
    }
}
