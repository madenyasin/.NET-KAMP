using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Marmaray_Revize;
using Newtonsoft.Json;

namespace Marmaray
{
    internal class MarmaraySystem
    {
        public List<Kisi> Kisiler = new List<Kisi>();
        public List<Durak> Duraklar = new List<Durak>();
        public List<Yolculuk> Yolculuklar = new List<Yolculuk>();

        string kisilerJson = "kisiler.json";
        string duraklarJson = "duraklar.json";
        string yolculuklarJson = "yolculuklar.json";

        public MarmaraySystem()
        {
            DosyadanOku(kisilerJson, ref Kisiler);
            DosyadanOku(duraklarJson, ref Duraklar);
            DosyadanOku(yolculuklarJson, ref Yolculuklar);
        }

        public void KisiEkle(Kisi kisi)
        {
            Kisiler.Add(kisi);
            DosyayaYaz(kisilerJson, ref Kisiler);
        }
        public void DurakEkle(Durak durak)
        {
            Duraklar.Add(durak);
        }
        public void YolculukEkle(Yolculuk yolculuk)
        {
            yolculuk.Tarih = DateTime.Now;
            yolculuk.Ucret = UcretHesapla(yolculuk);
            Yolculuklar.Add(yolculuk);
            DosyayaYaz(yolculuklarJson, ref Yolculuklar);
        }
        private double UcretHesapla(Yolculuk yolculuk)
        {
            List<double> temelUcretler = new List<double> { 59.76, 27, 0 };
            double ucret;
            int gidilenDurakSayisi = Math.Abs(yolculuk.Binis.Id - yolculuk.Inis.Id);
            int iadeTarifesi = gidilenDurakSayisi / 7;

            if (yolculuk.Abonman == AbonmanTuru.Tam)
            {
                if (yolculuk.IadeYapilacakMi)
                {
                    List<double> iadeliUcretler = new List<double> { 27, 34.72, 40.08, 46.22, 53.99, 59.76 };
                    switch (iadeTarifesi)
                    {
                        case 0:
                            ucret = iadeliUcretler[0];
                            break;
                        case 1:
                            ucret = iadeliUcretler[1];
                            break;
                        case 2:
                            ucret = iadeliUcretler[2];
                            break;
                        case 3:
                            ucret = iadeliUcretler[3];
                            break;
                        case 4:
                            ucret = iadeliUcretler[4];
                            break;
                        case 5:
                            ucret = iadeliUcretler[5];
                            break;
                        default:
                            ucret = 0;
                            break;
                    }
                }
                else
                {
                    ucret = temelUcretler[0];
                }
            }
            else if (yolculuk.Abonman == AbonmanTuru.Ogrenci)
            {
                if (yolculuk.IadeYapilacakMi)
                {
                    List<double> iadeliUcretler = new List<double> { 13.18, 16.23, 19.33, 21.98, 25.84, 27 };
                    switch (iadeTarifesi)
                    {
                        case 0:
                            ucret = iadeliUcretler[0];
                            break;
                        case 1:
                            ucret = iadeliUcretler[1];
                            break;
                        case 2:
                            ucret = iadeliUcretler[2];
                            break;
                        case 3:
                            ucret = iadeliUcretler[3];
                            break;
                        case 4:
                            ucret = iadeliUcretler[4];
                            break;
                        case 5:
                            ucret = iadeliUcretler[5];
                            break;
                        default:
                            ucret = 0;
                            break;
                    }
                }
                else
                {
                    ucret = temelUcretler[1];
                }
            }
            else
            {
                ucret = temelUcretler[2];
            }

            return ucret;
        }
        private void DosyayaYaz<T>(string filePath, ref List<T> list)
        {
            //JSON'a yazma işlemleri
            string json = JsonConvert.SerializeObject(list, Formatting.Indented);
            File.WriteAllText(filePath, json);
        }
        private void DosyadanOku<T>(string filePath, ref List<T> list)
        {
            if (File.Exists(filePath))
            {
                //JSON'dan okuma işlemleri
                string json = File.ReadAllText(filePath);
                list = JsonConvert.DeserializeObject<List<T>>(json);
            }
            return;
        }


    }
}
