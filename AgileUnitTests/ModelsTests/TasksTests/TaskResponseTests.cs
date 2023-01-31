using AgileApp.Models.Tasks;
using Xunit;

namespace AgileUnitTests.ModelsTests.TasksTests
{
    public class TaskResponseTests
    {
        [Fact]
        public void TaskResponse_WhenPropertiesAreValid_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var name = "Test Task";
            var description = "Test description";

            // Act
            var taskResponse = new TaskResponse
            {
                Name = name,
                Description = description
            };

            // Assert
            Assert.Equal(name, taskResponse.Name);
            Assert.Equal(description, taskResponse.Description);
        }
    }
}
