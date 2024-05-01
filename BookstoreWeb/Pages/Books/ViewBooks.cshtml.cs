using BookstoreBusiness;
using BookstoreWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Numerics;

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
            PopulateBook();
            PopulateAuthor();
            PopulateBookstore();
        }

        public void OnPost()
        {
            PopulateBook();
            PopulateGenreList();
            PopulateAuthor();
            PopulateBookstore();
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
                        if (genre.Value == SelectedGenreId.ToString() || SelectedGenreId == 0)
                        {
                            genre.Selected = true;
                            SelectedGenreId = Convert.ToInt32(genre.Value);
                        }
                        Genres.Add(genre);
                    }
                }
            }
        }
        public void PopulateAuthor()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {

                foreach (var a in Books)
                {
                    conn.Open();
                    string cmdText2 = "SELECT FirstName, LastName FROM Author WHERE Author.AuthorId = @authorId";
                    SqlCommand cmd2 = new SqlCommand(cmdText2, conn);
                    cmd2.Parameters.AddWithValue("@authorId", a.AuthorId);


                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        reader2.Read();
                        string authorName = reader2["FirstName"].ToString() + " " + reader2["LastName"].ToString();
                        a.AuthorName = authorName;
                    }
                    conn.Close();
                }
            }
        }
        public void PopulateBookstore()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {

                foreach (var a in Books)
                {
                    conn.Open();
                    string cmdText = "SELECT BookstoreName FROM Bookstore WHERE Bookstore.BookstoreID = @bookstoreId";
                    SqlCommand cmd2 = new SqlCommand(cmdText, conn);
                    cmd2.Parameters.AddWithValue("@bookstoreId", a.BookstoreId);


                    SqlDataReader reader2 = cmd2.ExecuteReader();
                    if (reader2.HasRows)
                    {
                        reader2.Read();
                        string bookstoreName = reader2["BookstoreName"].ToString();
                        a.BookstoreName = bookstoreName;
                    }
                    conn.Close();
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
