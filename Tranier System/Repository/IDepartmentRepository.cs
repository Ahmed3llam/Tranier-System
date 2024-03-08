using Tranier_System.Models;

namespace Tranier_System.Repository
{
    public interface IDepartmentRepository
    {
        public int Count();
        public List<Department> GetAll();
        public List<Department> GetSome(int skip, int content);
        public Department Get(int id);
        public void Insert(Department department);
        public void Update(Department department);
        public void Delete(int id);
        public int Save();
    }
}