using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace relation.ViewModels.Student
{
    public class CreateStudentFormVM
    {
        public CreateStudentVM Student { get; set; }

        [BindNever]
        [ValidateNever]
        public SelectList Courses { get; set; }
    }
}
