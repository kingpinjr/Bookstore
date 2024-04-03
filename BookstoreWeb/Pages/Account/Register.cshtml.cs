using BookstoreBusiness;
using BookstoreWeb.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace BookstoreWeb.Pages.Account
{
    public class Register : PageModel
    {
        [BindProperty]
        public Person NewPerson { get; set; }
        public void OnGet()
        {
            /*NewPerson.FirstName = "Please enter your first name.";
            NewPerson.LastName = "Please enter your last name.";*/
        }
        public ActionResult OnPost() 
        {
            if (ModelState.IsValid)
            {
                // Make sure the email does not exist before registering the user

                if (EmailAvailable(NewPerson.Email))
                {
                    RegisterUser();
                    return RedirectToPage("Login");
                }
                else
                {
                    ModelState.AddModelError("RegisterError", "The email address already exists. Try a different one.");
                    return Page();
                }
            }
            else
            {
                return Page();
            }
        }

        private void RegisterUser()
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {

                // 2. Create an insert query

                string cmdText = "INSERT INTO [User] (FirstName, LastName, Email, Password, PhoneNumber, Address, City, State, PostalCode, isAdmin)" +
                    " VALUES (@firstName, @lastName, @email, @password, @phoneNumber, @address, @city, @state, @postalCode, 0);";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@firstName", NewPerson.FirstName);
                cmd.Parameters.AddWithValue("@lastName", NewPerson.LastName);
                cmd.Parameters.AddWithValue("@email", NewPerson.Email);
                cmd.Parameters.AddWithValue("@password", SecurityHelper.GeneratePasswordHash(NewPerson.Password));
                cmd.Parameters.AddWithValue("@phoneNumber", NewPerson.PhoneNumber);
                cmd.Parameters.AddWithValue("@address", NewPerson.Address);
                cmd.Parameters.AddWithValue("@city", NewPerson.City);
                cmd.Parameters.AddWithValue("@state", NewPerson.State);
                cmd.Parameters.AddWithValue("@postalCode", NewPerson.PostalCode);
                //cmd.Parameters.AddWithValue("@firstName", NewPerson.RoleId);

                // 3. Open the database

                conn.Open();

                // 4. Execute the query

                // use ExecuteNonQuery when you aren't expecting a return result
                // for example, an insert, update, or delete query
                cmd.ExecuteNonQuery();
            }
        }

        private bool EmailAvailable(string email)
        {
            using(SqlConnection conn = new SqlConnection(SecurityHelper.GetDBConnectionString()))
            {
                string cmdText = "SELECT Email FROM [User] WHERE Email=@email";
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Parameters.AddWithValue("@email", email);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
