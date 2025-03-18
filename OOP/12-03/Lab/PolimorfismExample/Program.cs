using PolimorfismExample;

Araba araba = new Araba();
Serce serce = new Serce();
Ferrari ferrari = new Ferrari();

Console.WriteLine();

araba.Sur();
serce.Sur();
ferrari.Sur();

Console.WriteLine();

Araba araba2 = new Araba();
Araba serce2 = new Serce();
Araba ferrari2 = new Ferrari();

//Ferrari ferrari3 = (Ferrari)ferrari2;
//ferrari3.Sur();

araba2.Sur();
serce2.Sur();
ferrari2.Sur();

//List<Araba> arabalar = new List<Araba>();
//arabalar.Add(araba);
//arabalar.Add(ferrari);
//arabalar.Add(serce);

//foreach (var item in arabalar)
//{
//    item.Sur();
//}