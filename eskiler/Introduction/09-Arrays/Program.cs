// birden fazla aynı türden veriyi birarada tutabilmeyi sağlayan nesnelerdir.

//#region tanımlama
//string[] names;

//names = new string[5];

//names[0] = "Zafer";
//names[1] = "Yasin";
//names[2] = "Ahmet";
//names[3] = "Mehmet";
//names[4] = "Muhammed";


//string[] surnames = new string[5];

//surnames[0] = "Maden";
//surnames[1] = "Maden";
//surnames[2] = "Maden";
//surnames[3] = "Maden";
//surnames[4] = "Maden";


//int[] ages = new int[5] { 10, 20, 30, 40, 50 };
//int[] ages2 = { 10, 20, 30, 40, 50 };


//char[] chars = { 'A', 'B', 'C' };



//Console.WriteLine(); 
//#endregion


//string[] cars = { "togg", "bmw", "mercedes", "ford", "renault", "honda" };

//for (int i = 0; i < cars.Length; i++)
//{
//    Console.WriteLine(cars[i]);
//}


//Console.WriteLine(new String('*', 50));

//foreach (var car in cars)
//{
//    Console.ForegroundColor = (car == "togg") ? ConsoleColor.Red : ConsoleColor.White;
//    Console.WriteLine(car);

//    //if (car.ToLower() == "togg")
//    //{
//    //    Console.ForegroundColor = ConsoleColor.Red;
//    //    Console.WriteLine(car);
//    //}
//    //else
//    //{
//    //    Console.ForegroundColor= ConsoleColor.White;
//    //    Console.WriteLine(car);

//    //}
//}


//Console.WriteLine(new String('*', 50));

//object[] objects = { "Gel", 'g', 'i', 't', 12, 12.2, DateTime.Now, -51, true, false, 12.2m, 12.2f };

//foreach (object o in objects)
//{
//    Console.WriteLine(o);
//}

//int[] numbers = new int[8];

//for (int i = 0; i < numbers.Length; i++)
//{
//    Console.Write($"{i + 1}. sayıyı giriniz: ");
//    bool isSuccsess = int.TryParse(Console.ReadLine(), out numbers[i]);
//    if (!isSuccsess)
//        i--;
//}

//foreach (int number in numbers)
//{
//    Console.ForegroundColor = (number % 2 == 0) ? ConsoleColor.Red : ConsoleColor.White;

//    Console.WriteLine(number);
//}

//Random random = new Random();
//int[] numbers = new int[8];


//for (int i = 0; i < numbers.Length; i++)
//{
//    numbers[i] = random.Next(1, 101);
//}

//foreach (var item in numbers)
//{
//    Console.WriteLine(item);
//}


/*
 * maaş hesapla
 * kaç kişinin maaşı igrilecek sor
 * isimler
 * ücretler double
 * çalışma saatleri int
 * 
 * ekrana yazmak ister misiniz: e h 
 * 
 */


//int personNumber;

//do
//{
//    Console.WriteLine("Kaç kişinin maaşını gireceksiniz? ");
//}
//while (!int.TryParse(Console.ReadLine(), out personNumber));

//string[] names = new string[personNumber];
//double[] salaries = new double[personNumber];
//int[] workingHours = new int[personNumber];
//bool isSuccess;
//for (int i = 0; i < personNumber; i++)
//{
//    Console.Write("Çalışanın ismi: ");
//    names[i] = Console.ReadLine() ?? "null";

//    Console.Write("Çalışanın Maaşı: ");
//    isSuccess = double.TryParse(Console.ReadLine(), out salaries[i]);
//    if (!isSuccess)
//    {
//        Console.WriteLine("Maaşı tekrar giriniz.");
//        i--;
//    }

//    Console.Write("Çalışanın aylık çalışma saati: ");
//    isSuccess = int.TryParse(Console.ReadLine(), out workingHours[i]);
//    if (!isSuccess)
//    {
//        Console.WriteLine("Aylık çalışma saatini tekrar giriniz.");
//        i--;
//    }

//}

//Console.WriteLine("Sonuçları ekrana yazdırmak ister misiniz? (E/H)");
//string input = Console.ReadLine();
//if (input.ToLower() != "h")
//{
//    Console.WriteLine("----------------------------------------------");
//    foreach (var item in names)
//    {
//        Console.Write($"{item}\t");
//    }
//    Console.WriteLine("\n----------------------------------------------");
//    foreach (var item in workingHours)
//    {
//        Console.Write($"{item}\t");
//    }
//    Console.WriteLine("\n----------------------------------------------");

//    foreach (var item in salaries)
//    {
//        Console.Write($"{item}\t");
//    }
//    Console.WriteLine("\n----------------------------------------------");

//}


//int[] vizeler = { 20, 30, 40, 50 };
//int[] finaller = { 10, 20, 30, 40 };

//int[,] tumSinavlar = new int[4, 2] { { 20, 10 }, { 30, 20 }, { 40, 30 }, { 50, 40 } };

//Console.WriteLine(tumSinavlar[2, 1]);

//for (int i = 0; i < tumSinavlar.GetLength(0); i++)
//{
//    for (int j = 0; j < tumSinavlar.GetLength(1); j++)
//    {
//        Console.Write(tumSinavlar[i, j]);
//        Console.Write("\t");
//    }
//    Console.WriteLine();
//}


//Console.WriteLine("Kaç adet veri girilecek?");
//int adet = int.Parse(Console.ReadLine());

//int[] notlar = new int[adet];

//for (int i = 0; i < notlar.Length; i++)
//{
//    do
//    {
//        Console.Write($"{i+1}. notu giriniz: ");
//    }
//    while (!int.TryParse(Console.ReadLine(), out notlar[i]));
//}

//foreach (var item in notlar)
//{
//    Console.WriteLine(item);
//}

//Console.WriteLine($"ortalama: {notlar.Sum() / adet}");


/*Rastgele [-50,50] arasında 20 sayı alınız. Bu sayıları bir dizi içerisinde tutunuz.
Ekrana yazdırırken sayıların negatif, pozitif ve işaretsiz olma durumlarını yanına yazdıran programı yazın
*/

//Random random = new Random();
//int[] sayilar = new int[20]; 
//for (int i = 0; i < 20; i++)
//{
//    sayilar[i] = random.Next(-50, 51);
//}

//foreach (var item in sayilar)
//{
//    Console.Write(item);
//    if (item < 0)
//    {
//        Console.Write("\t-");
//    }
//    else if (item > 0)
//    {
//        Console.Write("\t+");
//    }
//    else
//    {
//        Console.Write("\tişaretsiz");
//    }
//    Console.WriteLine();
//}


//Random random = new Random();
//int[] sayilar = new int[15];
//for (int i = 0; i < 15; i++)
//{
//    sayilar[i] = random.Next();
//}

//Array.Sort(sayilar);

//for (int i = 0; i < sayilar.Length; i++)
//{
    
//}

//foreach (var item in sayilar)
//{
//    Console.WriteLine(item);
//}