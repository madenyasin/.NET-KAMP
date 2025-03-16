Obje obje = new Obje();
Kalem kalem = new Kalem();
Terlik terlik = new Terlik();


Console.WriteLine(obje.Bilgi());
Console.WriteLine(kalem.Bilgi());
Console.WriteLine(terlik.Bilgi());

public class Obje
{
    public virtual string Bilgi()
    {
        return "Ben bir objeyim.";
    }
}

public class Terlik : Obje
{
    override public string Bilgi()
    {
        return "Ben bir terliğim.";
    }
}

public class Kalem : Obje
{
    public override string Bilgi()
    {
        return "Ben bir kalemim";
    }
}