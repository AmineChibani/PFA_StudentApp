namespace StudentApp.Utils.Student
{
    public class GeneratePassword
    {
        public static string GenererMotDePasse(int longueur)
        {
            const string caracteresPossibles = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789$-#&@=-_";
            Random random = new Random();

            char[] motDePasse = new char[longueur];
            for (int i = 0; i < longueur; i++)
            {
                motDePasse[i] = caracteresPossibles[random.Next(caracteresPossibles.Length)];
            }

            return new string(motDePasse);
        }
    }
}
