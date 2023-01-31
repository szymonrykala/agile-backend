using AgileApp.Enums;
using Xunit;

namespace AgileUnitTests.EnumsTests
{
    public class TokenStatusTests
    {
        [Fact]
        public void ShouldReturnCorrectValue_WhenTokenIsNotExists()
        {
            var tokenStatus = TokenStatus.NotExists;

            Assert.Equal(TokenStatus.NotExists, tokenStatus);
        }

        [Fact]
        public void ShouldReturnCorrectValue_WhenTokenIsExpired()
        {
            var tokenStatus = TokenStatus.Expired;

            Assert.Equal(TokenStatus.Expired, tokenStatus);
        }

        [Fact]
        public void ShouldReturnCorrectValue_WhenTokenIsValid()
        {
            var tokenStatus = TokenStatus.Valid;

            Assert.Equal(TokenStatus.Valid, tokenStatus);
        }
    }
}
