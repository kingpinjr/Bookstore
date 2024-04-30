using BookstoreBusiness;
using BookstoreWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using System.Text.RegularExpressions;

namespace BookstoreWeb.Pages.Account
{
    [Authorize]
    
    public class ChangePasswordModel : PageModel
    {
        [BindProperty]
        public NewPassword Password { get; set; }
        public void OnGet()
        {
     
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                if (!VerifyOldPassword())
                {
                    ModelState.AddModelError("InvalidPassword", "Invalid password. Old password is incorrect!");
                    return Page();
                }
                var hasNumber = new Regex(@"[0-9]+");
                var hasUpperChar = new Regex(@"[A-Z]+");
                var hasLowerChar = new Regex(@"[a-z]+");
                var hasMinimum10Chars = new Regex(@".{10,}");

                if (!(hasNumber.IsMatch(Password.Password) && hasUpperChar.IsMatch(Password.Password) && hasLowerChar.IsMatch(Password.Password) && hasMinimum10Chars.IsMatch(Password.Password)))
                {
                    ModelState.AddModelError("InvalidPassword", "Invalid password. Must be at least 10 characters long, contain at least one number and one uppercase letter.");
                    return Page();
                }
                if (!Password.Password.Equals(Password.ConfirmPassword))
                {
                    ModelState.AddModelError("InvalidPassword", "Invalid password. New password is not same as confirmation password!");
                    return Page();
                }
                UpdatePassword();
                return RedirectToPage("Profile");
            }
            return Page();
        }

        private void UpdatePassword()
        {
            string email = HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "UPDATE [User] SET Password=@password WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratePasswordHash(Password.Password));
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private bool VerifyOldPassword()
        {
            string email = HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
            string passwordHash = "";
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT Password FROM [User] WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue(@"email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    passwordHash = reader.GetString(0);
                }
            }
            return SecurityHelper.VerifyPassword(Password.OldPassword, passwordHash);
        }
    }
}
