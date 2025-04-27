using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace relation.ViewModels.InstructorViewModels
{
    public class EditInstructorVM
    {
        [ValidateNever]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
