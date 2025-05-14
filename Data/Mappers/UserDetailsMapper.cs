using Data.Interfaces;
using Data.Models.GitHub;
using System.Text.Json;

namespace Data.Mappers
{
    public class Mapper : IMapper
    {
        public GitHubUserDetails MapUserDetails(string response)
        {
            var jsonData = JsonDocument.Parse(response).RootElement;

            GitHubUserDetails gitHubUserDetails = new GitHubUserDetails
            {
                Name = jsonData.GetProperty("name").ToString(),
                Location = jsonData.GetProperty("location").ToString(),
                Image = jsonData.GetProperty("avatar_url").ToString()
            };

            return gitHubUserDetails;
        }

        public List<GitHubRepo> MapRepos(string response)
        {
            var jsonData = JsonDocument.Parse(response).RootElement;
            List<GitHubRepo> gitHubRepos = new();

            // Iterate through each repository in the JSON array
            foreach (var repo in jsonData.EnumerateArray())
            {
                GitHubRepo gitHubRepo = new GitHubRepo
                {
                    Id = repo.GetProperty("id").GetInt32(),
                    Name = repo.GetProperty("name").ToString(),
                    Description = repo.GetProperty("description").ToString(),
                    Url = repo.GetProperty("html_url").ToString(),
                    StargazersCount = repo.GetProperty("stargazers_count").GetInt32()
                };

                gitHubRepos.Add(gitHubRepo);
            }

            return gitHubRepos;
        }

    }
}
