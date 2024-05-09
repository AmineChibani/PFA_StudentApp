using StudentApp.Models;
using StudentApp.ViewModels;
using StudentApp.ViewModels.Student;

namespace StudentApp.Utils.Student
{
    public interface IStudentMapper
    {
        public StudentViewModel ConvertStudentToVM(Models.Student student);
        public Models.Student ConvertAddStudentViewModelToStudent(AddStudentViewModel addStudentViewModel);
    }
}
