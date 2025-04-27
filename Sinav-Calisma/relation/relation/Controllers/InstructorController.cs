using Microsoft.AspNetCore.Mvc;
using relation.Data;
using relation.Models;
using relation.ViewModels.InstructorViewModels;

namespace relation.Controllers
{
    public class InstructorController : Controller
    {
        private readonly CourseDbContext dbContext;

        public InstructorController(CourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(InstructorCreateVM vm)
        {
            if (ModelState.IsValid)
            {
                Instructor newInstructor = new()
                {
                    Name = vm.Name,
                };

                dbContext.Add(newInstructor);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NoContent();
            }

            var instructor = dbContext.Instructors.Find(id);
            EditInstructorVM vm = new()
            {
                Id = instructor.Id,
                Name = instructor.Name
            };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(EditInstructorVM vm)
        {
            if (ModelState.IsValid)
            {
                var oldInstructor = dbContext.Instructors.Find(vm.Id);
                oldInstructor.Name = vm.Name;
                dbContext.Update(oldInstructor);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }
    }
}
