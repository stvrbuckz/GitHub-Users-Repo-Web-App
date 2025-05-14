using Data.Interfaces;
using Moq;

namespace UnitTest
{
    public class TestUserExists
    {
        private readonly Mock<IGitHubService> _gitHubServiceMock;

        public TestUserExists()
        {
            _gitHubServiceMock = new Mock<IGitHubService>();
        }

        // This attribute is used to indicate that this method is a test method.
        [Fact]
        public async void ShouldReturnGitHubUserExistsTrue()
        {
            // Arrange - set up preerequisites for the test, such as initialising variables and objects
            string username = "robconery";

            _gitHubServiceMock.Setup(s => s.CheckUserGitHubExists(username)).ReturnsAsync(true);
            var service = _gitHubServiceMock.Object;

            // Act - perform the action or operation that you want to test
            bool exists = await service.CheckUserGitHubExists(username);

            // Assert - verify that the result of the action matches the expected outcome
            Assert.True(exists, "User should exist on GitHub.");
        }

        [Fact]
        public async void ShouldReturnGitHubUserExistsFalse()
        {
            // Arrange
            string username = "4574e6ydeyhd";

            _gitHubServiceMock.Setup(s => s.CheckUserGitHubExists(username)).ReturnsAsync(false);
            var service = _gitHubServiceMock.Object;

            // Act
            bool exists = await service.CheckUserGitHubExists(username);

            // Assert
            Assert.False(exists, "User should not exist on GitHub.");
        }
    }
}