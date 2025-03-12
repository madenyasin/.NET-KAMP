/*
 * KARAR YAPILARI
 * if - else if - else
 */
/*
#region haftanın gunleri

Console.Write("1 ile 7 arasında bir rakam giriniz: ");
int gun = int.Parse(Console.ReadLine());

if (gun == 1)
    Console.Write("Pazartesi");
else if (gun == 2)
    Console.Write("Salı");
else if (gun == 3)
    Console.Write("Çarşamba");
else if (gun == 4)
    Console.Write("Perşembe");
else if (gun == 5)
    Console.Write("Cuma");
else if (gun == 6)
    Console.Write("Cumartesi");
else if (gun == 7)
    Console.Write("Pazar");
else
    Console.Write("Hatalı giriş");
#endregion
*/

/*

#region ornek1

Console.Write("Lütfen yaşınızı giriniz: [0-100] ");
int yas = int.Parse(Console.ReadLine());
if (yas < 0 || yas > 100)
    Console.WriteLine("Geçersiz yaş!");
else
    Console.WriteLine("Geçerli yaş.");


Console.Write("Lütfen yaşınızı giriniz: [0-100] ");
int yas2 = int.Parse(Console.ReadLine());
if (yas2 > 0 && yas2 < 100)
    Console.WriteLine("Geçerli yaş");
else
    Console.WriteLine("Geçersiz yaş!");


#endregion

*/


//#region ornek2

//Console.WriteLine("Vize notunuz: ");
//int vize = int.Parse(Console.ReadLine());
//Console.WriteLine("Final notunuz: ");
//int final = int.Parse(Console.ReadLine());

//double sonuc = (vize * 0.3) + (final * 0.7);

//if (sonuc >= 0 && sonuc < 30)
//    Console.WriteLine("FF");
//else if (sonuc >= 30 && sonuc < 50)
//    Console.WriteLine("CC");
//else if (sonuc >= 50 && sonuc < 70)
//    Console.WriteLine("BB");
//else if (sonuc >= 70 && sonuc <= 100)
//    Console.WriteLine("AA");
//else
//    Console.WriteLine("hatalı giriş");

//#endregion


//#region ternary if
////syntax: condition ? true : false;

//int sayi1;
//if (3 > 2)
//    sayi1 = 10;
//else
//    sayi1 = 5;

//int sayi2 = (3 > 2) ? 10 : 5;



//#endregion




//#region default
//Console.WriteLine("Bir veri giriniz: ");
//string input = Console.ReadLine();

//if (input == "")
//    Console.WriteLine("default");
//else
//    Console.WriteLine(input);
//#endregion


//#region teklikciftlik
//Console.WriteLine("sayi giriniz: ");
//int sayi = int.Parse(Console.ReadLine());

//string result = (sayi % 2 == 0) ? "çift" : "tek";
//Console.WriteLine(result); 
//#endregion

//#region MyRegion
//double ortalama = double.Parse(Console.ReadLine());
//string not;
//if (ortalama > 90 && ortalama <= 100)
//    not = "AA";
//else if (ortalama > 80 && ortalama <= 90)
//    not = "BB";
//else if (ortalama > 70 && ortalama <= 80)
//    not = "CC";
//else
//    not = "kaldınız";

//Console.WriteLine(not);

//#endregion


//#region switch case
//string mevsim = Console.ReadLine();

//switch (mevsim)
//{
//    case "ilkbahar":
//        Console.WriteLine("mart nisan mayıs");
//        break;
//    case "yaz":
//        Console.WriteLine("haziran temmuz ağustos");
//        break;
//    case "sonbahar":
//        Console.WriteLine("eylül ekim kasım");
//        break;
//    case "kış":
//        Console.WriteLine("aralık ocak şubat");
//        break;
//    default:
//        Console.WriteLine("hata");
//        Console.WriteLine("hata");
//        break;
//}
//#endregion



string rol = Console.ReadLine();

switch (rol.ToLower())
{
    case "yönetici":
    case "seo":
    case "başkan":
    case "admin":
        Console.WriteLine("yönetim paneline hoş geldiniz.");
        break;
    case "uye":
        Console.WriteLine("anasayfaya hoşgeldiniz.");
        break;
    default:
        Console.WriteLine("yetki yok");
        break;
}