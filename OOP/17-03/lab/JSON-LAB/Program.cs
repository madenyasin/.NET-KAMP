using JSON_LAB;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

HttpClient client = new HttpClient();
string json = client.GetStringAsync("https://reqres.in/api/users?page=2").Result;
Console.WriteLine(json);

RequestResponseModel response = JsonConvert.DeserializeObject<RequestResponseModel>(json);

foreach (var item in response.Data)
{
    Console.WriteLine(item);
}
