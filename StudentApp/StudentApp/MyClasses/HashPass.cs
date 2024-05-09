
using StudentApp.MyClasses;
using System.Security.Cryptography;
using System.Text;

namespace StudentApp.MyClasses
{
    public class HashPass : IHashPassword
    {
        private readonly HMACSHA256 sha256;

        private readonly byte[] secretKey;

        public HashPass()
        {
            this.secretKey = Encoding.UTF8.GetBytes(getSecret());
            this.sha256 = new HMACSHA256(this.secretKey);
        }

        public string HashPassword(string password)
        {
            byte[] hashedBytes = this.sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            string hashedInput = HashPassword(password);
            return string.Equals(hashedInput, hashedPassword, StringComparison.OrdinalIgnoreCase);
        }

        private static string getSecret()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            string ipAddress = configuration.GetSection("ServerSettings")["Secret"];
            return ipAddress;
        }
    }
    
}
