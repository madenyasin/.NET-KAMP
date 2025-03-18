using System.Collections;

ArrayList liste = new ArrayList();
List<int> liste2 = new List<int>();


DateTime basla, bitir;
TimeSpan delta = new TimeSpan();

int sayac= 9999999;
basla = DateTime.Now;

for (int i = 0; i < sayac; i++)
{
    liste.Add(i);
    int sayi = (int)liste[i];
}

bitir = DateTime.Now;

delta = bitir - basla;
Console.WriteLine("ArrayList: " + delta.TotalMilliseconds);


sayac = 9999999;
basla = DateTime.Now;

for (int i = 0; i < sayac; i++)
{
    liste2.Add(i);
    int sayi = liste2[i];
}

bitir = DateTime.Now;

delta = bitir - basla;


Console.WriteLine("List<int>: " + delta.TotalMilliseconds);
