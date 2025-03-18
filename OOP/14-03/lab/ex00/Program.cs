void Yaz()
{
    for (int i = 0; i < 1000; i++)
    {
        Thread.Sleep(10);
        Console.WriteLine("Yaz " + i);
    }
}

void Say()
{
    for (int i = 0; i < 1000; i++)
    {
        Thread.Sleep(10);
        Console.WriteLine(i);
    }
}

//Yaz();
//Say();

ThreadStart threadStartYaz = new ThreadStart(Yaz);
ThreadStart threadStartSay = new ThreadStart(Say);

threadStartSay();
threadStartYaz();

Thread threadYaz = new Thread(threadStartYaz);
Thread threadSay = new Thread(threadStartSay);

threadYaz.Start();
threadSay.Start();

