using System.Diagnostics;
using System.Threading.Tasks;
// SENKRON
//void Islem1()
//{
//    Console.WriteLine("Islem 1 Basladi");
//    Thread.Sleep(5000); // Simulate a long-running task
//    Console.WriteLine("Islem 1 Tamamlandi");
//}

//void Islem2()
//{
//    Console.WriteLine("Islem 2 Basladi");
//    Thread.Sleep(8000); // Simulate a long-running task
//    Console.WriteLine("Islem 2 Tamamlandi");
//}

//void Islem3()
//{
//    Console.WriteLine("Islem 3 Basladi");
//    Thread.Sleep(7000); // Simulate a long-running task
//    Console.WriteLine("Islem 3 Tamamlandi");
//}

//Stopwatch stopwatch = new Stopwatch();
//stopwatch.Start();
//Islem1();
//Islem2();
//Islem3();
//stopwatch.Stop();
//Console.WriteLine($"Toplam Sure: {stopwatch.ElapsedMilliseconds} ms");


// ASENKRON
async Task Islem1Async()
{
    Console.WriteLine("Islem 1 Basladi");
    await Task.Delay(5000);
    Console.WriteLine("Islem 1 Tamamlandi");
}

async Task Islem2Async()
{
    Console.WriteLine("Islem 2 Basladi");
    await Task.Delay(8000);
    Console.WriteLine("Islem 2 Tamamlandi");
}

async Task Islem3Async()
{
    Console.WriteLine("Islem 3 Basladi");
    await Task.Delay(7000);
    Console.WriteLine("Islem 3 Tamamlandi");
}

Stopwatch stopwatch = new Stopwatch();
stopwatch.Start();
Task.WaitAll(Islem1Async(), Islem2Async(), Islem3Async());

stopwatch.Stop();
Console.WriteLine($"Toplam Sure: {stopwatch.ElapsedMilliseconds} ms");