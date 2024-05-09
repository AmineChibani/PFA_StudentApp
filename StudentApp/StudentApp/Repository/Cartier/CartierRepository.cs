// CartierRepository.cs
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering; // Add this namespace
using StudentApp.Models;

namespace StudentApp.Repository.Cartier
{
    public class CartierRepository : ICartierRepository
    {
        private readonly U669885128UZsNtContext _u669885128UZsNtContext;

        public CartierRepository(U669885128UZsNtContext u669885128UZsNtContext)
        {
            _u669885128UZsNtContext = u669885128UZsNtContext;
        }

        public IList<@Models.Cartier> GetCartierList()
        {
            // Convert the list of Cartier objects to a list of SelectListItem objects
            return _u669885128UZsNtContext.Cartiers.ToList();


        }
    }
}
