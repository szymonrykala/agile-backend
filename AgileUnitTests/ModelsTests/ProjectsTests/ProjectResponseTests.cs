using AgileApp.Models.Projects;
using Xunit;

namespace AgileUnitTests.ModelsTests.ProjectsTests
{
    public class ProjectResponseTests
    {
        [Fact]
        public void ProjectResponse_ShouldHaveNameProperty()
        {
            // Arrange
            var projectResponse = new ProjectResponse();

            // Act
            projectResponse.Name = "Test Project";

            // Assert
            Assert.Equal("Test Project", projectResponse.Name);
        }

        [Fact]
        public void ProjectResponse_ShouldHaveDescriptionProperty()
        {
            // Arrange
            var projectResponse = new ProjectResponse();

            // Act
            projectResponse.Description = "Test Description";

            // Assert
            Assert.Equal("Test Description", projectResponse.Description);
        }
    }
}
