using System.ComponentModel.DataAnnotations;

namespace GitHub_Users_Repo_Web_App.Models
{
    public class UsernameDetails
    {
        [Required(ErrorMessage = "Please enter a username")]
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}
