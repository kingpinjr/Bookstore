using BookstoreBusiness;
using BookstoreWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Numerics;
using System.Reflection;

namespace BookstoreWeb.Pages.Books
{
    [BindProperties]
    public class AddBookModel : PageModel
    {
        public Book newBook { get; set; } = new Book();
        public List<SelectListItem> Genres { get; set; } = new List<SelectListItem>();
        public void OnGet()
        {
            PopulateGenreList();
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Book(Title, Description, Price, AuthorId, BokstoreId, Publisher, PublicationDate, ISBN, Stock, GenreId)" +
                        "VALUES  (@title, @description, @price, @authorId, @bookstoreId, @publisher, @publicationDate, @isbn, @stock, @genreId)";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@title", newBook.Title);
                    cmd.Parameters.AddWithValue("@description", newBook.Description);
                    cmd.Parameters.AddWithValue("@price", newBook.Price);
                    cmd.Parameters.AddWithValue("@authorId", newBook.AuthorId);
                    cmd.Parameters.AddWithValue("@bookstoreId", newBook.BookstoreId);
                    cmd.Parameters.AddWithValue("@publisher", newBook.Publisher);
                    cmd.Parameters.AddWithValue("@publicationDate", newBook.PublicationDate);
                    cmd.Parameters.AddWithValue("@isbn", newBook.ISBN);
                    cmd.Parameters.AddWithValue("@stock", newBook.Stock);
                    cmd.Parameters.AddWithValue("@genreId", newBook.GenreId);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return RedirectToPage("ViewBooks");
                }
            }
            else
            {
                return Page();
            }
        }
        public void PopulateGenreList()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT GenreId, GenreName FROM Genre ORDER BY GenreName";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        var genre = new SelectListItem();
                        genre.Value = reader.GetInt32(0).ToString();
                        genre.Text = reader.GetString(1);
                        Genres.Add(genre);
                    }
                }
            }
        }
    }
}
