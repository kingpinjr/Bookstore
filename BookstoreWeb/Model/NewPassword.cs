using System.ComponentModel.DataAnnotations;

namespace BookstoreWeb.Model
{
    public class NewPassword
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
