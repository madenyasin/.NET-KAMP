using Interfaces;

Personel personel = new Personel();
Musteri musteri = new Musteri();

personel.Islem();
musteri.Islem();

IArayuz obj1 = new Personel();
IArayuz obj2 = new Musteri();

obj1.Islem();
obj1.Test();