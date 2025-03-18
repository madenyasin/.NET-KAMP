using Interfaces01;

List<string> sehirler = new List<string> { "Ankara", "İstanbul", "İzmir" };

foreach (var item in sehirler)
{
    Console.WriteLine(item);
}

Console.WriteLine();

Depo depo = new Depo();


foreach (var item in depo)
{
    Console.WriteLine(item);
}

