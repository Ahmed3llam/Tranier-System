using Tranier_System.Models;

namespace Tranier_System.Repository
{
    public class CrsResultRepository: ICrsResultRepository
    {
        TContext db;
        public CrsResultRepository(TContext db)
        {
            this.db = db;
        }
        public int Count()
        {
            return db.CrsResult.Count();
        }
        public List<CrsResult> GetAll()
        {
            return db.CrsResult.ToList();
        }
        public List<CrsResult> GetSome(int skip, int content)
        {
            return db.CrsResult.Skip(skip).Take(content).ToList();
        }
        public List<CrsResult> GetForTrainee(int TraineeId)
        {
            return db.CrsResult.Where(c => c.TranieeId == TraineeId).ToList();
        }
        public List<CrsResult> GetForCourse(int CourseId)
        {
            return db.CrsResult.Where(c => c.CourseId == CourseId).ToList();
        }
        public int GetDegreeForTrainee(int TraineeId,int CrsId)
        {
            return db.CrsResult.Where(x => x.TranieeId == TraineeId && x.CourseId == CrsId).Select(d => d.Degree).FirstOrDefault();
        }
        public CrsResult Get(int id)
        {
            return db.CrsResult.FirstOrDefault(i => i.Id == id);
        }
        public void Insert(CrsResult crsResult)
        {
            db.Add(crsResult);
        }
        public void Update(CrsResult crsResult)
        {
            db.Update(crsResult);
        }
        public void Delete(int id)
        {
            CrsResult crsResult = Get(id);
            db.Remove(crsResult);
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
