using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileApp.Models;
using Xunit;

namespace AgileUnitTests.ModelsTests
{
    public class ErrorViewModelTests
    {
        [Theory]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("requestId", true)]
        public void ShowRequestId_ShouldReturnCorrectResult(string requestId, bool expected)
        {
            // Arrange
            var errorViewModel = new ErrorViewModel { RequestId = requestId };

            // Act
            var result = errorViewModel.ShowRequestId;

            // Assert
            Assert.Equal(expected, result);
        }
    }
}
