using Delegates;

Test test = new Test();
Temsilci temsilci = new Temsilci(Test.Merhaba);

temsilci += Test.Hello;
temsilci += Test.Hello;
//temsilci += Test.KareAL;
//temsilci ^= Test.IkiKatiniAl;



// Anonim metotlar

var t = delegate ()
{
    Console.WriteLine("anonim metod");
};

t();




public delegate void Temsilci();