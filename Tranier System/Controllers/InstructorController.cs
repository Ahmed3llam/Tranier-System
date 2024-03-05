using Microsoft.AspNetCore.Mvc;
using Tranier_System.Models;

namespace Tranier_System.Controllers
{
    public class InstructorController : Controller
    {
        TContext db= new TContext();
        //int count;
        //public InstructorController()
        //{
        //    count = 0;
        //}
        public IActionResult Index()
        {
            //count++;
            //HttpContext.Session.SetString("","");
            //HttpContext.Response.Cookies.Append("","");
            //CookieOptions options = new CookieOptions();
            //options.Expires = DateTime.Now.AddDays(2);
            //Response.Cookies.Append("", "",options);
            //var instructorsModel = db.Instructor.Select(i=> new {i.Id,i.Name,i.Image,i.Salary,i.Address,Department = i.Department.Name,Course = i.Course.Name }).ToList();
            List<Instructor> instructors = db.Instructor.ToList();
            
            return View("Index",instructors);
        }
        public IActionResult Details(int id)
        {
            //string? n=Request.Cookies[""];
            Instructor instructor = db.Instructor.SingleOrDefault(i=>i.Id==id);
            return View("Details", instructor);
        }
        public IActionResult Add()
        {
            InstDeptVM data = new InstDeptVM();
            data.Depts=db.Department.ToList();
            data.Courses=db.course.ToList();
            return View("AddInstructor",data);
        }
        [HttpPost]
        public IActionResult SaveAdd(InstDeptVM ins,IFormFile Image)
        {
            if(ins.Name !=null && ins.Address != null && ins.Salary != null && ins.DepartmentId != null && ins.CourseId != null) {
                if(Image.Length > 0)
                {
                    string FileName =  Guid.NewGuid().ToString()  + "_" +Path.GetFileName(Image.FileName) ;
                    string path = $"wwwroot/images/{FileName}";
                    FileStream fs = new FileStream(path, FileMode.Create);
                    Image.CopyTo(fs);
                    ins.Image= FileName;
                }
                Instructor Newins=new Instructor()
                {
                    Name=ins.Name,
                    Address=ins.Address,
                    Salary=ins.Salary,
                    DepartmentId=ins.DepartmentId,
                    CourseId=ins.CourseId,
                    Image=ins.Image,
                };
                db.Add(Newins);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            ins.Depts=db.Department.ToList();
            ins.Courses = db.course.ToList();
            return View("AddInstructor", ins);
        }
    }
}
