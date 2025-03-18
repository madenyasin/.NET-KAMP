using EF_Core_Intro.Data;
using EF_Core_Intro.Models;

Console.WriteLine("EF Core Code First => Model First");


PersonelContext context = new PersonelContext();

//context.Database.EnsureDeleted();
//context.Database.EnsureCreated();

//context.Bolumler.Add(new Bolum { BolumAd = "Yazılım" });
//context.Bolumler.Add(new Bolum { BolumAd = "Satış" });

//foreach (var bolum in context.Bolumler)
//{
//    Console.WriteLine(bolum.BolumID + " " + bolum.BolumAd);
//}

//var yazilim = context.Bolumler.Find(2);
//yazilim.BolumAd = "Yazılım";

//context.Bolumler.Update(yazilim);


context.Bolumler.Remove(context.Bolumler.Find(1));


context.SaveChanges();

