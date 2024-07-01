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
    public class DeleteSubscriptionCommandHandler : IRequestHandler<DeleteSubscriptionCommand>
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        public DeleteSubscriptionCommandHandler(ISubscriptionRepository subscriptionRepository)
        {
            _subscriptionRepository = subscriptionRepository;
        }

        public async Task Handle(DeleteSubscriptionCommand request, CancellationToken cancellationToken)
        {
            var subscription = await _subscriptionRepository.GetByIdAsync(request.Id);

            if (subscription == null)
                throw new NotFoundException("Assinatura");

            subscription.Delete();

            await _subscriptionRepository.SaveAsync();
        }
    }
}
