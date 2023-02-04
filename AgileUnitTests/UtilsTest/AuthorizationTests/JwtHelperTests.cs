using AgileApp.Utils.Authorization;
using System.Linq;
using System.Security.Claims;
using Xunit;

namespace AgileUnitTests.UtilsTest.AuthorizationTests
{
    public class JwtHelperTests
    {
        private readonly IJwtHelper _jwtHelper;

        public JwtHelperTests()
        {
            // Arrange
            var secretKey = "secret-key";
            var issuer = "test-issuer";
        }

        [Fact]
        public void GenerateTokenFromLoginData_ReturnsValidJwt()
        {
            // Act
            var email = "test@example.com";
            var hash = "abc123";
            var token = _jwtHelper.GenerateTokenFromLoginData(email, hash);

            // Assert
            var result = _jwtHelper.ReverseTokenContent(token);
            Assert.True(result.IsValid);

            var claims = result.Claims;
            var emailClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);
            Assert.NotNull(emailClaim);
            Assert.Equal(email, emailClaim.Value);

            var hashClaim = claims.FirstOrDefault(c => c.Type == ClaimTypes.Hash);
            Assert.NotNull(hashClaim);
            Assert.Equal(hash, hashClaim.Value);
        }
    }
}
