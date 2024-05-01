using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BookstoreWeb.Model;
using Microsoft.Data.SqlClient;
using BookstoreBusiness;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace BookstoreWeb.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login LoginUser { get; set; }
        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                // Check login credentials
                if (ValidateCredentials())
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

        private bool ValidateCredentials()
        {
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT Password, UserID, FirstName, Email, isAdmin FROM [User] WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", LoginUser.Email);
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
                            // Get the UserID and use it to update the User record
                            int userID = reader.GetInt32(1);
                            //UpdateUserLoginTime(userID);
                            
                            // Create a principal
                            string name = reader.GetString(2);
                            string role = reader.GetBoolean(4) ? "1" : "0";

                            // Create list of claims

                            Claim emailClaim = new Claim(ClaimTypes.Email, LoginUser.Email);
                            Claim nameClaim = new Claim(ClaimTypes.Name, name);
                            Claim roleClaim = new Claim(ClaimTypes.Role, role);

                            List<Claim> claims = new List<Claim> { emailClaim, nameClaim, roleClaim };

                            // Add the list of claims to a ClaimsIdentity
                            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            // Add identity to a ClaimsPrincipal
                            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                            // Call HttpContext.SigninAsync() method to encrypt the principal
                            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        /*
        private void UpdateUserLoginTime(int userID)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "UPDATE [User] SET LastLoginTime=@lastLoginTime WHERE UserID=@userID";
                SqlCommand cmd = new SqlCommand( cmdText, conn);
                cmd.Parameters.AddWithValue("@lastLoginTime", DateTime.Now);
                cmd.Parameters.AddWithValue("@userID", userID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }*/
    }
}
