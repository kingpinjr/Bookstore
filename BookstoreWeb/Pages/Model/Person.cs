using System.ComponentModel.DataAnnotations;

namespace BookstoreWeb.Pages.Model
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password {  get; set; }
        [Required]
        public string Telephone {  get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State {  get; set; }
        public string PostalCode { get; set; }
        public int RoleId { get; set; }
        //public DateTime LastLoginTime { get; set; }
    }
}
