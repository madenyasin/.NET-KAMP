// İstisna Tipleri

/*
 * 1.   Derleme zamanı - Compile time exception: genellikle syntax kaynaklı (yazılımsal hatalar) 
 * hatalardır. Hata meydana geldiğinde CS bize bilgi verir.
 * 
 * 2.   Çalışma zamanı - Run time exception: Uygulama çalışırken alınan hatalar.
 * Çoğunlukla kullanıcı kaynaklı (verilerin yanlış veya eksik girilmesi gibi) hatalardır.
 * Çözüm -> trt-catch mekanizması
 * 
 * 3.   Mantıksal hatalar: 100% yazılımcı kaynaklı hatalardır. Uygulamanın
 * algoritmasından kaynaklıdır.
 */

#region ornek1
Basla:
try
{
    Console.WriteLine("telefon numarası: (xxx-xxx-xx-xx)");
    int input = int.Parse(Console.ReadLine());
    Console.WriteLine("tebrikler!");
}
catch (FormatException ex)
{
    Console.WriteLine($"Format hatası oluştu.\nDetaylar: {ex.Message}");
}
catch(OverflowException ex)
{
    Console.WriteLine($"Değer aşımı oluştu.\nDetaylar: {ex.Message}");
}
catch (DivideByZeroException ex)
{
    Console.WriteLine($"Sıfıra bölme hatası oluştu.\nDetaylar: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"Bir hata meydana geldi.\nDetaylar: {ex.Message}");
}
goto Basla;
#endregion