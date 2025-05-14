using System.ComponentModel.DataAnnotations;

namespace GitHub_Users_Repo_Web_App.Models.GitHub
{
    public class GitHubRepo
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public int StargazersCount { get; set; }
    }
}
