using AgileApp.Utils;
using Xunit;

namespace AgileUnitTests.UtilsTest
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("test", "new", "new")]
        [InlineData("test", "", "test")]
        [InlineData("test", null, "test")]
        [InlineData("test", "test", "test")]
        public void PropertyStringCompare_ReturnsCorrectString(string original, string newProperty, string expected)
        {
            var result = original.PropertyStringCompare(newProperty);

            Assert.Equal(expected, result);
        }
    }
}
