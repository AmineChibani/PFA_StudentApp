using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using StudentApp.Models;
using StudentApp.Repository.Abonnement;
using StudentApp.Repository.Student;
using StudentApp.ViewModels.Abonnement;

namespace StudentApp.Controllers
{
    public class AbonnementController : Controller
    {
        private readonly IAbonnementRepository _abonnementRepository;
        private readonly IStudentRepository _studentRepository;


        public AbonnementController(IAbonnementRepository abonnementRepository, IStudentRepository studentRepository)
        {
            _abonnementRepository = abonnementRepository;
            _studentRepository = studentRepository;
        }



        public IActionResult Abonnement()
        {
            // Fetch abonnements with associated students
            IList<Abonnement> abonnementList = _abonnementRepository.GetAllAbonnementWithStudents();

            // Fetch students
            IList<Student> studentList = _studentRepository.GetAllStudents();

            // Convert student list to SelectListItem list
            IList<SelectListItem> studentItems = studentList
                .Select(s => new SelectListItem
                {
                    Value = s.IdStudent.ToString(),
                    Text = s.Prenom
                })
                .ToList();

            // Set ViewBag for students
            ViewBag.Students = studentItems;

            // Fetch lines from API
            List<LineVM> lines = FetchLinesFromAPI();

            // Set ViewBag for lines
            ViewBag.Lines = lines;

            // Pass abonnementList to the partial view
            return PartialView("_AbonnementPartial", abonnementList);
        }




        public IActionResult AddAbonnement()
        {
            //get student data base
            var students = _studentRepository.GetAllStudents();
            ViewData["StudentId"] = new SelectList(students, "IdStudent", "Nom");
            //get ligne api
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
                        // Handle API call failure
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception
                }
            }

            return lines;
        }
    }
}

