using Generics;

int[] sayilar = { 1, 2, 3, 4, 5 };
string[] sehirler = { "Ankara", "İstanbul", "İzmir" };

void EkranaYaz<T>(T[] dizi)
{
    foreach (var eleman in dizi)
    {
        Console.WriteLine(eleman);
    }
}

EkranaYaz(sayilar);
EkranaYaz(sehirler);

Depo<Televizyon> depo = new();
Depo<Buzdolabi> depo2 = new();


