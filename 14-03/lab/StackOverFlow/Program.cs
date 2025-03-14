using System.Runtime.CompilerServices;


// Hatalı kullanım
int Faktoriyel(int sayi)
{
    return sayi * Faktoriyel(sayi - 1);
}

// Doğru kullanım
int Faktoriyel2(int sayi)
{
    if (sayi == 1)
        return 1;
    return sayi * Faktoriyel2(sayi - 1);
}

Faktoriyel2(5);