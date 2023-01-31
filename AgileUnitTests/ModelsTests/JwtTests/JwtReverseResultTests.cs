using AgileApp.Models.Jwt;
using System.Collections.Generic;
using System.Security.Claims;
using Xunit;

namespace AgileUnitTests.ModelsTests.JwtTests
{
    public class JwtReverseResultTests
    {
        [Fact]
        public void ShouldReturnCorrectValues_WhenResultIsInvalid()
        {
            var result = JwtReverseResult.Invalid();

            Assert.False(result.IsValid);
            Assert.Null(result.Claims);
        }

        [Fact]
        public void ShouldReturnCorrectValues_WhenResultIsValid()
        {
            var claims = new List<Claim>
            {
                new Claim("TestType", "TestValue")
            };

            var result = JwtReverseResult.Valid(claims);

            Assert.True(result.IsValid);
            Assert.Equal(claims, result.Claims);
        }
    }
}
