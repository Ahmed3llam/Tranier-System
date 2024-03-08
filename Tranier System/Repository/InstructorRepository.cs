using Tranier_System.Models;

namespace Tranier_System.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        TContext db;
        public InstructorRepository(TContext db)
        {
            this.db = db;
        }
        public int Count()
        {
            return db.Instructor.Count();
        }
        public List<Instructor> GetAll()
        {
            return db.Instructor.ToList();
        }
        public List<Instructor> GetSome(int skip,int content)
        {
            return db.Instructor.Skip(skip).Take(content).ToList();
        }
        public List<Instructor> GetForDepartment(int DeptId)
        {
            return db.Instructor.Where(i => i.DepartmentId == DeptId).ToList();
        }
        public List<Instructor> GetForCourse(int CourseId)
        {
            return db.Instructor.Where(i => i.CourseId == CourseId).ToList();
        }
        public Instructor Get(int id)
        {
            return db.Instructor.FirstOrDefault(i => i.Id == id);
        }
        public void Insert(Instructor instructor)
        {
            db.Add(instructor);
        }
        public void Update(Instructor instructor)
        {
            db.Update(instructor);
        }
        public void Delete(int id)
        {
            Instructor instructor = Get(id);
            db.Remove(instructor);
        }
        public int Save()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
