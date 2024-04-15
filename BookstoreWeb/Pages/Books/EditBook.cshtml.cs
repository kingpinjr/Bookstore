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
        public List<SelectListItem> Bookstores { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>();

        public void OnGet(int id)
        {
            PopulateBook(id);
            PopulateGenreList();
            PopulateBookstoreList();
            PopulateAuthorList();
        }
        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "UPDATE Book SET Title=@title, Description=@description, Price=@price, AuthorID=@authorId, BookstoreID=@bookstoreId," +
                        " Publisher=@publisher, PublicationDate=@publicationDate, ISBN=@isbn, Stock=@stock, GenreID= @genreId WHERE BookID=@bookId";
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
                string cmdText = "SELECT GenreID, GenreName FROM Genre ORDER BY GenreName";
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

        public void PopulateBookstoreList()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT BookstoreID, BookstoreName FROM Bookstore ORDER BY BookstoreName";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var bookstore = new SelectListItem();
                        bookstore.Value = reader.GetInt32(0).ToString();
                        bookstore.Text = reader.GetString(1);
                        if (bookstore.Value == Book.BookstoreId.ToString())
                        {
                            bookstore.Selected = true;
                        }
                        Bookstores.Add(bookstore);
                    }
                }
            }
        }
        public void PopulateAuthorList()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT AuthorID, FirstName, LastName FROM Author ORDER BY LastName";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var author = new SelectListItem();
                        author.Value = reader.GetInt32(0).ToString();
                        author.Text = reader.GetString(1) + " " + reader.GetString(2);
                        if (author.Value == Book.AuthorId.ToString())
                        {
                            author.Selected = true;
                        }
                        Authors.Add(author);
                    }
                }
            }
        }

        public void PopulateBook(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT Title, Description, Price, AuthorID, BookstoreID, Publisher, PublicationDate, ISBN, Stock, GenreID FROM Book WHERE BookID=@bookId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@bookId", id);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    Book.BookId = id;
                    Book.Title = reader.GetString(0);
                    Book.Description = reader.GetString(1);
                    Book.Price = reader.GetDecimal(2);
                    Book.AuthorId = reader.GetInt32(3);
                    Book.BookstoreId = reader.GetInt32(4);
                    Book.Publisher = reader.GetString(5);
                    Book.PublicationDate = DateOnly.FromDateTime(reader.GetDateTime(6));
                    Book.ISBN = reader.GetString(7);
                    Book.Stock = reader.GetInt32(8);
                    Book.GenreId = reader.GetInt32(9);
                }
            }
        }
    }
}
