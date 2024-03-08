using Microsoft.AspNetCore.Mvc;
using Tranier_System.Models;
using Tranier_System.Repository;

namespace Tranier_System.Controllers
{
    public class CrsResultController : Controller
    {
        //TContext db = new TContext();
        ICrsResultRepository CrsResultRepository;
        public CrsResultController(ICrsResultRepository CrsResultRepo)
        {
            CrsResultRepository = CrsResultRepo;
        }
        public IActionResult CourceResult(int id)
        {
            var results = CrsResultRepository.GetForCourse(id).
                Select(c => new TraineeResultViewModel
                {
                    TraineeName = c.Trainee.Name,
                    CourseName = c.Course.Name,
                    Degree = c.Degree,
                    MinDegree = c.Course.MinDegree
                }).ToList();
            foreach (var result in results)
            {
                result.Color = result.Degree >= result.MinDegree ? "green" : "red";
            }
            return View("CourceResult", results);
        }
        public IActionResult TraineeResult(int id)
        {
            var results = CrsResultRepository.GetForTrainee(id).
                Select(c => new TraineeResultViewModel { 
                    TraineeName = c.Trainee.Name, 
                    CourseName = c.Course.Name, 
                    Degree = c.Degree, 
                    MinDegree = c.Course.MinDegree 
                }).ToList();
            foreach (var result in results)
            {
                result.Color=result.Degree >= result.MinDegree ? "green" : "red";
            }
            return View("TraineeResult", results);
        }
    }
}
