using System.ComponentModel.DataAnnotations;

namespace WebApplication1.CustomValidators
{
    public class TcKimlikNoValidator : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string tc = value as string;

            if (!long.TryParse(tc, out long deneme))
            {
                return false;
            }
            if (tc.Length != 11)
            {
                return false;
            }
            else if (tc[0] == '0')
            {
                return false;
            }
            else if (!CiftMi(int.Parse(tc[10].ToString())))
            {
                return false;
            }
            return true;
        }

        public bool CiftMi(int n)
        {
            if (n % 2 == 0)
                return true;
            else
                return false;
        }
    }
}
