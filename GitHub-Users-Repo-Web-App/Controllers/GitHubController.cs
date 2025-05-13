using System.Diagnostics;
using System.Net.Http;
using GitHub_Users_Repo_Web_App.Interfaces;
using GitHub_Users_Repo_Web_App.Models;
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
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("GitHubUserDetails", new { username = model.Username });
        }

        [HttpGet]
        public IActionResult GitHubUserDetails(string username)
        {
            //var userDetails = _gitHubService.GetUserDetails(username).Result;

            var url = $"https://api.github.com/users/{username}";

            var response =  _httpClient.GetAsync(url);

            //response.EnsureSuccessStatusCode();


            return View();
        }
    }
}
