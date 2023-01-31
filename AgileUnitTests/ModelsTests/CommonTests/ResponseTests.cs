using AgileApp.Models.Common;
using Xunit;

namespace AgileUnitTests.ModelsTests.CommonTests
{
    public class ResponseTests
    {
        [Fact]
        public void ShouldReturnCorrectValue_WhenResponseIsSuccessful()
        {
            var response = Response.Succeeded();

            Assert.True(response.IsSuccess);
        }

        [Fact]
        public void ShouldReturnCorrectValue_WhenResponseFails()
        {
            var response = Response.Failed();

            Assert.False(response.IsSuccess);
        }
    }

    public class ResponseWithDataTests
    {
        [Fact]
        public void ShouldReturnCorrectValues_WhenResponseIsSuccessful()
        {
            var data = "Test data";
            var response = Response<string>.Succeeded(data);

            Assert.True(response.IsSuccess);
            Assert.Equal(data, response.Data);
        }

        [Fact]
        public void ShouldReturnCorrectValues_WhenResponseFails()
        {
            var response = Response<string>.Failed();

            Assert.False(response.IsSuccess);
            Assert.Null(response.Data);
        }
    }
}
