using BCrypt.Net;
namespace BookstoreBusiness
{
    public class SecurityHelper
    {
        public static string GeneratePasswordHash(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }

        public static bool VerifyPassword(string password, string passwordHash)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, passwordHash);
        }

        public static string GetDBConnectionString()
        {
            return "Server=(localdb)\\MSSQLLocalDB;Database=Bookstore;Trusted_Connection=true;";
        }
    }
}
