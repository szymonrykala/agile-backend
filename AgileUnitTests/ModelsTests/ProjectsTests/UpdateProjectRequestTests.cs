using AgileApp.Models.Projects;
using Xunit;

namespace AgileUnitTests.ModelsTests.ProjectsTests
{
    public class UpdateProjectRequestTests
    {
        [Fact]
        public void UpdateProjectRequest_ShouldHaveIdProperty()
        {
            // Arrange
            var updateProjectRequest = new UpdateProjectRequest();

            // Act
            updateProjectRequest.Id = 1;

            // Assert
            Assert.Equal(1, updateProjectRequest.Id);
        }

        [Fact]
        public void UpdateProjectRequest_ShouldHaveNameProperty()
        {
            // Arrange
            var updateProjectRequest = new UpdateProjectRequest();

            // Act
            updateProjectRequest.Name = "Test Project";

            // Assert
            Assert.Equal("Test Project", updateProjectRequest.Name);
        }

        [Fact]
        public void UpdateProjectRequest_ShouldHaveDescriptionProperty()
        {
            // Arrange
            var updateProjectRequest = new UpdateProjectRequest();

            // Act
            updateProjectRequest.Description = "Test Description";

            // Assert
            Assert.Equal("Test Description", updateProjectRequest.Description);
        }
    }
}
