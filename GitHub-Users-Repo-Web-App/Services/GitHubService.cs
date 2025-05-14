using GitHub_Users_Repo_Web_App.Interfaces;
using GitHub_Users_Repo_Web_App.Mappers;
using GitHub_Users_Repo_Web_App.Models;
using GitHub_Users_Repo_Web_App.Models.GitHub;
using Microsoft.AspNetCore.Mvc;

namespace GitHub_Users_Repo_Web_App.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public GitHubService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHub-Users-Repo-Web-App");
            _mapper = mapper;
        }

        public async Task<GitHubUserDetails> GetGitHubUserDetails(string username)
        {
            var response = await GetGitHubUserDetailsResponse(username);

            GitHubUserDetails gitHubUserDetails = _mapper.MapUserDetails(response);
            
            var repos = GetGitHubRepos(username).Result;
            gitHubUserDetails.Repositories = GetTopStargazerRepos(repos);

            return gitHubUserDetails;
        }

        private async Task<string> GetGitHubUserDetailsResponse(string username)
        {
            var url = $"https://api.github.com/users/{username}";

            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }

        private async Task<List<GitHubRepo>> GetGitHubRepos(string username)
        {
            var url = $"https://api.github.com/users/{username}/repos";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Request failed with status code {response.StatusCode}");
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            return _mapper.MapRepos(responseContent);
        }

        private List<GitHubRepo> GetTopStargazerRepos(List<GitHubRepo> gitHubRepos)
        {
            var topStargazerRepos = gitHubRepos.OrderByDescending(repo => repo.StargazersCount)
                .Take(5)
                .ToList();

            return topStargazerRepos;
        }
    }
}
