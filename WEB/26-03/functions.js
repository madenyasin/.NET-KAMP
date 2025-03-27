function kareAl(sayi) {
    return sayi * sayi;
}

function sayilariTopla(...sayilar) {
    let toplam = 0;
    sayilar.forEach(sayi => toplam += sayi)
    return toplam
}

function silindirHacimHesapla(yaricap, yukseklik) {
    return daireAlanHesapla(yaricap) * yukseklik;

    function daireAlanHesapla(yaricap) {
        return Math.PI * yaricap * yaricap;
    }
}

function zarAt() {
    let random;
    do {
        random = parseInt(Math.random() * 7)

    } while (random === 0);
    return random;
}