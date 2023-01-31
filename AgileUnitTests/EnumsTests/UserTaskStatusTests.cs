using AgileApp.Enums;
using Xunit;

namespace AgileUnitTests.EnumsTests
{
    public class UserTaskStatusTests
    {
        [Fact]
        public void ShouldReturnCorrectValue_WhenTaskIsUnassigned()
        {
            var taskStatus = UserTaskStatus.Unassigned;

            Assert.Equal(UserTaskStatus.Unassigned, taskStatus);
        }

        [Fact]
        public void ShouldReturnCorrectValue_WhenTaskIsAssigned()
        {
            var taskStatus = UserTaskStatus.Assigned;

            Assert.Equal(UserTaskStatus.Assigned, taskStatus);
        }

        [Fact]
        public void ShouldReturnCorrectValue_WhenWorkOnTaskHasStarted()
        {
            var taskStatus = UserTaskStatus.WorkStarted;

            Assert.Equal(UserTaskStatus.WorkStarted, taskStatus);
        }

        [Fact]
        public void ShouldReturnCorrectValue_WhenWorkOnTaskHasCompleted()
        {
            var taskStatus = UserTaskStatus.WorkCompleted;

            Assert.Equal(UserTaskStatus.WorkCompleted, taskStatus);
        }

        [Fact]
        public void ShouldReturnCorrectValue_WhenTaskIsArchived()
        {
            var taskStatus = UserTaskStatus.Archived;

            Assert.Equal(UserTaskStatus.Archived, taskStatus);
        }
    }
}
