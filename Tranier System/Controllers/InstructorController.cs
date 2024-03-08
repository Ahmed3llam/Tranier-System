using Microsoft.AspNetCore.Mvc;
using Tranier_System.Models;
using Tranier_System.Repository;

namespace Tranier_System.Controllers
{
    public class InstructorController : Controller
    {
        //TContext db= new TContext();
        IInstructorRepository instructorRepository;
        ICourseRepository courseRepository;
        IDepartmentRepository departmentRepository;
        public InstructorController(IInstructorRepository insrepo,ICourseRepository crsrepo,IDepartmentRepository deptrepo)
        {
            instructorRepository = insrepo;
            courseRepository = crsrepo;
            departmentRepository = deptrepo;
        }
        public IActionResult Index(int page=1)
        {
            int content = 3;
            int skip = (page - 1) * content;
            List<Instructor> instructors = instructorRepository.GetSome(skip,content);
            int totalInstructors = instructorRepository.Count();
            ViewData["Page"] = page;
            ViewData["content"] = content;
            ViewData["TotalItems"] = totalInstructors;
            return View("Index",instructors);
        }
        public IActionResult Details(int id)
        {
            Instructor instructor = instructorRepository.Get(id);
            return View("Details", instructor);
        }
        public IActionResult Add()
        {
            InstDeptVM data = new InstDeptVM();
            data.Depts=departmentRepository.GetAll();
            data.Courses=courseRepository.GetAll();
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
                instructorRepository.Update(Newins);
                instructorRepository.Save();
                //db.Add(Newins);
                //db.SaveChanges();
                return RedirectToAction("Index");
                
            }
            ins.Depts=departmentRepository.GetAll();
            ins.Courses = courseRepository.GetAll();
            return View("AddInstructor", ins);
        }
        public IActionResult Deps()
        {
            List<Department> deps = departmentRepository.GetAll();
            return Json(deps);
        }
        public IActionResult CrsInDeps(int id)
        {
            List<Course> crs = courseRepository.GetForDepartment(id);
            return Json(crs);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["Deps"] = departmentRepository.GetAll();
            Course data = courseRepository.Get(id);
            return View("Edit", data);
        }
        [HttpPost]
        public IActionResult Edit(Instructor ins, IFormFile Image)
        {
            if (ins.Name != null && ins.Address != null && ins.Salary != null && ins.DepartmentId != null && ins.CourseId != null)
            {
                if (Image.Length > 0)
                {
                    string FileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(Image.FileName);
                    string path = $"wwwroot/images/{FileName}";
                    FileStream fs = new FileStream(path, FileMode.Create);
                    Image.CopyTo(fs);
                    ins.Image = FileName;
                }
                instructorRepository.Update(ins);
                instructorRepository.Save();
                //db.Update(ins);
                //db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewData["Deps"] = departmentRepository.GetAll();
            return PartialView("_DataPartial",ins);
        }
        public IActionResult DataPartial(int id)
        {
            Instructor instructor =instructorRepository.Get(id);
            return PartialView("_DataPartial", instructor);
        }
        public IActionResult DataEditPartial(int id)
        {
            ViewData["Deps"] = departmentRepository.GetAll();
            ViewData["Crs"] = courseRepository.GetAll();
            Instructor instructor = instructorRepository.Get(id);
            return PartialView("_DataEditPartial", instructor);
        }
    }
}
