Console.WriteLine("basit bir c# hesap makinası");
Console.WriteLine("işlem seçiniz [+ | - | * | /] Çıkış yapmak için boş bırakın");

int sayi1, sayi2;
string mathOp;
Basla:

try
{
    Console.Write("Sayı 1: ");
    sayi1 = int.Parse(Console.ReadLine());
    //System.FormatException: 'The input string 'zafer' was not in a correct format.'

    Console.Write("Sayı 2: ");
    sayi2 = int.Parse(Console.ReadLine());

    Console.WriteLine("İşlem: ");
    mathOp = Console.ReadLine();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    goto Basla;
}


switch (mathOp)
{
    case "+": Console.WriteLine($"toplam: {sayi1 + sayi2}"); break;
    case "-": Console.WriteLine($"çıkarma: {sayi1 - sayi2}"); break;
    case "*": Console.WriteLine($"çarpma: {sayi1 * sayi2}"); break;
    case "/": Console.WriteLine($"bölme: {sayi1 / sayi2}"); break;
        //System.DivideByZeroException: 'Attempted to divide by zero.'
    default:
        throw new Exception();
        break;
}
