using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tranier_System.Models;
using Tranier_System.Repository;
using static System.Net.Mime.MediaTypeNames;

namespace Tranier_System.Controllers
{
    public class CourseController : Controller
    {
        //TContext db = new TContext();
        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;
        public CourseController(ICourseRepository crsrepo, IDepartmentRepository deptrepo)
        {
            courseRepository = crsrepo;
            departmentRepository = deptrepo;
        }
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
            List<Course> courses = courseRepository.GetSome(skip,content);
            int totalCourses = courseRepository.Count();
            ViewData["Page"] = page;
            ViewData["content"] = content;
            ViewData["TotalItems"] = totalCourses;
            ViewData["Deps"] = departmentRepository.GetAll();
            return View("Index", courses);
        }
        public IActionResult Details(int id)
        {
            Course crs =courseRepository.Get(id);
            ViewData["Dept"] = departmentRepository.Get(crs.DepartmentId);
            return View("Details", crs);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewData["Deps"] = departmentRepository.GetAll();
            return View("Add");
        }
        [HttpPost]
        public IActionResult Add(Course crs)
        {
            if (ModelState.IsValid == true)
            {
                courseRepository.Insert(crs);
                courseRepository.Save();
                //db.Add(crs);
                //db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewData["Deps"] = departmentRepository.GetAll();
            return View("Add");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Deps"] = departmentRepository.GetAll();
            Course data = courseRepository.Get(id);
            return View("Edit",data);
        }
        [HttpPost]
        public IActionResult Edit(Course crs)
        {
            if (ModelState.IsValid == true)
            {
                courseRepository.Update(crs);
                courseRepository.Save();
                //db.Update(crs);
                //db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewData["Deps"] = departmentRepository.GetAll();
            return View("Edit");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Course crs = courseRepository.Get(id);
            return View("Delete", crs);
        }
        [HttpPost]
        public IActionResult Delete(Course crs)
        {
            if (crs == null)
            {
                return NotFound();
            }
            courseRepository.Delete(crs.Id);
            courseRepository.Save();
            //db.Remove(crs);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
