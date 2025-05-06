// LSP - Liskov Substitution Principle
// Barbara Liskov

using ex02_LSP;

Daire daire = new Daire() { Yaricap = 4};
Silindir silindir = new Silindir() { Yaricap = 4, Yukseklik = 10};

Console.WriteLine($"Dairenin Alanı: {Hesaplayici.Hesaple(daire)}");
Console.WriteLine($"Silindirin Alanı: {Hesaplayici.Hesaple(silindir)}");