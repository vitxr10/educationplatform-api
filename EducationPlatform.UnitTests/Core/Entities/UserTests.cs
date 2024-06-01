using EducationPlatform.Core.Entities;
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
        public void UserExists_Executed_UpdateUser()
        {
            // Arrange
            var user = new User();
            var email = "user@email.com";
            var phone = "1140028922";

            // Act
            user.Update(email, phone);

            // Assert
            Assert.Equal(email, user.Email);
            Assert.Equal(phone, user.Phone);
            Assert.NotNull(user.UpdatedAt);
        }
    }
}
