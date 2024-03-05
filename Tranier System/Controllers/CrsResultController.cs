using Microsoft.AspNetCore.Mvc;
using Tranier_System.Models;

namespace Tranier_System.Controllers
{
    public class CrsResultController : Controller
    {
        TContext db = new TContext();
        public IActionResult CourceResult(int id)
        {
            var results = db.CrsResult.Where(i => i.CourseId == id).
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
            var results = db.CrsResult.Where(i => i.TranieeId == id).
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
