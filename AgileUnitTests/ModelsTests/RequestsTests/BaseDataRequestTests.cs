using AgileApp.Models.Requests;
using Xunit;

namespace AgileUnitTests.ModelsTests.RequestsTests
{
    public class BaseDataRequestTests
    {
        [Fact]
        public void BaseDataRequest_ShouldHaveEmailProperty()
        {
            // Arrange
            var baseDataRequest = new BaseDataRequest();

            // Act
            baseDataRequest.Email = "email@example.com";

            // Assert
            Assert.Equal("email@example.com", baseDataRequest.Email);
        }

        [Fact]
        public void BaseDataRequest_ShouldReturnTrueForIsValid_WhenEmailIsNotNullOrWhiteSpaceAndMatchesEmailExpression()
        {
            // Arrange
            var baseDataRequest = new BaseDataRequest { Email = "email@example.com" };

            // Act
            var isValid = baseDataRequest.IsValid;

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void BaseDataRequest_ShouldReturnFalseForIsValid_WhenEmailIsNullOrWhiteSpace()
        {
            // Arrange
            var baseDataRequest = new BaseDataRequest();

            // Act
            var isValid = baseDataRequest.IsValid;

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void BaseDataRequest_ShouldReturnFalseForIsValid_WhenEmailDoesNotMatchEmailExpression()
        {
            // Arrange
            var baseDataRequest = new BaseDataRequest { Email = "invalidemail" };

            // Act
            var isValid = baseDataRequest.IsValid;

            // Assert
            Assert.False(isValid);
        }
    }
}
