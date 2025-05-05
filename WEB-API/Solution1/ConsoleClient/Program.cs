using ConsoleClient;
using System.Net.Http.Json;

Console.WriteLine("Merhaba dünya");
Console.WriteLine("Baslangic servisini kullan");

HttpClient client = new HttpClient();

//var jsonData = client.GetStringAsync("http://localhost:5118/api/Baslangic/liste").Result;

var jsonData = client.GetFromJsonAsync<List<Product>>("http://localhost:5118/api/Baslangic/liste").Result;
Console.WriteLine(jsonData);

foreach (var item in jsonData)
{
    Console.WriteLine($"{item.UrunID} {item.UrunAdi} {item.Fiyat}");
}