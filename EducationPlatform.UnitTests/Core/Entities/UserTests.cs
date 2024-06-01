using EducationPlatform.Application.Commands.UserCommands;
using EducationPlatform.Core.Entities;
using EducationPlatform.Core.Enums;
using EducationPlatform.Core.Repositories;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationPlatform.UnitTests.Core.Entities
{
    public class UserTests
    {
        [Fact]
        public async void UserExists_Executed_UpdateUser()
        {
            // Arrange
            var user = new User("Paulo Teste", "12345678901", "paulo@email.com", "123456", "11937433901", DateTime.Now);
            var email = "updated@email.com";
            var phone = "40028922";

            var userRepositoryMock = Substitute.For<IUserRepository>();
            userRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(user);

            var updateUserCommand = new UpdateUserCommand(email, phone);
            var updateUserCommandHandler = new UpdateUserCommandHandler(userRepositoryMock);

            // Act
            await updateUserCommandHandler.Handle(updateUserCommand, new CancellationToken());

            // Assert
            Assert.Equal(email, user.Email);
            Assert.Equal(phone, user.Phone);
            Assert.NotNull(user.UpdatedAt);
            await userRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await userRepositoryMock.Received(1).SaveAsync();
        }

        [Fact]
        public async void UserExists_Executed_DeleteUser()
        {
            // Arrange
            var user = new User("Paulo Teste", "12345678901", "paulo@email.com", "123456", "11937433901", DateTime.Now);
            var userSubscription = new UserSubscription(1, 1, SubscriptionStatusEnum.Active, DateTime.Now, DateTime.Now.AddDays(182));
            user.UserSubscription = userSubscription;

            var userRepositoryMock = Substitute.For<IUserRepository>();
            userRepositoryMock.GetByIdAsync(Arg.Any<int>()).Returns(user);

            var deleteUserCommand = new DeleteUserCommand();
            var deleteUserCommandHandler = new DeleteUserCommandHandler(userRepositoryMock);

            // Act
            await deleteUserCommandHandler.Handle(deleteUserCommand, new CancellationToken());

            // Assert
            Assert.False(user.Active);
            Assert.NotNull(user.InactivatedAt);
            Assert.Equal(SubscriptionStatusEnum.Disabled, userSubscription.Status);
            await userRepositoryMock.Received(1).GetByIdAsync(Arg.Any<int>());
            await userRepositoryMock.Received(1).SaveAsync();
        }
    }
}
