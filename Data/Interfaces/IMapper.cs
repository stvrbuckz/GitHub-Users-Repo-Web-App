using Data.Models.GitHub;

namespace Data.Interfaces
{
    public interface IMapper
    {
        public GitHubUserDetails MapUserDetails(string response);

        public List<GitHubRepo> MapRepos(string response);
    }
}
