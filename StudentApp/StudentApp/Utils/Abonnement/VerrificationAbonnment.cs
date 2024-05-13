using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace StudentApp.Utils.Abonnement
{
    public class VerrificationAbonnment
    {
        public static IList<int> VerificationAbonnementPatterns(StudentApp.Models.Abonnement abonnement)
        {
            IList<int> errors = new List<int>();

            if (string.IsNullOrEmpty(abonnement.TypeAbonnement) || abonnement.TypeAbonnement.Length < 3 || !Regex.IsMatch(abonnement.TypeAbonnement, @"^[A-Za-z]+$"))
            {
                errors.Add(1);
            }
            if (abonnement.Solde <= 0)
            {
                errors.Add(2);
            }

            if (abonnement.StudentId == null )
            {
                errors.Add(3);
            }
            return errors;
        }
    }
}
