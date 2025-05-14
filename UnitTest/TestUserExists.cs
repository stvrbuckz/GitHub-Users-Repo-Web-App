using GitHub_Users_Repo_Web_App.Interfaces;

namespace UnitTest
{
    public class TestUserExists(IGitHubService gitHubService)
    {
        private readonly IGitHubService _gitHubService = gitHubService;

        // This attribute is used to indicate that this method is a test method.
        [Fact]
        public async void ShouldReturnGitHubUserExistsTrue()
        {
            // Arrange - set up preerequisites for the test, such as initialising variables and objects
            string username = "robconery";

            // Act - perform the action or operation that you want to test
            bool exists = await _gitHubService.CheckUserGitHubExists(username);

            // Assert - verify that the result of the action matches the expected outcome
            Assert.True(exists, "User should exist on GitHub.");
        }

        [Fact]
        public async void ShouldReturnGitHubUserExistsFalse()
        {
            // Arrange
            string username = "4574e6ydeyhd";

            // Act
            bool exists = await _gitHubService.CheckUserGitHubExists(username);

            // Assert
            Assert.False(exists, "User should not exist on GitHub.");
        }
    }
}