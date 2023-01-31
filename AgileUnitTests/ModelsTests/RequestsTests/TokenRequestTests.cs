using AgileApp.Models.Requests;
using AgileApp.Utils;
using Xunit;

namespace AgileUnitTests.ModelsTests.RequestsTests
{
    public class TokenRequestTests
    {
        [Fact]
        public void IsValid_ReturnsFalse_WhenTokenIsNullOrWhiteSpace()
        {
            var request = new TokenRequest
            {
                Email = "test@email.com",
                Token = string.Empty
            };

            Assert.False(request.IsValid);
        }

        [Fact]
        public void IsValid_ReturnsFalse_WhenTokenLengthIsDifferentThanAppSettingsTokenLength()
        {
            var request = new TokenRequest
            {
                Email = "test@email.com",
                Token = "token"
            };

            Assert.False(request.IsValid);
        }

        [Fact]
        public void IsValid_ReturnsTrue_WhenTokenIsNotNullOrWhiteSpaceAndLengthIsAppSettingsTokenLength()
        {
            var request = new TokenRequest
            {
                Email = "test@email.com",
                Token = new string('*', AppSettings.TokenLength)
            };

            Assert.True(request.IsValid);
        }
    }
}
