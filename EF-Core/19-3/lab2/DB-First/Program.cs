using DB_First.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

Console.WriteLine("Database First");

NorthwindContext context = new();

//var urunler = northwind.Products.ToList();

//foreach (var urun in urunler)
//{
//    Console.WriteLine(urun);
//}
//Console.WriteLine("-----------------------------------");


//var result = context.Products.Join(
//    context.Categories,
//    p => p.CategoryId,
//    c => c.CategoryId,
//    (p, c) => new { p.ProductName, c.CategoryName });

//foreach (var item in result)
//{
//    Console.WriteLine(item);
//}

//var sonuc = context.Products.Include(x => x.Category);
//foreach (var item in sonuc)
//{
//    Console.WriteLine(item.ProductName+','+item.Category);
//}

/**
 * 
 * EF Core yükleme mekanizmaları
 * Lazy Loading
 * Eager Loading 
 * explicit Loading
 */


var listele = context.Products.ToList();
foreach (var item in listele)
{
    Console.WriteLine(item.Category.CategoryName);
}