using System.Text.RegularExpressions;

namespace StudentApp.Utils.Student
{
    public class VerificationStudent
    {
        public static IList<int> VerificationStudentPatterns(StudentApp.Models.Student s)
        {
            IList<int> errors = new List<int>();

            if (string.IsNullOrEmpty(s.Nom) || s.Nom.Length < 3 || !Regex.IsMatch(s.Nom, @"^[A-Za-z]+$"))
            {
                errors.Add(1);
            }

            if (string.IsNullOrEmpty(s.Prenom) || s.Prenom.Length < 3 || !Regex.IsMatch(s.Prenom, @"^[A-Za-z]+$"))
            {
                errors.Add(2);
            }


            if (string.IsNullOrEmpty(s.Cen))
            {
                errors.Add(3);
            }

            if (s.Cin == null ||  !Regex.IsMatch(s.Cin, @"^[A-Za-z]{1,2}\d+[A-Za-z]*$"))
            {
                errors.Add(4);
            }


            if (s.Tel == null || !Regex.IsMatch(s.Tel, @"^\d{10}$"))
            {
                errors.Add(5);
            }

            if (string.IsNullOrEmpty(s.Email) || !Regex.IsMatch(s.Email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errors.Add(6);
            }

            if (s.Adresse == null || s.Adresse.Length < 5)
            {
                errors.Add(7);
            }

            if (s.Cartier == 0)
            {
                errors.Add(8);
            }

            return errors;
        }


    }
}
