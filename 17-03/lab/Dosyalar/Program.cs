// Dosya oluşturma

//string filePath = @"C:\Users\a\Desktop\data.txt";
//StreamWriter sw = new(filePath, true);
//sw.WriteLine("Merhaba Dünya!");
//sw.WriteLine("Merhaba Dünya!2");
//sw.Close();


// Text Dosya okuma

string filePath = @"C:\Users\a\Desktop\data.txt";
StreamReader sr = new(filePath);

// tüm verileri tek seferde okur
//Console.WriteLine(sr.ReadToEnd());




// satır satır okuma
while (!sr.EndOfStream)
{
    Console.WriteLine(">>" + sr.ReadLine());
}

sr.Close();