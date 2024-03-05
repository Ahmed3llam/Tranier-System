using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tranier_System.Models;

namespace Tranier_System.Controllers
{
    public class TraineeController : Controller
    {
        TContext db = new TContext();
        public IActionResult ShowResult(int id, int CrsId)
        {
            TraineeResultViewModel data=new TraineeResultViewModel();
            data.TraineeName = db.Trainee.Where(x => x.Id == id).Select(t => t.Name).SingleOrDefault().ToString();
            var Cdata = db.course.Where(x => x.Id == CrsId).FirstOrDefault();
            data.CourseName = Cdata.Name;
            data.MinDegree=Cdata.MinDegree;
            data.Degree= db.CrsResult.Where(x => x.TranieeId == id && x.CourseId == CrsId).Select(d => d.Degree).FirstOrDefault();
            //session
            HttpContext.Session.SetInt32("Degree", data.Degree);
            //data.Degree = HttpContext.Session.GetInt32("Degree").Value;

            data.Color = data.Degree >= 60 ? "Green" : "Red";
            
            return View("TraineeResult",data);
        }
    }
}
