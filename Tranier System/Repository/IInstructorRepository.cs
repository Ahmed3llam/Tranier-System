using Tranier_System.Models;

namespace Tranier_System.Repository
{
    public interface IInstructorRepository
    {
        public int Count();
        public List<Instructor> GetAll();
        public List<Instructor> GetSome(int skip, int content);
        public List<Instructor> GetForDepartment(int DeptId);
        public List<Instructor> GetForCourse(int CourseId);
        public Instructor Get(int id);
        public void Insert(Instructor instructor);
        public void Update(Instructor instructor);
        public void Delete(int id);
        public int Save();
    }
}