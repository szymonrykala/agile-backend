using AgileApp.Models;
using Xunit;

namespace AgileUnitTests.ModelsTests
{
    public class AuthorizeUserResultTests
    {
        [Fact]
        public void AuthorizeUserResult_NotExist_ShouldReturnCorrectResult()
        {
            // Act
            var result = AuthorizeUserResult.NotExist();

            // Assert
            Assert.False(result.Exists);
            Assert.Null(result.Hash);
        }

        [Fact]
        public void AuthorizeUserResult_Exist_ShouldReturnCorrectResult()
        {
            // Arrange
            var hash = "testhash";

            // Act
            var result = AuthorizeUserResult.Exist(hash);

            // Assert
            Assert.True(result.Exists);
            Assert.Equal(hash, result.Hash);
        }
    }
}
