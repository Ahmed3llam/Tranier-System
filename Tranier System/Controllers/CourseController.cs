using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tranier_System.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Tranier_System.Controllers
{
    public class CourseController : Controller
    {
        TContext db = new TContext();

        public IActionResult CheckMinDegree(int MinDegree,int Degree)
        {
            if (MinDegree < Degree)
                return Json(true);
            return Json(false);
        }
        public IActionResult Index(int page=1)
        {
            int content = 3;
            int skip = (page - 1) * content;
            List<Course> courses = db.course.Skip(skip).Take(content).ToList();
            int totalCourses = db.course.Count();
            ViewData["Page"] = page;
            ViewData["content"] = content;
            ViewData["TotalItems"] = totalCourses;
            //List<Course> Course = db.course.ToList();
            ViewData["Deps"] = db.Department.ToList();
            return View("Index", courses);
        }
        public IActionResult Details(int id)
        {
            Course crs = db.course.SingleOrDefault(i => i.Id == id);
            ViewData["Dept"] = db.Department.SingleOrDefault(i=>i.Id==crs.DepartmentId);
            return View("Details", crs);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Deps"] = db.Department.ToList();
            return View("Add");
        }
        [HttpPost]
        public IActionResult Add(Course crs)
        {
            if (ModelState.IsValid == true)
            {
                db.Add(crs);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewData["Deps"] = db.Department.ToList();
            return View("Add");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Deps"] = db.Department.ToList();
            Course data = db.course.SingleOrDefault(c => c.Id == id);
            return View("Edit",data);
        }
        [HttpPost]
        public IActionResult Edit(Course crs)
        {
            if (ModelState.IsValid == true)
            {
                db.Update(crs);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewData["Deps"] = db.Department.ToList();
            return View("Edit");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Course crs = db.course.SingleOrDefault(c => c.Id == id);
            return View("Delete", crs);
        }
        [HttpPost]
        public IActionResult Delete(Course crs)
        {
            if (crs == null)
            {
                return NotFound();
            }
            db.Remove(crs);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
