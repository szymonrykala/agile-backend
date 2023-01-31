using AgileApp.Models.Tasks;
using Xunit;

namespace AgileUnitTests.ModelsTests.TasksTests
{
    public class AddTaskRequestTests
    {
        [Fact]
        public void AddTaskRequest_WhenPropertiesAreValid_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var name = "Test Task";
            var description = "Test description";
            var projectId = 1;
            var userId = 2;

            // Act
            var addTaskRequest = new AddTaskRequest
            {
                Name = name,
                Description = description,
                ProjectId = projectId,
                UserId = userId
            };

            // Assert
            Assert.Equal(name, addTaskRequest.Name);
            Assert.Equal(description, addTaskRequest.Description);
            Assert.Equal(projectId, addTaskRequest.ProjectId);
            Assert.Equal(userId, addTaskRequest.UserId);
        }
    }
}
