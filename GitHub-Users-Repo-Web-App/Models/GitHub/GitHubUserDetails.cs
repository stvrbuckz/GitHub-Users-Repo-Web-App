using System.ComponentModel.DataAnnotations;

namespace GitHub_Users_Repo_Web_App.Models.GitHub
{
    public class GitHubUserDetails
    {
        [Display(Name = "User's Name")]
        public string Name { get; set; }

        [Display(Name = "Location")]

        public string Location { get; set; }

        [Display(Name = "Avatar Image")]
        public string Image { get; set; }

        public List<GitHubRepo> Repositories { get; set; }
    }
}
