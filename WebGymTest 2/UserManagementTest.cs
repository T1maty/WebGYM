using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebGymTest_2
{
    public class UserManagementTest
    {
        [Fact]
        public void Add_CreateUser()
        {
            var userManagement = new UserManagement();

            userManagement.Add(new(
               "Viacheslav","Boiko"));

            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.NotNull(savedUser);
            Assert.Equal("Viacheslav", savedUser.FirstName);
            Assert.Equal("Boiko", savedUser.LastName);
            Assert.NotEmpty(savedUser.Phone);
            Assert.False(savedUser.VerifiedEmail);
        }
        [Fact]
        public void Verify_VerifyEmailAddress()
        {
            var userManagement, Add(new(
                "Viacheslav", "Boiko"));
            var firstUser = userManagement.AllUsers.ToList().First();
            userManagement.VerifyEmail(firstUser.Id);

            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.True(savedUser.VerifiedEmail);
        }
        [Fact]
        public void Update_UpdateMobileNumber()
        {
            // Arrange
            var userManagement = new UserManagement();

            // Act
            userManagement.Add(new(
                    "Mohamad", "Lawand"
            ));

            var firstUser = userManagement.AllUsers.ToList().First();
            firstUser.Phone = "+380951746365";
            userManagement.UpdatePhone(firstUser);

            // Assert
            var savedUser = Assert.Single(userManagement.AllUsers);
            Assert.Equal("+380951746365", savedUser.Phone);
        }
    }
}
