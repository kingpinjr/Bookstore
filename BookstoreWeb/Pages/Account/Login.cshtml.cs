using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookstoreWeb.Model;
using Microsoft.Data.SqlClient;
using BookstoreBusiness;

namespace BookstoreWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LoginUser { get; set; }
        public void OnGet()
        {

        }

        public ActionResult onPost()
        {
            if (ModelState.IsValid)
            {
                SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString());
                string cmdText = "SELECT Password FROM User WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    if (!reader.IsDBNull(0))
                    {
                        string passwordHash = reader.GetString(0);
                        if (SecurityHelper.VerifyPassword(LoginUser.Password, passwordHash))
                        {
                            return RedirectToPage("Profile");
                        }
                        else
                        {
                            ModelState.AddModelError("LoginError", "Invalid credentials. Try again.");
                            return Page();
                        }
                    }
                    else
                    {
                        return Page();
                    }
                }
                else
                {
                    ModelState.AddModelError("LoginError", "Invalid credentials. Try again.");
                    return Page();
                }
                conn.Close();
            }
            else
            {
                return Page();
            }
        }
    }
}
