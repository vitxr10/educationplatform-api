using EducationPlatform.Application.Exceptions;
using EducationPlatform.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.Application.Commands.SubscriptionCommands
{
    public class UpdateSubscriptionCommandHandler : IRequestHandler<UpdateSubscriptionCommand>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public UpdateSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task Handle(UpdateSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(request.Id);

            if (subscription == null)
                throw new NotFoundException("Assinatura");

            subscription.Update(request.Name);

            await _subscriptionRepository.SaveAsync();
        }
    }
}
