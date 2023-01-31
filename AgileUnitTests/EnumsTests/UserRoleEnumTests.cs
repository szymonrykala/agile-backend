using AgileApp.Enums;
using Xunit;

namespace AgileUnitTests.EnumsTests
{
    public class UserRoleEnumTests
    {
        [Fact]
        public void ShouldReturnCorrectValue_WhenUserHasNoRole()
        {
            var userRole = UserRoleEnum.None;

            Assert.Equal(UserRoleEnum.None, userRole);
        }

        [Fact]
        public void ShouldReturnCorrectValue_WhenUserIsAStudent()
        {
            var userRole = UserRoleEnum.Student;

            Assert.Equal(UserRoleEnum.Student, userRole);
        }

        [Fact]
        public void ShouldReturnCorrectValue_WhenUserIsAProfessor()
        {
            var userRole = UserRoleEnum.Professor;

            Assert.Equal(UserRoleEnum.Professor, userRole);
        }
    }
}
