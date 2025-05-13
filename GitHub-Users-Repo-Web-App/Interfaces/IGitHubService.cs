using GitHub_Users_Repo_Web_App.Models;

namespace GitHub_Users_Repo_Web_App.Interfaces
{
    public interface IGitHubService
    {
        public void GetUserDetails(string username);
    }
}
