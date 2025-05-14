using System.Diagnostics;
using System.Net.Http;
using GitHub_Users_Repo_Web_App.Interfaces;
using GitHub_Users_Repo_Web_App.Models;
using GitHub_Users_Repo_Web_App.Models.GitHub;
using Microsoft.AspNetCore.Mvc;

namespace GitHub_Users_Repo_Web_App.Controllers
{
    public class GitHubController : Controller
    {
        private readonly IGitHubService _gitHubService;
        private readonly HttpClient _httpClient;

        public GitHubController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "GitHub-Users-Repo-Web-App");
        }

        [HttpGet]
        public IActionResult SubmitUsername()
        {
            UsernameDetails model = new();

            return View(model);
        }

        [HttpPost]
        public IActionResult SubmitUsername(UsernameDetails model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("GitHubUserDetails", new { username = model.Username });
        }

        [HttpGet]
        public async Task<IActionResult> GitHubUserDetails(string username)
        {
            GitHubUserDetails model = await _gitHubService.GetGitHubUserDetails(username);

            return View(model);
        }
    }
}
