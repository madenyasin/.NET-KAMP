//// döngüler for, while, do while

//for (int i = 0; i < 10; i++)
//{
//    Console.WriteLine(i);
//}



//for (int i = 2; i <= 1000; i+=2)
//{
//    Console.WriteLine(i);
//}


//for (int i = 1000; i >= 2; i -= 2)
//{
//    Console.WriteLine(i);
//}


//for (int i = 1; i <= 1000; i++)
//{
//    if (i % 2 == 1)
//        Console.WriteLine(i);
//}


//for (int i = 'A';i <= 'Z'; i++)
//{
//    Console.WriteLine(Convert.ToChar(i));
//}


//int sum = 0;
//for (int i = 1; i <= 100; i++)
//{
//    sum += i;
//}
//Console.WriteLine(sum);

//int sum2 = 0;
//int sum3 = 0;
//for (int i = 1; i <= 100; i++)
//{
//    if (i % 2 == 1)
//    {
//        sum2 += i;
//    }
//    else
//    {
//        sum3 += i;
//    }
//}
//Console.WriteLine(sum);

//int fark = sum3 - sum2;
//Console.WriteLine(fark * fark);
//for (DateTime i = new DateTime(1945, 01,01); i < DateTime.Now; i = i.AddYears(1))
//{
//    if (i.Year <)
//    {
//        Console.ForegroundColor = ConsoleColor.Red; // Yazı rengini
//        Console.WriteLine(i.ToString());

//    }
//    Console.WriteLine(i.ToString());
//}


//try
//{
//    int sum = 0;
//    for (int i = 0; i < 10; i++)
//    {
//        sum += int.Parse(Console.ReadLine());
//    }
//    Console.WriteLine(sum);
//}
//catch (Exception e)
//{

//    Console.WriteLine(e.ToString());
////}

//int i = 1000;
//while (i > 0)
//{
//    Console.WriteLine(i);
//    i--;
//}


//int toplamTek = 0, toplamCift = 0, sayac = 1;
//while (sayac <= 100)
//{
//    if (sayac % 2 == 0)
//    {
//        toplamCift += sayac;
//    }
//    else
//    {
//        toplamTek += sayac;
//    }
//    sayac++;
//}

//int sonuc = toplamCift - toplamTek;
//Console.WriteLine(sonuc * sonuc);

//int sayac2 = 1;
//int toplam = 0;
//while (sayac2 <= 10)
//{
//    toplam += int.Parse(Console.ReadLine());
//    sayac2++;
//}
//Console.WriteLine(toplam);



//#region algoritma

////Dışarıdan ürün adı girilecek bize hangi bölümde olduğunu söylecek...

////Domates, Biber, Patlican => Meyve ve Sebze Bölümüne bak.
////Diş Macunu, Parfüm, Sabun => Kozmetik Bölümüne bak.
////Cep Telefonu, TV, Bilgisayar => Teknoloji Bölümüne bak.
////Bunların dışında bir ürün => "Bu ürün bizde yok!"....

//string input = Console.ReadLine();  
//switch (input.ToLower())
//{
//    case "domates":
//    case "biber":
//    case "patlican":
//        Console.WriteLine("Meyve ve Sebze Bölümüne bak.");
//        break;
//    case "diş macunu":
//    case "parfüm":
//    case "sabun":
//        Console.WriteLine("Kozmetik Bölümüne bak.");
//        break;
//    case "cep telefonu":
//    case "tv":
//    case "bilgisayar":
//        Console.WriteLine("teknoloji Bölümüne bak.");
//        break;
//    default:
//        Console.WriteLine("bu ürün bizde yok");
//        break;
//}



//#endregion


//string userName, password;
//do
//{
//    Console.Write("Kullanıcı adınızı giriniz: ");
//    userName = Console.ReadLine();

//    Console.Write("Şifrenizi giriniz: ");
//    password = Console.ReadLine();
//}
//while (userName != "admin" || password != "123");



//Sayi1GoTo:
//Console.WriteLine("Sayı 1:");
//bool parseResult = int.TryParse(Console.ReadLine(), out int number);
//if (!parseResult)
//{
//    goto Sayi1GoTo;
//}

//Sayi2GoTo:
//Console.WriteLine("Sayı 2:");
//bool parseResult2 = int.TryParse(Console.ReadLine(), out int number2);
//if (!parseResult2)
//{
//    goto Sayi2GoTo;
//}

//Console.WriteLine(number + number2);  


//bool flag = true;
//while (flag)
//{
//    Console.WriteLine("Doğum tarihini giriniz: ");

//    bool result = DateTime.TryParse(Console.ReadLine(), out DateTime t);

//    if (result)
//    {
//        flag = false;
//        Console.WriteLine(DateTime.Now.Year - t.Year);
//    }

//}


//int sumNegative = 0;
//int carpim = 1;
//int sayac = 0;
//for (int i = 0; i < 25; i++)
//{
//    bool result = int.TryParse(Console.ReadLine(), out int sayi);
//    if (result)
//    {
//        if (sayi < 0)
//        {
//            sumNegative += sayi;
//        }
//        else if (sayi % 2 == 0)
//        {
//            carpim *= sayi;
//        }
//        else if (sayi == 7)
//        {
//            sayac++;
//        }
//    }
//}
//Console.WriteLine($"negatif sayıların toplamı: {sumNegative}");
//Console.WriteLine($"çift sayıların çarpımı: {carpim}");
//Console.WriteLine($"kaç tane '7' yazıldı? -> {sayac}");

int sum = 0;
bool flag = true;
int number1 = 0, number2 = 0;
while (flag)
{
    Console.Write("sayi 1: ");
    bool inputResult = int.TryParse(Console.ReadLine(), out int sayi1);
    if (!inputResult)
    {
        Console.Clear();
        continue;
    }
    number1 = sayi1;

    Console.Write("sayi 2: ");
    inputResult = int.TryParse(Console.ReadLine(), out int sayi2);

    if (!inputResult)
    {
        Console.Clear();
        continue;
    }
    else
    {
        number2 = sayi2;
        flag = false;
    }
}

for (int i = 0; i < number1; i++)
{
    sum += number2;

}

Console.WriteLine($"{number1} x {number2} = {sum}");
