/*
//  bir firmada tam zamanlı ve yarı zamanlı olmak üzere çeşit satış elemanı çalışmaktadır.

// tam zamanlı çalışan personelleri maaşı; taban ucret + prim şeklinde hesaplanmaktadır

// prim ise yaptığı aylık satış tutarı üzerinden aşağıdaki gibi hesaplanacaktır.;
        250000 < yuzde 1
        250000 >= ve <500000 ise yüzde 2
        500000 > yüzde 3


 yarı zamanlı personellerin maaşı ise; (çalıştığı saat * saat ucreti) + prim
        prim ise satışın sadece yüzde 1'i olacaktır.

 */

using lab3_11_3;


TamZamanliPersonel tamZamanli = new TamZamanliPersonel()
{
    ID = 1,
    Ad = "yasin",
    Soyad = "maden",
    ToplamSatis = 300_000,
    TabanUcret = 10_000
};

Console.WriteLine(tamZamanli.ToString());

yariZamanliPersonel yariZamanli = new yariZamanliPersonel
{
    ID = 2,
    Ad = "ahmet",
    Soyad = "dursun",
    SaatUcreti = 100,
    CalismaSaati = 100,
    ToplamSatis = 400_000
};

Console.WriteLine(yariZamanli.ToString());