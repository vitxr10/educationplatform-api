﻿using EducationPlatform.Application.Common;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.SubscriptionCommands
{
    public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand, ServiceResult>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public UpdateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task<ServiceResult> Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(request.Id);

            if (subscription == null)
                return ServiceResult.Error("Assinatura não encontrada.", ErrorTypeEnum.NotFound);

            subscription.Update(request.Name);

            await _subscriptionRepository.SaveAsync();

            return ServiceResult.Success();
        }
    }
}
