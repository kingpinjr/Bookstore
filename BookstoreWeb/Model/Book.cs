using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

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
        [Display(Name = "Bookstore")]
        [Required]
        public int BookstoreId { get; set; }
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
        [ValidateNever]
        public List<int> GenreIds { get; set; } = new List<int>();
    }
}
