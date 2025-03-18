using System.Collections;

ArrayList list = new();

list.Add(1);
list.Add(5);
list.Add(3);
list.Add("on");

int toplam = 0;

foreach (int item in list)
{
    
    toplam += item;
}
Console.WriteLine(toplam);