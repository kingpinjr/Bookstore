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
        public List<GenreInfo> Genres { get; set; } = new List<GenreInfo>();
        public List<int> selectedGenreIds { get; set; } = new List<int>();
        public List<SelectListItem> Bookstores { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Authors { get; set; } = new List<SelectListItem>();
        public void OnGet()
        {
            PopulateGenreList();
            PopulateBookstoreList();
            PopulateAuthorList();
            newBook.GenreIds = selectedGenreIds;
        }
        public IActionResult OnPost()
        {
            int id = 0;
            if (ModelState.IsValid)
            {
                using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
                {
                    string cmdText = "INSERT INTO Book(Title, Description, Price, AuthorID, BookstoreID, Publisher, PublicationDate, ISBN, Stock, PictureURL)" +
                        " VALUES  (@title, @description, @price, @authorId, @bookstoreId, @publisher, @publicationDate, @isbn, @stock, @pictureUrl); SELECT @@identity AS BookId";
                        
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
                    cmd.Parameters.AddWithValue("@pictureUrl", newBook.PictureURL);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        if (reader["BookId"] != null)
                        {
                            id = int.Parse(reader["BookId"].ToString());
                            newBook.BookId = id;
                        }
                    }
                    
                }
                if (id != 0)
                {
                    BookGenres(id);
                    return RedirectToPage("ViewBooks");
                }
                else
                {
                    ModelState.AddModelError("AddBookError", "Cannot add the book, please try again.");
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }

        private void BookGenres(int id)
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "INSERT INTO BookGenre(BookID, GenreID) VALUES(@bookId, @genreId)";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                for(int i = 0; i < selectedGenreIds.Count; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@bookId", id);
                    cmd.Parameters.AddWithValue("@genreId", selectedGenreIds[i]);
                    newBook.GenreIds.Add(selectedGenreIds[i]);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void PopulateGenreList()
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
                        GenreInfo genre = new GenreInfo();
                        genre.GenreID = reader.GetInt32(0);
                        genre.GenreName = reader.GetString(1);
                        genre.isSelected = false;
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
                        Authors.Add(author);
                    }
                }
            }
        }
        public class GenreInfo
        {
            public int GenreID { get; set; }
            public string GenreName { get; set; }
            public bool isSelected { get; set; }
        }
    }
}
