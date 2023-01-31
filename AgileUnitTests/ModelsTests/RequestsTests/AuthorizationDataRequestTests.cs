using AgileApp.Models.Requests;
using Xunit;

namespace AgileUnitTests.ModelsTests.RequestsTests
{
    public class AuthorizationDataRequestTests
    {
        [Fact]
        public void AuthorizationDataRequest_ShouldHavePasswordProperty()
        {
            // Arrange
            var authorizationDataRequest = new AuthorizationDataRequest();

            // Act
            authorizationDataRequest.Password = "password";

            // Assert
            Assert.Equal("password", authorizationDataRequest.Password);
        }

        [Fact]
        public void AuthorizationDataRequest_ShouldHaveFirstNameProperty()
        {
            // Arrange
            var authorizationDataRequest = new AuthorizationDataRequest();

            // Act
            authorizationDataRequest.FirstName = "John";

            // Assert
            Assert.Equal("John", authorizationDataRequest.FirstName);
        }

        [Fact]
        public void AuthorizationDataRequest_ShouldHaveLastNameProperty()
        {
            // Arrange
            var authorizationDataRequest = new AuthorizationDataRequest();

            // Act
            authorizationDataRequest.LastName = "Doe";

            // Assert
            Assert.Equal("Doe", authorizationDataRequest.LastName);
        }

        [Fact]
        public void AuthorizationDataRequest_ShouldHaveRoleProperty()
        {

        }

        [Fact]
        public void AuthorizationDataRequest_ShouldReturnTrueForIsValid_WhenPasswordIsNotNullOrWhiteSpace()
        {
            // Arrange
            var authorizationDataRequest = new AuthorizationDataRequest { Password = "password" };

            // Act
            var isValid = authorizationDataRequest.IsValid;

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void AuthorizationDataRequest_ShouldReturnFalseForIsValid_WhenPasswordIsNullOrWhiteSpace()
        {
            // Arrange
            var authorizationDataRequest = new AuthorizationDataRequest();

            // Act
            var isValid = authorizationDataRequest.IsValid;

            // Assert
            Assert.False(isValid);
        }
    }
}
