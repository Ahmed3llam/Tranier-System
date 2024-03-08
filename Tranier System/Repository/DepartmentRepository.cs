using Tranier_System.Models;

namespace Tranier_System.Repository
{
    public class DepartmentRepository: IDepartmentRepository
    {
        TContext db;
        public DepartmentRepository(TContext db)
        {
            this.db = db;
        }
        public int Count()
        {
            return db.Department.Count();
        }
        public List<Department> GetAll()
        {
            return db.Department.ToList();
        }
        public List<Department> GetSome(int skip, int content)
        {
            return db.Department.Skip(skip).Take(content).ToList();
        }
        public Department Get(int id)
        {
            return db.Department.FirstOrDefault(d => d.Id == id);
        }
        public void Insert(Department department)
        {
            db.Add(department);
        }
        public void Update(Department department)
        {
            db.Update(department);
        }
        public void Delete(int id)
        {
            Department department = Get(id);
            db.Remove(department);
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
