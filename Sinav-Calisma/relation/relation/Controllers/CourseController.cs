using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using relation.Data;
using relation.Models;
using relation.ViewModels.Course;

namespace relation.Controllers
{
    public class CourseController : Controller
    {
        private readonly CourseDbContext dbContext;

        public CourseController(CourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {

            return View();
        }
        public IActionResult Create()
        {
            CourseCreateFormVM vm = new()
            {
                Course = new(),
                Instructors = new SelectList(dbContext.Instructors.ToList(), "Id", "Name")
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Create(CourseCreateVM course)
        {
            if (ModelState.IsValid)
            {
                Course newCourse = new()
                {
                    CourseName = course.CourseName,
                    InstructorId = course.InstructorId
                };

                dbContext.Courses.Add(newCourse);
                dbContext.SaveChanges();
                return RedirectToAction("Index");

            }

            CourseCreateFormVM vm = new()
            {
                Course = course,
                Instructors = new SelectList(dbContext.Instructors.ToList(), "Id", "Name")
            };
            return View(vm);
        }


    }
}
