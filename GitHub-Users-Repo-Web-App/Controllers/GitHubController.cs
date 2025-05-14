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
        public async Task<IActionResult> SubmitUsername(UsernameDetails model)
        {
            // Check if model state is valid
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var apiStatus = await _gitHubService.GetGitHubApiStatus();

            if(apiStatus != System.Net.HttpStatusCode.OK)
            {
                ViewBag.ErrorMessage = "GitHub API is currently unavailable. Please try again later.";
                return View(model);
            }

            var userExists = await _gitHubService.CheckUserGitHubExists(model.Username);

            // Check if user exists is true
            if (!userExists)
            {
                ViewBag.ErrorMessage = "User not found. Please try a different username.";
                return View(model);
            }

            return RedirectToAction("GitHubUserDetails", new {model.Username});
        }

        [HttpGet]
        public async Task<IActionResult> GitHubUserDetails(string username)
        {
            // Get Git Hub user details and repositories
            GitHubUserDetails model = await _gitHubService.GetGitHubUserDetails(username);

            return View(model);
        }
    }
}
