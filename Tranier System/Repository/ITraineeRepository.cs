using Tranier_System.Models;

namespace Tranier_System.Repository
{
    public interface ITraineeRepository
    {
        public int Count();
        public List<Trainee> GetAll();
        public List<Trainee> GetSome(int skip, int content);
        public List<Trainee> GetForDepartment(int DeptId);
        public Trainee Get(int id);
        public string GetName(int id);
        public void Insert(Trainee trainee);
        public void Update(Trainee trainee);
        public void Delete(int id);
        public int Save();
    }
}