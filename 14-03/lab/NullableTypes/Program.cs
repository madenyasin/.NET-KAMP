//int sayi = null;

Nullable<int> sayi2 = null;

int? sayi3 = null;
int? sayi4 = 444;

Console.WriteLine(sayi3.GetValueOrDefault());

Console.WriteLine(sayi3 ?? -1);
Console.WriteLine(sayi4 ?? -1);