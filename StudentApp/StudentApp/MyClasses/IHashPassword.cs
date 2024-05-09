using System.Security.Cryptography;
using System.Text;

namespace StudentApp.MyClasses
{
    public interface IHashPassword
    {

        public string HashPassword(string password);

        public bool VerifyPassword(string password, string hashedPassword);

    }
}
