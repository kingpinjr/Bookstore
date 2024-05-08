using System.ComponentModel.DataAnnotations;

namespace BookstoreWeb.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required(ErrorMessage = "The First Name is required.")]
        [Display(Name = "First Name ")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "The Last Name is required.")]
        [Display(Name = "Last Name ")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "The Email is required.")]
        [Display(Name = "Email ")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "The Password is required.")]
        [Display(Name = "Password ")]
        [StringLength(int.MaxValue, MinimumLength = 10, ErrorMessage = "Password must be at least 10 characters long.")]
        [RegularExpression(@"^(?:(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*)$", ErrorMessage = "Invalid password. Must contain at least one number, one uppercase letter, and one lowercase letter.")]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? PostalCode { get; set; }
        public int RoleId { get; set; }
        //public DateTime LastLoginTime { get; set; }
    }
}
