using BookstoreBusiness;
using BookstoreWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;

namespace BookstoreWeb.Pages.Books
{
    [BindProperties]
    public class ViewBooksModel : PageModel
    {
        public List<SelectListItem> Genres { get; set; } = new List<SelectListItem>();

        public List<Book> Books { get; set; } = new List<Book>();

        public int SelectedGenreId { get; set; }
        public void OnGet()
        {
            PopulateGenreList();
        }
        public void OnPost()
        {
            PopulateBook(SelectedGenreId);
            PopulateGenreList();
        }
        public void PopulateBook(int SelectedGenreId)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT BookId, Title, Description, Price, AuthorId, BookstoreId, Publisher, PublicationDate, ISBN, Stock, GenreId FROM Book WHERE GenreId=@genreId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@genreId", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var book = new Book();
                        book.BookId = reader.GetInt32(0);
                        book.Title = reader.GetString(1);
                        book.Description = reader.GetString(2);
                        book.Price = reader.GetString(3);   
                        book.AuthorId = reader.GetInt32(4);
                        book.BookstoreId = reader.GetInt32(5);
                        book.Publisher = reader.GetString(6);
                        book.PublicationDate = reader.GetString(7);
                        book.ISBN = reader.GetInt32(8);
                        book.Stock = reader.GetInt32(9);
                        book.GenreId = reader.GetInt32(10);
                        Books.Add(book);
                    }
                }
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

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var genre = new SelectListItem();
                        genre.Value = reader.GetInt32(0).ToString();
                        genre.Text = reader.GetString(1);
                        if (genre.Value == SelectedGenreId.ToString())
                        {
                            genre.Selected = true;
                        }
                        Genres.Add(genre);
                    }
                }
            }
        }
    }
}
