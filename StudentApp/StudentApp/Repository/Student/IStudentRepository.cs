using StudentApp.Models;
using StudentApp.ViewModels;

namespace StudentApp.Repository.Student
{
    public interface IStudentRepository
    {
        IList<@Models.Student> GetAllStudents();
        public @Models.Student GetStudentById(int id);
        public bool AddStudent(@Models.Student student);
        public bool UpdateStudent(@Models.Student studentEdited);
        public bool DeleteStudent(int id);
    }
}
