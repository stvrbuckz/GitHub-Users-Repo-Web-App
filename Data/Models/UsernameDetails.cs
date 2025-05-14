using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class UsernameDetails
    {
        [Required(ErrorMessage = "Please enter a username")]
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}
