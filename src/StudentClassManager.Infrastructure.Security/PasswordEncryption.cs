using System.Text;
using System.Security.Cryptography;

namespace StudentClassManager.Infrastructure.Security;

public class PasswordEncryption
{
    public static string EncryptPassword(string password)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            byte[] hashBytes = md5.ComputeHash(passwordBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }

            return sb.ToString();
        }
    }
}