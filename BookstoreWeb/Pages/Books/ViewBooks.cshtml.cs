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
        public List<GenreInfo> SelectedGenreInfo { get; set; } = new List<GenreInfo>();
        public List<Book> Books { get; set; } = new List<Book>();
        public int SelectedGenreId { get; set; }
        public void OnGet()
        {
            PopulateGenreList();
        }

          public void OnPost()
        {
            PopulateBook();
            PopulateGenreList();
        }
        public void PopulateBook()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                // add 
                string cmdText = "SELECT Title, Description, Price, AuthorID, BookstoreID, Publisher, PublicationDate, ISBN, Stock, PictureURL, Book.BookID FROM Book " +
                                 "INNER JOIN BookGenre ON Book.BookID = BookGenre.BookID WHERE BookGenre.GenreID=@genreId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@genreId", SelectedGenreId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var book = new Book();
                        book.Title = reader.GetString(0);
                        book.Description = reader.GetString(1);
                        book.Price = reader.GetDecimal(2);   
                        book.AuthorId = reader.GetInt32(3);
                        book.BookstoreId = reader.GetInt32(4);
                        book.Publisher = reader.GetString(5);
                        book.PublicationDate = DateOnly.FromDateTime(reader.GetDateTime(6));
                        book.ISBN = reader.GetString(7);
                        book.Stock = reader.GetInt32(8);
                        book.PictureURL = reader.GetString(9);
                        book.BookId = reader.GetInt32(10);
                        PopulateBookGenres(book);
                        Books.Add(book);
                    }
                }
            }
        }

        private void PopulateBookGenres(Book book)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT BookGenre.GenreID, GenreName FROM BookGenre INNER JOIN Genre ON BookGenre.GenreID = Genre.GenreID WHERE BookID = @bookId";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@bookId", book.BookId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                int ctr = 0;
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        book.GenreIds.Add(reader.GetInt32(0));
                        var genre = new GenreInfo();
                        genre.GenreID = book.GenreIds[ctr];
                        genre.GenreName = reader.GetString(1);
                        SelectedGenreInfo.Add(genre);
                        ctr++;
                    }
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
        public class GenreInfo
        {
            public int GenreID { get; set; }
            public string GenreName { get; set; }
        }
    }
}
