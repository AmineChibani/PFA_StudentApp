
using System.IO;

namespace StudentApp.MyClasses
{
    public class VerificationImage
    {
        private static string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".gif" };

        public static string VerifierImage(IFormFile Photo, string fileName)
        {
            if (Photo.Length > 0)
            {
                // genere un nom Crepter
                //string fileName = $"{DateTime.Now:yyyyMMddHHmmss}-{"@@"}-{Photo.Length}-{Photo.FileName}";

                // Spécification du chemin du dossier où enregistrer les images
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads/userImages");

                // Vérification et création du dossier s'il n'existe pas
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Chemin complet du fichier sur le serveur
                string filePath = Path.Combine(uploadPath, fileName);
               
                string fileExtension = Path.GetExtension(filePath).ToLower();

                if (allowedExtensions.Contains(fileExtension))
                {
                    // Enregistrement du fichier sur le serveur
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Photo.CopyTo(fileStream);
                    }
                    return "true";
                }

                return  "Le fichier n'est pas une image valide.";
            }
            else
            {
                return  "uploder une image valide.";
            }
        }

        public static string VerifierCover(IFormFile Photo, string fileName)
        {
            if (Photo.Length > 0)
            {
                // genere un nom Crepter
                //string fileName = $"{DateTime.Now:yyyyMMddHHmmss}-{"@@"}-{Photo.Length}-{Photo.FileName}";

                // Spécification du chemin du dossier où enregistrer les images
                string uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads/userCovers");

                // Vérification et création du dossier s'il n'existe pas
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }

                // Chemin complet du fichier sur le serveur
                string filePath = Path.Combine(uploadPath, fileName);

                string fileExtension = Path.GetExtension(filePath).ToLower();

                if (allowedExtensions.Contains(fileExtension))
                {
                    // Enregistrement du fichier sur le serveur
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        Photo.CopyTo(fileStream);
                    }
                    return "true";
                }

                return "Le fichier n'est pas une image valide.";
            }
            else
            {
                return "uploder une image valide.";
            }
        }

        public static bool UpdateImage(string path)
        {
            if (path != "artisan.png")
            {
                string filePathToDelete = "C:\\Users\\MO KADI\\Desktop\\PFA__Project\\wwwroot\\uploads\\userImages\\" + path;
                if (File.Exists(filePathToDelete))
                {
                    File.Delete(filePathToDelete);
                    return true;
                }
            }
            return false;
        }

    }
}
