using System.Numerics;

List<int> sayilar = new List<int>() { 34, 55, 11, 33, 42, 12, 77, 98, 44 };



Predicate<int> predicate = new Predicate<int>(SayiTekMi);

// 2. Yöntem
Yazdir(sayilar.FindAll(predicate));
bool SayiTekMi(int sayi) => sayi % 2 == 1;

// 3. Yöntem
Yazdir(sayilar.FindAll(SayiTekMi));

// 4. Yöntem

Yazdir(sayilar.FindAll(delegate (int sayi) { return sayi % 2 == 1; }));

// 5. Yöntem
Yazdir(sayilar.FindAll(x =>
{
    return x % 2 == 1;
}));

void Yazdir(IEnumerable<int> sayilar)
{
    foreach (var sayi in sayilar)
    {
        Console.WriteLine(sayi);
    }
}