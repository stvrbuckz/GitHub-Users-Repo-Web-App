using System.ComponentModel.DataAnnotations;

namespace GitHub_Users_Repo_Web_App.Models
{
    public class UsernameDetails
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}
