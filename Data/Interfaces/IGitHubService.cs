
using Data.Models.GitHub;
using System.Net;

namespace Data.Interfaces
{
    public interface IGitHubService
    {
        public Task<HttpStatusCode> GetGitHubApiStatus();

        public Task<bool> CheckUserGitHubExists(string username);

        public Task<GitHubUserDetails> GetGitHubUserDetails(string username);

        public Task<string> GetGitHubUserDetailsResponse(string username);

        public Task<List<GitHubRepo>> GetGitHubRepos(string username);

        public List<GitHubRepo> GetTopStargazerRepos(List<GitHubRepo> gitHubRepos);
    }
}
