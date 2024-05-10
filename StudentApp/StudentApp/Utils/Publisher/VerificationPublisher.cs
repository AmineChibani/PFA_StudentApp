using System.Text.RegularExpressions;

namespace StudentApp.Utils.Publisher
{
    public class VerificationPublisher
    {

        public static IList<int> VerificationPublisherPatterns(StudentApp.Models.Publisher p)
        {
            IList<int> errors = new List<int>();

            if (string.IsNullOrEmpty(p.Name) || p.Name.Length < 3 || !Regex.IsMatch(p.Name, @"^[A-Za-z]+$"))
            {
                errors.Add(1);
            }

            if (string.IsNullOrEmpty(p.Contact) || !Regex.IsMatch(p.Contact, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errors.Add(2);
            }

            if (p.Telephone == null || !Regex.IsMatch(p.Telephone, @"^\d{10}$"))
            {
                errors.Add(3);
            }

            return errors;
        }


    }
}
