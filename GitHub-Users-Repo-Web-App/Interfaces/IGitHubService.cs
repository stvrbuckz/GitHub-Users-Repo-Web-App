using GitHub_Users_Repo_Web_App.Models;
using GitHub_Users_Repo_Web_App.Models.GitHub;
using System.Net;

namespace GitHub_Users_Repo_Web_App.Interfaces
{
    public interface IGitHubService
    {
        public Task<HttpStatusCode> GetGitHubApiStatus();

        public Task<bool> CheckUserGitHubExists(string username);

        public Task<GitHubUserDetails> GetGitHubUserDetails(string username);
    }
}
