using Tranier_System.Models;

namespace Tranier_System.Repository
{
    public interface ICourseRepository
    {
        public int Count();
        public List<Course> GetSome(int skip, int content);
        public List<Course> GetAll();
        public List<Course> GetForDepartment(int DeptId);
        public Course Get(int id);
        public void Insert(Course course);
        public void Update(Course course);
        public void Delete(int id);
        public int Save();
    }
}