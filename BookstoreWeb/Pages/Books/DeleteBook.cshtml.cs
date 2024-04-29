using BookstoreBusiness;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace BookstoreWeb.Pages.Books
{
    public class DeleteBookModel : PageModel
    {
        public IActionResult OnGet(int id)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "DELETE FROM BookGenre WHERE BookID=@bookId; DELETE FROM Book WHERE BookID=@bookId;";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("bookId", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                return RedirectToPage("ViewBooks");
            }
        }
    }
}
