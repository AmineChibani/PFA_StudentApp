using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using StudentApp.Utils.Student;
using StudentApp.ViewModels;

namespace StudentApp.Repository.Student
{
    public class StudentRepository : IStudentRepository
    {
        private readonly U669885128UZsNtContext _U669885128UZsNtContext;
        private readonly IStudentMapper _StudentMapper;
        public StudentRepository(U669885128UZsNtContext U669885128UZsNtContext, IStudentMapper studentMapper)
        {
            _U669885128UZsNtContext = U669885128UZsNtContext;
            _StudentMapper = studentMapper;

        }


        public bool AddStudent(@Models.Student student)
        {
            try
            {
                _U669885128UZsNtContext.Students.Add(student);
                _U669885128UZsNtContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public bool DeleteStudent(int id)
        {
            try
            {
                @Models.Student? studentToRemove = _U669885128UZsNtContext.Students.Find(id);

                if (studentToRemove != null)
                {
                    _U669885128UZsNtContext.Students.Remove(studentToRemove);
                    _U669885128UZsNtContext.SaveChanges();

                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public IList<@Models.Student> GetAllStudents()
        {
            return _U669885128UZsNtContext.Students.Include(s => s.CartierNavigation).ToList();
        }

        public @Models.Student GetStudentById(int id)
        {
            return _U669885128UZsNtContext.Students.Find(id);
        }

        public bool UpdateStudent(@Models.Student studentEdited)
        {
            try
            {
                _U669885128UZsNtContext.Attach(studentEdited);
                _U669885128UZsNtContext.Entry(studentEdited).State = EntityState.Modified;
                _U669885128UZsNtContext.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
