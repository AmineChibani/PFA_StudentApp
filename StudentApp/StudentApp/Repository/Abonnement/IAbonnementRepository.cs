using StudentApp.Models;
namespace StudentApp.Repository.Abonnement
{
    public interface IAbonnementRepository
    {
        IList<Models.Abonnement> GetAllAbonnement();
        public Models.Abonnement GetAbonnementById(int id);
        public bool AddAbonnement(Models.Abonnement abonnement);
        public bool UpdateAbonnement(Models.Abonnement abonnementEdited);
        public bool DeleteAbonnement(int id);
    }
}
