using AgileApp.Models.Projects;
using Xunit;

namespace AgileUnitTests.ModelsTests.ProjectsTests
{
    public class AddProjectRequestTests
    {
        [Fact]
        public void AddProjectRequest_ShouldHaveNameProperty()
        {
            // Arrange
            var addProjectRequest = new AddProjectRequest();

            // Act
            addProjectRequest.Name = "Test Project";

            // Assert
            Assert.Equal("Test Project", addProjectRequest.Name);
        }

        [Fact]
        public void AddProjectRequest_ShouldHaveDescriptionProperty()
        {
            // Arrange
            var addProjectRequest = new AddProjectRequest();

            // Act
            addProjectRequest.Description = "Test Description";

            // Assert
            Assert.Equal("Test Description", addProjectRequest.Description);
        }
    }
}
