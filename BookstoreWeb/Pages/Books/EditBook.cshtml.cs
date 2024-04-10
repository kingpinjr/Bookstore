using BookstoreBusiness;
using BookstoreWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace BookstoreWeb.Pages.Books
{
    [BindProperties]
    public class EditBookModel : PageModel
    {
        public Book Book { get; set; } = new Book();
        public List<SelectListItem> Genres { get; set; } = new List<SelectListItem>();
        public void OnGet(int id)
        {
            PopulateBook(id);
            PopulateGenreList();
        }
        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE Book SET Title=@title, Description=@description, Price=@price, AuthorId=@authorId, BokstoreId=@bookstoreId," +
                        " Publisher=@publisher, PublicationDate=@publicationDate, ISBN=@isbn, Stock=@stock, GenreId= @genreId WHERE BookId=@bookId";
                    SqlCommand cmd = new SqlCommand(cmdText, conn);
                    cmd.Parameters.AddWithValue("@title", Book.Title);
                    cmd.Parameters.AddWithValue("@description", Book.Description);
                    cmd.Parameters.AddWithValue("@price", Book.Price);
                    cmd.Parameters.AddWithValue("@authorId", Book.AuthorId);
                    cmd.Parameters.AddWithValue("@bookstoreId", Book.BookstoreId);
                    cmd.Parameters.AddWithValue("@publisher", Book.Publisher);
                    cmd.Parameters.AddWithValue("@publicationDate", Book.PublicationDate);
                    cmd.Parameters.AddWithValue("@isbn", Book.ISBN);
                    cmd.Parameters.AddWithValue("@stock", Book.Stock);
                    cmd.Parameters.AddWithValue("@genreId", Book.GenreId);
                    cmd.Parameters.AddWithValue("@bookId", id);

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
        private void PopulateGenreList()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT GenreId, GenreName FROM Genre ORDER BY GenreName";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var genre = new SelectListItem();
                        genre.Value = reader.GetInt32(0).ToString();
                        genre.Text = reader.GetString(1);
                        if (genre.Value == Book.GenreId.ToString())
                        {
                            genre.Selected = true;
                        }
                        Genres.Add(genre);
                    }
                }
            }
        }

        public void PopulateBook(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT Title, Description, Price, AuthorId, BokstoreId, Publisher, PublicationDate, ISBN, Stock, GenreId FROM Book WHERE BookId=@bookId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@bookId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Book.BookId = id;
                    Book.Title = reader.GetString(1);
                    Book.Description = reader.GetString(2);
                    Book.Price = reader.GetString(3);
                    Book.AuthorId = reader.GetInt32(4);
                    Book.BookstoreId = reader.GetInt32(5);
                    Book.Publisher = reader.GetString(6);
                    Book.PublicationDate = reader.GetString(7);
                    Book.ISBN = reader.GetInt32(8);
                    Book.Stock = reader.GetInt32(9);
                    Book.GenreId = reader.GetInt32(10);
                }
            }
        }
    }
}
