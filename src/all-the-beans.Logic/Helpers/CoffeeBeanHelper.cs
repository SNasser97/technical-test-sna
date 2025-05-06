using System.Security.Cryptography;
using System.Text;

namespace all_the_beans.Logic.Helpers
{
    public class CoffeeBeanHelper
    {
        public static string GenerateId(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
                string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hashString.Substring(0, 24); // Trim to 24 characters
            }
        }
    }
}
