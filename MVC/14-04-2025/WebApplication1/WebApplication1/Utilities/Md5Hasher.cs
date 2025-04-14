//using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
//using System.Security.Cryptography;

//namespace WebApplication1.Utilities
//{
//    public static class Md5Hasher
//    {
//        public static string HashOlustur(string sifre)
//        {
//            MD5 md5 = MD5.Create();
//            var hashedData = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(sifre));

//            string strhashedPassword = "";
//            foreach (var key in hashedData)
//            {
//                strhashedPassword += key.ToString("x2");
//            }

//            return strhashedPassword;
//        }
//    }
//}

using System.Security.Cryptography;
using System.Text;

namespace WebApplication1.Utilities
{
    public static class Md5Hasher
    {
        public static string HashOlustur(string kullaniciAdi, string sifre)
        {
            // Basit salt: kullanıcı adının ilk 3 harfi + şifrenin son 2 harfi
            string salt = "";
            if (!string.IsNullOrEmpty(kullaniciAdi))
                salt += kullaniciAdi.Substring(0, Math.Min(3, kullaniciAdi.Length)).ToLower();

            if (!string.IsNullOrEmpty(sifre))
                salt += sifre.Substring(Math.Max(0, sifre.Length - 2)).ToUpper();

            // Salt'ı şifreyle birleştir
            string saltedPassword = salt + sifre;

            // MD5 hashleme işlemi
            using MD5 md5 = MD5.Create();
            byte[] hashedBytes = md5.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));

            // Hash'i hex string'e çevir
            StringBuilder sb = new StringBuilder();
            foreach (var b in hashedBytes)
                sb.Append(b.ToString("x2"));

            return sb.ToString();
        }
    }
}

