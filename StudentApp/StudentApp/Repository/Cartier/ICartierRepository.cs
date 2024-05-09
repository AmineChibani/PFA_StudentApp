using Microsoft.AspNetCore.Mvc.Rendering;
using StudentApp.Models;

namespace StudentApp.Repository.Cartier
{
    public interface ICartierRepository
    {
        IList<Models.Cartier> GetCartierList();
    }
}
