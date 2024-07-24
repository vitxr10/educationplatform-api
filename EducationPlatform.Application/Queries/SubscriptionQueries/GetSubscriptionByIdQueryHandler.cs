using AutoMapper;
using EducationPlatform.Application.Common;
using EducationPlatform.Application.Exceptions;
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
    public class GetSubscriptionByIdQueryHandler : IRequestHandler<GetSubscriptionByIdQuery, ServiceResult<SubscriptionDetailsViewModel>>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;
        public GetSubscriptionByIdQueryHandler(ISubscriptionRepository subscriptionRepository, IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResult<SubscriptionDetailsViewModel>> Handle(GetSubscriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(request.Id);

            if (subscription == null)
                return ServiceResult<SubscriptionDetailsViewModel>.Error("Assinatura não encontrada.", ErrorTypeEnum.NotFound);

            var subscriptionDetailsViewModel = _mapper.Map<SubscriptionDetailsViewModel>(subscription);

            return ServiceResult<SubscriptionDetailsViewModel>.Success(subscriptionDetailsViewModel);
        }
    }
}
