using StudentApp.Models;
using StudentApp.ViewModels;
using StudentApp.ViewModels.Student;
using System.ComponentModel.DataAnnotations;

namespace StudentApp.Utils.Student
{
    public class StudentMapper : IStudentMapper
    {
        public Models.Student ConvertAddStudentViewModelToStudent(AddStudentViewModel addStudentViewModel)
        {
            return new Models.Student
            {
                Nom = addStudentViewModel.Nom,
                Prenom = addStudentViewModel.Prenom,
                Cen = addStudentViewModel.Cen,
                Cin = addStudentViewModel.Cin,
                Tel = addStudentViewModel.Tel,
                Adresse = addStudentViewModel.Adresse,
                Email = addStudentViewModel.Email,
                Etat = addStudentViewModel.Etat,
                Cartier = addStudentViewModel.CartierId
            };
        }

        public StudentViewModel ConvertStudentToVM(Models.Student student)
        {
            try
            {
                var studentViewModel = new StudentViewModel
                {
                    IdStudent = student.IdStudent,
                    Nom = student.Nom,
                    Prenom = student.Prenom,
                    Cen = student.Cen,
                    Cin = student.Cin,
                    Tel = student.Tel,
                    Adresse = student.Adresse,
                    Email = student.Email,
                    Password = student.Password,
                    Etat = student.Etat,
                    Cartier = student.Cartier
                };
                return studentViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static UpdateStudentViewModel ConvertStudentToUpdateStudentViewModel(Models.Student student)
        {
            try
            {
                var studentViewModel = new UpdateStudentViewModel
                {
                    IdStudent = student.IdStudent,
                    Nom = student.Nom,
                    Prenom = student.Prenom,
                    Cen = student.Cen,
                    Cin = student.Cin,
                    Tel = student.Tel,
                    Adresse = student.Adresse,
                    Email = student.Email,
                    Password = student.Password,
                    Etat = student.Etat,
                    CartierId = student.Cartier
                };

                return studentViewModel;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
