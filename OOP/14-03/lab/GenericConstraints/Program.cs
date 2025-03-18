using GenericConstraints;

Test<string> test = new Test<string>();
Test<object> test2 = new Test<object>();
Test<Urun> test3 = new Test<Urun>();

// VALUE TYPE KULLANILAMAZ. (Class constraint kullanıldığı için) 
//Test<int> test4 = new Test<int>();

Islem<int> islem = new();
Islem<double> islem2 = new();

// REFERENCE TYPE KULLANILAMAZ. (Struct constraint kullanıldığı için)

//Islem<Urun> islem3 = new Islem<Urun>();
//Islem<string> islem3 = new();

PersonelIslemleri<Personel> personelIslemleri = new();
PersonelIslemleri<Mudur> personelIslemleri2 = new();
PersonelIslemleri<Memur> personelIslemleri3 = new();


// Urun ve string; Personel sınıfından türetilmediği için hata alırız.
//PersonelIslemleri<string> personelIslemleri4 = new();
//PersonelIslemleri<Urun> personelIslemleri5 = new();



SilahRuhsatIslemleri<Mudur> silahRuhsatIslemleri = new();
SilahRuhsatIslemleri<Guvenlik> silahRuhsatIslemleri2 = new();

// SilahTasiyabilir interface'inden türetilmediği için hata alırız.
//SilahRuhsatIslemleri<Memur> silahRuhsatIslemleri3 = new();


MuhasebeIslemleri<Mudur> muhasebeIslemleri = new();
MuhasebeIslemleri<Memur> muhasebeIslemleri2 = new();


// default constructor'ı olmadığı için hata alırız.
//MuhasebeIslemleri<Hizmetli> muhasebeIslemleri4 = new();

// Personel sınıfından türetilmediği için hata alırız.
//MuhasebeIslemleri<Guvenlik> muhasebeIslemleri3 = new();




