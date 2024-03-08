using Tranier_System.Models;

namespace Tranier_System.Repository
{
    public class TraineeRepository: ITraineeRepository
    {
        TContext db;
        public TraineeRepository(TContext db)
        {
            this.db = db;
        }
        public int Count()
        {
            return db.Trainee.Count();
        }
        public List<Trainee> GetAll()
        {
            return db.Trainee.ToList();
        }
        public List<Trainee> GetSome(int skip, int content)
        {
            return db.Trainee.Skip(skip).Take(content).ToList();
        }
        public List<Trainee> GetForDepartment(int DeptId)
        {
            return db.Trainee.Where(t => t.DepartmentId == DeptId).ToList();
        }
        public Trainee Get(int id)
        {
            return db.Trainee.FirstOrDefault(i => i.Id == id);
        }
        public string GetName(int id)
        {
            return db.Trainee.Where(x => x.Id == id).Select(t => t.Name).SingleOrDefault().ToString();
        }
        public void Insert(Trainee trainee)
        {
            db.Add(trainee);
        }
        public void Update(Trainee trainee)
        {
            db.Update(trainee);
        }
        public void Delete(int id)
        {
            Trainee trainee = Get(id);
            db.Remove(trainee);
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
