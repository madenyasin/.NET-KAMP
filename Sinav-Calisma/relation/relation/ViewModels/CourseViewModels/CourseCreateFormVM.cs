using Microsoft.AspNetCore.Mvc.Rendering;

namespace relation.ViewModels.Course
{
    public class CourseCreateFormVM
    {
        public CourseCreateVM Course { get; set; }
        public SelectList Instructors { get; set; }
    }
}
