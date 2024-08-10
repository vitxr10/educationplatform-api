using EducationPlatform.Application.Commands.SubscriptionCommands;
using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.UnitTests.Core.Entities
{
    public class SubscriptionTests
    {
        [Fact]
        public async void SubscriptionExists_Executed_UpdateSubscription()
        {
            // Arrange
            var subscription = new Subscription("Assinatura teste", 365);
            var name = "Nome atualizado";

            var subscriptionRepositoryMock = Substitute.For<ISubscriptionRepository>();
            subscriptionRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(subscription);

            var updateSubscriptionCommand = new UpdateSubscriptionCommand(name);
            var updateSubscriptionCommandHandler = new UpdateSubscriptionCommandHandler(subscriptionRepositoryMock);

            // Act
            await updateSubscriptionCommandHandler.Handle(updateSubscriptionCommand, new CancellationToken());

            // Assert
            Assert.Equal(name, subscription.Name);
            Assert.NotNull(subscription.UpdatedAt);
            await subscriptionRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await subscriptionRepositoryMock.Received(1).SaveAsync();
        }

        [Fact]
        public async void SubscriptionExists_Executed_DeleteSubscription()
        {
            // Arrange
            var subscription = new Subscription("Assinatura teste", 365);

            var subscriptionRepositoryMock = Substitute.For<ISubscriptionRepository>();
            subscriptionRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(subscription);

            var deleteSubscriptionCommand = new DeleteSubscriptionCommand();
            var deleteSubscriptionCommandHandler = new DeleteSubscriptionCommandHandler(subscriptionRepositoryMock);

            // Act
            await deleteSubscriptionCommandHandler.Handle(deleteSubscriptionCommand, new CancellationToken());

            // Assert
            Assert.False(subscription.Active);
            Assert.NotNull(subscription.InactivatedAt);
            await subscriptionRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await subscriptionRepositoryMock.Received(1).SaveAsync();
        }
    }
}
