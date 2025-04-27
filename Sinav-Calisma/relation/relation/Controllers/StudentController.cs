using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using relation.Data;
using relation.Models;
using relation.ViewModels.Student;

namespace relation.Controllers
{
    public class StudentController : Controller
    {
        private readonly CourseDbContext dbContext;

        public StudentController(CourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            var vm = new CreateStudentFormVM()
            {
                Courses = new SelectList(dbContext.Courses.ToList(), "Id", "CourseName"),
                Student = new()
            };
            return View(vm);
        }

        //[HttpPost]
        //public IActionResult Create(CreateStudentFormVM vm)
        //{
        //    if (ModelState.IsValid)
        //    {

        //        Student newStudent = new()
        //        {
        //            Name = vm.Student.Name,
        //            StudentDetail = new()
        //            {
        //                Address = vm.Student.Address,
        //                Phone = vm.Student.Phone,
        //            },
        //        };

        //        if (vm.Student.SecilenKursIdleri != null)
        //        {
        //            foreach (var item in vm.Student.SecilenKursIdleri)
        //            {
        //                newStudent.Courses.Add(new StudentCourse
        //                {
        //                    CourseId = item,
        //                    Student = newStudent
        //                });
        //            }
        //        }


        //        dbContext.Students.Add(newStudent);
        //        dbContext.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    vm.Courses = new SelectList(dbContext.Courses.ToList(), "Id", "CourseName");

        //    return View(vm);
        //}

        [HttpPost]
        public IActionResult Create(CreateStudentVM student)
        {
            if (ModelState.IsValid)
            {

                Student newStudent = new()
                {
                    Name = student.Name,
                    StudentDetail = new()
                    {
                        Address = student.Address,
                        Phone = student.Phone,
                    },
                };

                if (student.SecilenKursIdleri != null)
                {
                    foreach (var item in student.SecilenKursIdleri)
                    {
                        newStudent.Courses.Add(new StudentCourse
                        {
                            CourseId = item,
                            Student = newStudent
                        });
                    }
                }


                dbContext.Students.Add(newStudent);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            var vm = new CreateStudentFormVM()
            {
                Courses = new SelectList(dbContext.Courses.ToList(), "Id", "CourseName"),
                Student = student
            };

            return View(vm);
        }



    }
}
