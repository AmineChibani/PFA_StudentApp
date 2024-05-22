using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentApp.Filters;
using StudentApp.Models;
using StudentApp.Utils.Publisher;
using StudentApp.Utils.Student;
using System.Security.Policy;
using Publisher = StudentApp.Models.Publisher;

namespace StudentApp.Controllers
{
    [Isconnected]
    public class PublisherController : Controller
    {
        private readonly U669885128UZsNtContext _context;
        public PublisherController(U669885128UZsNtContext context)
        {
            this._context = context;
        }
        public IActionResult Index()
        {
            IList<Publisher> publisherList = _context.Publishers.ToList();
            return PartialView(publisherList);
        }


        [HttpPost]
        public IActionResult AddPublisher(string Nom, string Contact,string Tel)
        {
            Publisher newpublisher = new Publisher();
            newpublisher.Telephone = Tel;
            newpublisher.Contact = Contact;
            newpublisher.Name = Nom;

            
            IList<int> errors = VerificationPublisher.VerificationPublisherPatterns(newpublisher);

            if (errors.Count == 0)
            {
                _context.Publishers.Add(newpublisher);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            
            return Json(new { success = false, Errors = errors });
        }

        [HttpGet]
        public IActionResult GetPulisherById(int PublisherId)
        {
            Publisher publisher = _context.Publishers.FirstOrDefault(p => p.Id == PublisherId);

            if (publisher != null)
            {
                return Json(new { success = true, publisher });
            }

            return Json(new { success = false });
        }


        [HttpPost]
        public IActionResult EditPublisher(int PublisherId, string Nom, string Contact, string Tel)
        {
            var existPublisher = _context.Publishers.FirstOrDefault(p => p.Id == PublisherId);
            if (existPublisher == null)
            {
                return NotFound();
            }


            existPublisher.Name = Nom;
            existPublisher.Contact = Contact;
            existPublisher.Telephone = Tel;


            IList<int> errors = VerificationPublisher.VerificationPublisherPatterns(existPublisher);

            if (errors.Count == 0)
            {

                _context.SaveChanges();
                return Json(new { success = true });
                
            }

            return Json(new { success = false, Errors = errors });
        }


        [HttpPost]
        public IActionResult DeletePublisher(int PublisherId)
        {
            var existPublisher = _context.Publishers.FirstOrDefault(p => p.Id == PublisherId);
            if (existPublisher == null)
            {
                return Json(new { success = false,message = "Publisher nexist pas !!" });
            }
            _context.Publishers.Remove(existPublisher);
            _context.SaveChanges();
            return Json(new { success = true });
        }

        



    }
}
