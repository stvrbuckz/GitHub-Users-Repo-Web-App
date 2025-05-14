using GitHub_Users_Repo_Web_App.Models;
using GitHub_Users_Repo_Web_App.Models.GitHub;

namespace GitHub_Users_Repo_Web_App.Interfaces
{
    public interface IGitHubService
    {
        public Task<GitHubUserDetails> GetGitHubUserDetails(string username);
    }
}
