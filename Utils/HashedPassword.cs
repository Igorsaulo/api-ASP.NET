using System.Security.Cryptography;
using System.Text;

namespace FirstApp.HashedPassword{
    public class Hashed{
        public string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

                byte[] hashBytes = sha256.ComputeHash(passwordBytes);

                string hash = BitConverter.ToString(hashBytes).Replace("-", "");

                return hash;
            }
        }
    }
}