using AgileApp.Models;
using Xunit;

namespace AgileUnitTests.ModelsTests
{
    public class UserResponseTests
    {
        [Fact]
        public void UserResponse_PropertiesHaveCorrectValues_ReturnTrue()
        {
            var response = new UserResponse
            {
                FirstName = "John",
                LastName = "Doe",
                Email = "johndoe@example.com"
            };

            Assert.Equal("John", response.FirstName);
            Assert.Equal("Doe", response.LastName);
            Assert.Equal("johndoe@example.com", response.Email);
        }
    }
}
