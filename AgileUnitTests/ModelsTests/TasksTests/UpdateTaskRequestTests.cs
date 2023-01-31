using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileApp.Enums;
using AgileApp.Models.Tasks;
using Xunit;

namespace AgileUnitTests.ModelsTests.TasksTests
{
    public class UpdateTaskRequestTests
    {
        [Fact]
        public void UpdateTaskRequest_WhenPropertiesAreValid_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var id = 1;
            var name = "Test Task";
            var description = "Test description";
            var projectId = 2;
            var userId = 3;

            // Act
            var updateTaskRequest = new UpdateTaskRequest
            {
                Id = id,
                Name = name,
                Description = description,
                ProjectId = projectId,
                UserId = userId
            };

            // Assert
            Assert.Equal(id, updateTaskRequest.Id);
            Assert.Equal(name, updateTaskRequest.Name);
            Assert.Equal(description, updateTaskRequest.Description);
            Assert.Equal(projectId, updateTaskRequest.ProjectId);
            Assert.Equal(userId, updateTaskRequest.UserId);
        }

        [Fact]
        public void UpdateTaskRequest_WhenSomePropertiesAreNull_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var id = 1;
            var name = "Test Task";
            var description = "Test description";
            UserTaskStatus? status = null;
            int? projectId = null;
            int? userId = null;

            // Act
            var updateTaskRequest = new UpdateTaskRequest
            {
                Id = id,
                Name = name,
                Description = description,
                Status = status,
                ProjectId = projectId,
                UserId = userId
            };

            // Assert
            Assert.Equal(id, updateTaskRequest.Id);
            Assert.Equal(name, updateTaskRequest.Name);
            Assert.Equal(description, updateTaskRequest.Description);
            Assert.Null(updateTaskRequest.Status);
            Assert.Null(updateTaskRequest.ProjectId);
            Assert.Null(updateTaskRequest.UserId);
        }
    }
}
