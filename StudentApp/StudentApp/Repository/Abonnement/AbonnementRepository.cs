
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;

namespace StudentApp.Repository.Abonnement
{
    public class AbonnementRepository : IAbonnementRepository
    {
        private readonly U669885128UZsNtContext _u669885128UZsNtContext;
        public AbonnementRepository(U669885128UZsNtContext u669885128UZsNtContext)
        {
            _u669885128UZsNtContext = u669885128UZsNtContext;
        }
       public bool AddAbonnement(Models.Abonnement abonnement)
        {
            try
            {
                _u669885128UZsNtContext.Abonnements.Add(abonnement);
                _u669885128UZsNtContext.SaveChanges();
                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool DeleteAbonnement(int id)
        {
            try
            {
                Models.Abonnement? abonnementToRemove = _u669885128UZsNtContext.Abonnements.Find(id);

                if(abonnementToRemove != null)
                {
                    _u669885128UZsNtContext.Abonnements.Remove(abonnementToRemove);
                    _u669885128UZsNtContext.SaveChanges();
                    return true;
                }
                return false;
            }catch(Exception ex)
            {
                return false;
            }
        }

        public Models.Abonnement GetAbonnementById(int id)
        {
            return _u669885128UZsNtContext.Abonnements.Find(id);
        }

        public IList<Models.Abonnement> GetAllAbonnementWithStudents()
        {
            return _u669885128UZsNtContext.Abonnements
                .Include(a => a.AbonnementLignes)
                .Include(a => a.Student)
                .ToList();
        }

        public bool UpdateAbonnement(Models.Abonnement abonnementEdited)
        {
            try
            {
                _u669885128UZsNtContext.Attach(abonnementEdited);
                _u669885128UZsNtContext.Entry(abonnementEdited).State = EntityState.Modified;
                return true;

            }catch(Exception ex)
            {
                return false;
            }
        }
    }
}
