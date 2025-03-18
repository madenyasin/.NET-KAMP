using ex01;

Daire daire = new Daire() { Yaricap = 5 };
Silindir silindir = new Silindir() { Yaricap = 5, Yukseklik = 10 };
Koni koni = new Koni() { Yaricap = 5, Yukseklik = 10 };

Console.WriteLine(daire.AlanHesapla());
Console.WriteLine(silindir.HacimHesaapla());
Console.WriteLine(koni.HacimHesaapla());
