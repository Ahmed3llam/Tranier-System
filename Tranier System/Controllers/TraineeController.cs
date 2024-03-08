using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tranier_System.Models;
using Tranier_System.Repository;

namespace Tranier_System.Controllers
{
    public class TraineeController : Controller
    {
        //TContext db = new TContext();
        ITraineeRepository traineeRepository;
        ICourseRepository courseRepository;
        ICrsResultRepository crsResultRepository;
        public TraineeController(ITraineeRepository traineeRepo, ICourseRepository crsrepo, ICrsResultRepository crsResultRepo)
        {
            traineeRepository = traineeRepo;
            courseRepository = crsrepo;
            crsResultRepository = crsResultRepo;
        }
        public IActionResult ShowResult(int id, int CrsId)
        {
            TraineeResultViewModel data=new TraineeResultViewModel();
            data.TraineeName = traineeRepository.GetName(id);
            var Cdata = courseRepository.Get(CrsId);
            data.CourseName = Cdata.Name;
            data.MinDegree=Cdata.MinDegree;
            data.Degree= crsResultRepository.GetDegreeForTrainee(id,CrsId);
            //session
            HttpContext.Session.SetInt32("Degree", data.Degree);
            //data.Degree = HttpContext.Session.GetInt32("Degree").Value;

            data.Color = data.Degree >= 60 ? "Green" : "Red";
            
            return View("TraineeResult",data);
        }
    }
}
