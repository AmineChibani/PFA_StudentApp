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
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IStudentMapper _studentMapper;
        private readonly ICartierRepository _cartierRepository;

        public StudentController(IStudentRepository studentRepository, IStudentMapper studentMapper, ICartierRepository cartierRepository)
        {
            _studentMapper = studentMapper;
            _studentRepository = studentRepository;
            _cartierRepository = cartierRepository;
        }
        public IActionResult Index()
        {
            IList<Student> studentList = _studentRepository.GetAllStudents();

            IList<SelectListItem> cartierList = _cartierRepository.GetCartierList()
                .Select(c => new SelectListItem
                {
                    Value = c.Id.ToString(),
                    Text = c.Libelle
                }).ToList();

            ViewBag.Cartier = cartierList;

            return View(studentList);
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
    }
}
