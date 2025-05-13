using GitHub_Users_Repo_Web_App.Interfaces;
using GitHub_Users_Repo_Web_App.Models;

namespace GitHub_Users_Repo_Web_App.Services
{
    public class GitHubService : IGitHubService
    {
        private readonly HttpClient _httpClient;

        public GitHubService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async void GetUserDetails(string username)
        {

        }

    }
}
