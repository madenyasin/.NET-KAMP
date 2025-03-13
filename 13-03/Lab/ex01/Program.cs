using ex01;

Boyahane boyahane = new Boyahane();
Bmx bmx = new Bmx()
{
    Marka = "Bisiklet",
    Model = "Bmx",
};
Ferrari ferrari = new Ferrari()
{
    Marka = "Ferrari",
    Model = "F40",
};




if (boyahane.BoyaYap(bmx, ConsoleColor.Blue))
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(bmx);
}
else
{
    Console.WriteLine("Bmx boyanamaz");
}

if (boyahane.BoyaYap(ferrari, ConsoleColor.Blue))
{
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.WriteLine(ferrari);
}
else
{
    Console.WriteLine("Ferrari boyanamaz");
}