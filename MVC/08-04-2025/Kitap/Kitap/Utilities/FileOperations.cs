namespace Kitap.Utilities
{
    public class FileOperations
    {
        public static string ResimYukle(IFormFile dosya, string path = "wwwroot/Resimler/")
        {
            string guid = Guid.NewGuid().ToString();
            string dosyaAdi = guid + "_" + dosya.FileName;
            string dosyaYolu = path + dosyaAdi;
            FileStream fs = new(dosyaYolu, FileMode.Create);
            dosya.CopyTo(fs);
            fs.Close();
            return dosyaAdi;
        }
    }
}
