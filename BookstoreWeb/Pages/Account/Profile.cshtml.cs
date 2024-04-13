using BookstoreBusiness;
using BookstoreWeb.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;

namespace BookstoreWeb.Pages.Account
{
    [Authorize]
    public class ProfileModel : PageModel
    {
        //[BindProperty]
        public UserProfile profile = new UserProfile();
        public void OnGet()
        {
            PopulateProfile();
        }

        private void PopulateProfile()
        {
            string email = HttpContext.User.FindFirstValue(ClaimValueTypes.Email);
            using (SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT FirstName, LastName, Email, PhoneNumber FROM [User] WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue(@"email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    profile.FirstName = reader.GetString(0);
                    profile.LastName = reader.GetString(1);
                    profile.Email = reader.GetString(2);
                    profile.PhoneNumber = reader.GetString(3);
                }
            }

        }
    }
}
