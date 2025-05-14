using System.ComponentModel.DataAnnotations;

namespace GitHub_Users_Repo_Web_App.Models.GitHub
{
    public class GitHubRepo
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Repository Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Repository URL")]
        public string Url { get; set; }

        [Display(Name = "Stargazers Count")]
        public int StargazersCount { get; set; }
    }
}
