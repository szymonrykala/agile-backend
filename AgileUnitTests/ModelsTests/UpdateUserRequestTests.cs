using AgileApp.Models;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace AgileUnitTests.ModelsTests
{
    public class UpdateUserRequestTests
    {
        [Fact]
        public void Id_ShouldBeRequired()
        {
            // Arrange
            var propertyInfo = typeof(UpdateUserRequest)
                .GetProperty(nameof(UpdateUserRequest.Id));

            // Act
            var result = propertyInfo
                .GetCustomAttributes(false)
                .OfType<RequiredAttribute>()
                .Any();

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData("Email")]
        [InlineData("FirstName")]
        [InlineData("LastName")]
        [InlineData("Password")]
        [InlineData("Role")]
        public void Properties_ShouldNotBeRequired(string propertyName)
        {
            // Arrange
            var propertyInfo = typeof(UpdateUserRequest)
                .GetProperty(propertyName);

            // Act
            var result = propertyInfo
                .GetCustomAttributes(false)
                .OfType<RequiredAttribute>()
                .Any();

            // Assert
            Assert.False(result);
        }
    }
}
