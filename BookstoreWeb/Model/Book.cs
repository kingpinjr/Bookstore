using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using static System.Net.WebRequestMethods;

namespace BookstoreWeb.Model
{
    public class Book
    {
        public int BookId {  get; set; }
        [Display(Name = "Title")]
        [Required]
        public string Title { get; set; }
        [Display(Name = "Description")]
        [Required]
        public string Description { get; set; }
        [Display(Name = "Price")]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Author")]
        [Required]
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        [Display(Name = "Bookstore")]
        [Required]
        public int BookstoreId { get; set; }
        public string? BookstoreName { get; set; }
        [Display(Name = "Publisher")]
        [Required]
        public string Publisher { get; set; }
        [Display(Name = "Publication Date")]
        [Required]
        public DateOnly PublicationDate { get; set; }
        [Display(Name = "ISBN")]
        [Required]
        public string ISBN { get; set; }
        [Display(Name = "Stock")]
        [Required]
        public int Stock {  get; set; }
        [Display(Name = "Picture URL")]
        public string PictureURL { get; set; } = "https://st4.depositphotos.com/14953852/24787/v/450/depositphotos_247872612-stock-illustration-no-image-available-icon-vector.jpg";
        [ValidateNever]
        public List<int> GenreIds { get; set; } = new List<int>();
    }
}
