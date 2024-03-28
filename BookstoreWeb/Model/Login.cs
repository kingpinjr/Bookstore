using System.ComponentModel.DataAnnotations;

namespace BookstoreWeb.Model
{
    public class Login
    {
        [Required(ErrorMessage ="Email is required.")]
        public string Email {  get; set; }
        public string Password { get; set; }

    }
}
