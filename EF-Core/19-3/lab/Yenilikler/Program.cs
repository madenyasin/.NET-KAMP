/*
 * 1) var kullanımı
 * 2) dynamic kullanımı
 * 3) Auto property
 * 4) Object Initiliazer
 * 5) Collection Initiliazer
 * 6) Anonymous Object(Type)
 * 7) ...
 */


// 1- var kullanımı

using LINQ;

var d1 = 12;
var d2 = "Merhaba";
var d3 = 'a';
var d4 = 124.66;
var d5 = 33.5M;
var d6 = 44L;
var d7 = true;
var d8 = new List<string>();
var d9 = new int[10];

// 2- dynamic kullanımı

dynamic d10 = "Merhaba";
d10 = 123;

// dynamic vs object

Object obj = new object();
obj = 12;

int sayi = (int)obj;

dynamic dynmc = 12;
int sayi2 = dynmc;

// 3 - Auto Property
// backing field ve get - set metotları otomatik olarak oluşturulur.


// 4 - Object Initiliazer

Personel personel = new Personel { ID = 1, Ad = "Yasin", Soyad = "Maden" };
Personel personel2 = new() { ID = 2, Ad = "Ahmet", Soyad = "Maden" };

// 5) Collection Initiliazer

List<Personel> list = new()
{
    new Personel { ID = 3, Ad = "Yasin", Soyad = "Maden" } ,
    new Personel { ID = 4, Ad = "Yasin", Soyad = "Maden" } ,

};

// 6) Anonymous Object(Type)

var d11 = new { Id = 12, Ad = "kemal", Adres = "Kadiköy" };

Console.WriteLine(d11);