using BookstoreBusiness;
using BookstoreWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace BookstoreWeb.Pages
{
    [BindProperties]
    public class IndexModel : PageModel
    {
        public List<Book> Books { get; set; } = new List<Book>();

        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            PopulateBook();
            PopulateAuthor();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("Books/ViewBooks");
        }

        public void PopulateBook()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                // add 
                string cmdText = "SELECT Title, Price, AuthorID, PictureURL, Book.BookID FROM Book ";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var book = new Book();
                        book.Title = reader.GetString(0);
                        book.Price = reader.GetDecimal(1);
                        book.AuthorId = reader.GetInt32(2);
                        book.PictureURL = reader.GetString(3);
                        book.BookId = reader.GetInt32(4);
                        Books.Add(book);
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
    }
}
