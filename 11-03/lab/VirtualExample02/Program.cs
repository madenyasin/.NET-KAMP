Ucgen ucgen = new Ucgen() { Boy = 3, En = 4};
Dİkdortgen dİkdortgen = new Dİkdortgen() { Boy = 3, En = 4};
Console.WriteLine(ucgen.AlanHesapla());
Console.WriteLine(dİkdortgen.AlanHesapla());

public class Sekil
{
    public int Boy { get; set; }
    public int En { get; set; }

    public virtual int AlanHesapla()
    {
        return 0;
    }
}

public class Ucgen : Sekil
{
    override public int AlanHesapla()
    {
        return En * Boy / 2;
    }
}
public class Dİkdortgen : Sekil
{
    override public int AlanHesapla()
    {
        return En * Boy;
    }
}