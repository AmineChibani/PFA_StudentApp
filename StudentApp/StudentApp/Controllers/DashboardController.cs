using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using StudentApp.Repository.Abonnement;
using StudentApp.Repository.Cartier;
using StudentApp.Repository.Student;
using StudentApp.Utils.Student;
using StudentApp.ViewModels;
using StudentApp.ViewModels.Abonnement;
using StudentApp.ViewModels.Student;
using System.Runtime.ConstrainedExecution;

namespace StudentApp.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentMapper _studentMapper;
        private readonly ICartierRepository _cartierRepository;
        private readonly IAbonnementRepository _abonnementRepository;

        public DashboardController(IStudentRepository studentRepository, IStudentMapper studentMapper, ICartierRepository cartierRepository, IAbonnementRepository abonnementRepository)
        {
            _studentMapper = studentMapper;
            _studentRepository = studentRepository;
            _cartierRepository = cartierRepository;
            _abonnementRepository = abonnementRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Student()
        {
            IList<Student> studentList = _studentRepository.GetAllStudents();

            IList<SelectListItem> cartierList = _cartierRepository.GetCartierList()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(), 
                    Text = c.Libelle 
                }).ToList();

            ViewBag.Cartier = cartierList;

            return PartialView("_StudentPartial", studentList);
        }


        [HttpPost]
        public IActionResult AddStudent(string Nom, string Prenom, string Cen, string Cin, string Tel, string Adresse, string Email, string CartierId)
        {
            Student newStudent = new Student();
            newStudent.Etat = true;
            newStudent.CreationDate = DateTime.Now;
            newStudent.Nom = Nom;
            newStudent.Prenom = Prenom;
            newStudent.Cen = Cen;
            newStudent.Cin = Cin;
            newStudent.Tel = Tel;
            newStudent.Adresse = Adresse;
            newStudent.Email = Email;
            if (CartierId != null)
            {
                newStudent.Cartier = int.Parse(CartierId);
            }

            

            IList<int> errors = VerificationStudent.VerificationStudentPatterns(newStudent);

            if(errors.Count == 0)
            {
                newStudent.Password = GeneratePassword.GenererMotDePasse(10);
                if (_studentRepository.AddStudent(newStudent))
                {
                    return Json(new { success = true });
                }
            }

            return Json(new { success = false, Errors = errors });
        }

        [HttpGet]
        public IActionResult GetStudentById(int studentId)
        {
            Student student = _studentRepository.GetStudentById(studentId);

            if (student != null)
            {
                //return Json(new { success = false, IdStudent = student.IdStudent, Nom= student.Nom, Prenom= student.Prenom, Cen= student.Cen, Cin= student.Cin, Tel= student.Tel, Adresse= student.Adresse, Email= student.Email, Password= student.Password, Etat= student.Etat, CartierId= student.Cartier });
                return Json(new { success = true, student });
            }

            return Json(new { success = false }); 
        }

        [HttpPost]
        public IActionResult EditStudent(int studentId, string Nom, string Prenom, string Cen, string Cin, string Tel, string Adresse, string Email, string CartierId)
        {
            var existingStudent = _studentRepository.GetStudentById(studentId);
            if (existingStudent == null)
            {
                return NotFound();
            }

       
            existingStudent.Nom = Nom;
            existingStudent.Prenom = Prenom;
            existingStudent.Cen = Cen;
            existingStudent.Cin = Cin;
            existingStudent.Tel = Tel;
            existingStudent.Adresse = Adresse;
            existingStudent.Email = Email;
            if (CartierId != null)
            {
                existingStudent.Cartier = int.Parse(CartierId);
            }

            IList<int> errors = VerificationStudent.VerificationStudentPatterns(existingStudent);

            if (errors.Count == 0)
            {
                if (_studentRepository.UpdateStudent(existingStudent))
                {
                    return Json(new { success = true });
                }
            }

            return Json(new { success = false, Errors = errors });
        }

        [HttpPost]
        public IActionResult DeleteStudent(int studentId)
        {
            try
            {
                // Assuming _studentRepository is your repository instance
                var success = _studentRepository.DeleteStudent(studentId);
                if (success)
                {
                    return Json(new { success = true });
                }
                else
                {
                    return Json(new { success = false, message = "Failed to delete student" });
                }
            }
            catch (Exception ex)
            {
                // Log the exception
                return Json(new { success = false, message = "An error occurred while deleting the student" });
            }
        }



        public IActionResult Abonnement()
        {
            IList<Abonnement> abonnmentList = _abonnementRepository.GetAllAbonnement();
            return PartialView("_AbonnementPartial", abonnmentList);
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


        public IActionResult Historique()
        {
            return PartialView("_HistoriquePartial");
        }

        public IActionResult Publisher()
        {
            return PartialView("_PublisherPartial");
        }

        public IActionResult Campaing()
        {
            return PartialView("_CampaignPartial");
        }
    }
}
