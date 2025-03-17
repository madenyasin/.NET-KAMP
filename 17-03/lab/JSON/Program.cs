using JSON;
using Newtonsoft.Json;

StreamReader streamReader = new StreamReader("../../../kitap.json");
string strJson = streamReader.ReadToEnd();

var kitaplar = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Kitap>>(strJson);

foreach (var kitap in kitaplar)
{
    Console.WriteLine($"{kitap.ID} {kitap.Yazar} {kitap.Ad} {kitap.Fiyat}");
}


var strSerialized = JsonConvert.SerializeObject(kitaplar, Formatting.Indented);
Console.WriteLine(strSerialized);