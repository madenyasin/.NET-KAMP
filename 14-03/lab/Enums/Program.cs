////for (int i = 1; i < 6; i++)
////{
////    Console.ForegroundColor = (ConsoleColor)i;
////    Console.WriteLine("merhaba dünya");
////}
////Console.ForegroundColor = ConsoleColor.White;

//using Enums;

//Gunler gunler = Gunler.Cuma;

//Console.WriteLine(gunler);
//Console.WriteLine((int)gunler);

//foreach (var item in Enum.GetNames(typeof(Gunler)))
//{
//    Console.WriteLine(item);
//}

using Enums;

Personel personel = new Personel();
personel.IzinGunu = Gunler.Cuma ;