﻿using Microsoft.AspNetCore.Mvc;
using System.Net;
using Tranier_System.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Tranier_System.Controllers
{
    public class CourseController : Controller
    {
        TContext db = new TContext();

        public IActionResult Index()
        {
            List<Course> Course = db.course.ToList();
            ViewData["Deps"] = db.Department.ToList();
            return View("Index", Course);
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
            if (crs.Name != null && crs.Degree != 0 && crs.MinDegree != 0 && crs.DepartmentId != 0 )
            {
                db.Add(crs);
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            ViewData["Deps"] = db.Department.ToList();
            return View("Add");
        }
    }
}