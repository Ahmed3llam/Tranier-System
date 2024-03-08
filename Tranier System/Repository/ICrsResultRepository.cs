using Tranier_System.Models;

namespace Tranier_System.Repository
{
    public interface ICrsResultRepository
    {
        public int Count();
        public List<CrsResult> GetAll();
        public List<CrsResult> GetSome(int skip, int content);
        public List<CrsResult> GetForTrainee(int TraineeId);
        public List<CrsResult> GetForCourse(int CourseId);
        public int GetDegreeForTrainee(int TraineeId, int CrsId);
        public CrsResult Get(int id);
        public void Insert(CrsResult crsResult);
        public void Update(CrsResult crsResult);
        public void Delete(int id);
        public int Save();
    }
}