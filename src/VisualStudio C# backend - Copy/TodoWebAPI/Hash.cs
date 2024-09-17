using System.Security.Cryptography;
using System.Text;

namespace TodoWebAPI
{
    public class Hash
    {
        public static string ToSHA256(string inputString)
        {
            using var sha256 = SHA256.Create();
            byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputString));

            var builtString = new StringBuilder();
            for (int i = 0; i  < bytes.Length; i++)
            {
                builtString.Append(bytes[i].ToString("x2"));
            }
            return builtString.ToString();
        }
    }
}
