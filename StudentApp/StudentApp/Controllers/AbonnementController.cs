using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StudentApp.Filters;
using StudentApp.Models;
using StudentApp.Repository.Abonnement;
using StudentApp.Repository.Student;
using StudentApp.ViewModels.Abonnement;

namespace StudentApp.Controllers
{
    [Isconnected]
    public class AbonnementController : Controller
    {
        private readonly IAbonnementRepository _abonnementRepository;
        private readonly IStudentRepository _studentRepository;


        public AbonnementController(IAbonnementRepository abonnementRepository, IStudentRepository studentRepository)
        {
            _abonnementRepository = abonnementRepository;
            _studentRepository = studentRepository;
        }



        public IActionResult Index()
        {
            IList<Abonnement> abonnementList = _abonnementRepository.GetAllAbonnementWithStudents();

            IList<Student> studentList = _studentRepository.GetAllStudents();

            IList<SelectListItem> studentItems = studentList
                .Select(s => new SelectListItem
                {
                    Value = s.IdStudent.ToString(),
                    Text = s.Prenom
                })
                .ToList();

            ViewBag.Students = studentItems;

            List<LineVM> lines = FetchLinesFromAPI();
            ViewBag.Lines = lines;
            return View( abonnementList);
        }




        public IActionResult AddAbonnement()
        {
            var students = _studentRepository.GetAllStudents();
            ViewData["StudentId"] = new SelectList(students, "IdStudent", "Nom");
            string apiUrl = "https://lyfytech.com/APIScanner/listline.php";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        List<LineVM> lines = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LineVM>>(apiResponse);
                        ViewBag.Lines = lines;
                        return PartialView("_AddAbonnementPartial");
                    }
                    else
                    {
                        return View("Error");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    return View("Error");
                }
            }
        }

        [HttpPost]
        public IActionResult AddAbonnement(Abonnement abonnement)
        {
            abonnement.DateDeCreation = DateTime.Now;

            try
            {
                bool success = _abonnementRepository.AddAbonnement(abonnement);

                if (success)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to add subscription" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "An error occurred while adding the subscription" });
            }
        }

        private List<LineVM> FetchLinesFromAPI()
        {
            string apiUrl = "https://lyfytech.com/APIScanner/listline.php";
            List<LineVM> lines = new List<LineVM>();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = response.Content.ReadAsStringAsync().Result;
                        lines = JsonConvert.DeserializeObject<List<LineVM>>(apiResponse);
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                }
            }

            return lines;
        }
    }
}

