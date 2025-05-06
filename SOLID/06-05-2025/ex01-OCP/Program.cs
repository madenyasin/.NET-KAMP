// OCP - Open-Closed Principle
// Değişikliklere kapalı, genişletmelere açık
using ex01_OCP;

JsonDosya jsonDosya = new JsonDosya();
XmlDosya xmlDosya = new XmlDosya();

DosyaYoneticisi dosyaYoneticisi = new DosyaYoneticisi();

Console.WriteLine(dosyaYoneticisi.DosyadanOku(jsonDosya));
Console.WriteLine(dosyaYoneticisi.DosyadanOku(xmlDosya));