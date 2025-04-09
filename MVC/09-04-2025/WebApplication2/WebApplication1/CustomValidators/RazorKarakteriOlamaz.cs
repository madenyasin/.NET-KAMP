using System.ComponentModel.DataAnnotations;

namespace WebApplication1.CustomValidators
{
    public class RazorKarakteriOlamaz : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if(value != null)
            {
                string deger = value as string;
                return !deger.Contains('@');
            }
            return true;
        }
    }
}
