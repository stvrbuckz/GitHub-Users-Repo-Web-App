using GitHub_Users_Repo_Web_App.Models.GitHub;

namespace GitHub_Users_Repo_Web_App.Interfaces
{
    public interface IMapper
    {
        public GitHubUserDetails MapUserDetails(string response);

        public List<GitHubRepo> MapRepos(string response);
    }
}
