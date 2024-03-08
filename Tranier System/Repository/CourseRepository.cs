using Tranier_System.Models;

namespace Tranier_System.Repository
{
    public class CourseRepository: ICourseRepository
    {
        TContext db;
        public CourseRepository(TContext db)
        {
            this.db = db;
        }
        public int Count()
        {
            return db.course.Count();
        }
        public List<Course> GetSome(int skip, int content)
        {
            return db.course.Skip(skip).Take(content).ToList();
        }
        public List<Course> GetAll()
        {
            return db.course.ToList();
        }
        public List<Course> GetForDepartment(int DeptId)
        {
            return db.course.Where(c=> c.DepartmentId == DeptId).ToList();
        }
        public Course Get(int id)
        {
            return db.course.FirstOrDefault(c=> c.Id == id);
        }
        public void Insert(Course course)
        {
            db.Add(course);
        }
        public void Update(Course course)
        {
            db.Update(course);
        }
        public void Delete(int id)
        {
            Course course = Get(id);
            db.Remove(course);
        }
        public int Save()
        {
            try
            {
                return db.SaveChanges();
            }
            catch(Exception ex)
            {
                return 0;
            }
        }
    }
}
