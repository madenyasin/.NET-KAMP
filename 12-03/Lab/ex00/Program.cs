// bir arraylist oluşturup içersine Musteri ,personel sınıfları atınız.

using ex00;
using System.Collections;

ArrayList Insanlar = new ArrayList();
Insanlar.Add(
    new Personel
    {
        Ad = "Ali",
        Soyad = "Veli",
        PersonelID = 1,
        Maas = 1000
    });

Insanlar.Add(
    new Personel
    {
        Ad = "Mehmet",
        Soyad = "Furkan",
        PersonelID = 2,
        Maas = 3000
    });

Insanlar.Add(
    new Musteri
    {
        Ad = "Ayşe",
        Soyad = "Fatma",
        MusteriID = 1,
        CariDurum = 1000
    });

Insanlar.Add(
    new Musteri
    {
        Ad = "Zeynep",
        Soyad = "Ateş",
        MusteriID = 2,
        CariDurum = -5000
    });

foreach (var insan in Insanlar)
{
    Console.WriteLine(insan);
}