using Data.Interfaces;
using Data.Mappers;
using Data.Models;
using Data.Models.GitHub;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Data.Services
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

        /// <summary>
        /// This method returns the HTTP Status Code of the GitHub API.
        /// </summary>
        public async Task<HttpStatusCode> GetGitHubApiStatus()
        {
            var url = "https://api.github.com/users";
            var response = await _httpClient.GetAsync(url);
            return response.StatusCode;
        }


        /// <summary>
        /// This method returns true or false if the user exists on GitHub via the API.
        /// </summary>
        /// <param name="username">the username of the user to search for.</param>
        public async Task<bool> CheckUserGitHubExists(string username)
        {
            var url = $"https://api.github.com/users/{username}";
            var response = await _httpClient.GetAsync(url);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// This method returns the GitHub user details and their top 5 stargazer repositories.
        /// </summary>
        /// <param name="username">the username of the user to search for.</param>
        public async Task<GitHubUserDetails> GetGitHubUserDetails(string username)
        {
            var response = await GetGitHubUserDetailsResponse(username);

            if(response != null && response != "")
            {
                GitHubUserDetails gitHubUserDetails = _mapper.MapUserDetails(response);

                var repos = GetGitHubRepos(username).Result;
                gitHubUserDetails.Repositories = GetTopStargazerRepos(repos);

                return gitHubUserDetails;
            } else
            {
                return null;
            } 
        }

        /// <summary>
        /// This method returns the GitHub user details response from the GitHub API.
        /// </summary>
        /// <param name="username">the username of the user to search for.</param>
        public async Task<string> GetGitHubUserDetailsResponse(string username)
        {
            var url = $"https://api.github.com/users/{username}";

            var response = await _httpClient.GetAsync(url);

            var responseContent = await response.Content.ReadAsStringAsync();

            return responseContent;
        }

        /// <summary>
        /// This method returns the GitHub repositories of the user from the GitHub API.
        /// </summary>
        /// <param name="username">the username of the user to search for.</param>
        public async Task<List<GitHubRepo>> GetGitHubRepos(string username)
        {
            var url = $"https://api.github.com/users/{username}/repos";
            var response = await _httpClient.GetAsync(url);

            var responseContent = await response.Content.ReadAsStringAsync();
            return _mapper.MapRepos(responseContent);
        }

        /// <summary>
        /// This method returns the top five stargazer repositories of the user with the highest stargazer count.
        /// </summary>
        /// <param name="gitHubRepos">the list of GitHub repositories.</param>
        public List<GitHubRepo> GetTopStargazerRepos(List<GitHubRepo> gitHubRepos)
        {
            var topStargazerRepos = gitHubRepos.OrderByDescending(repo => repo.StargazersCount)
                .Take(5)
                .ToList();

            return topStargazerRepos;
        }
    }
}
