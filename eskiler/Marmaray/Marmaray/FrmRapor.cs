using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Marmaray
{
    internal partial class FrmRapor : Form
    {
        MarmaraySystem _marmaraySystem;
        public FrmRapor(MarmaraySystem marmaraySystem)
        {
            InitializeComponent();
            _marmaraySystem = marmaraySystem;
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            // Rapor verilerini hesapla
            double toplamUcret = 0;
            int toplamYolcu = 0;
            int toplamIadeSayisi = 0;
            StringBuilder rapor = new StringBuilder();

            foreach (var yolculuk in _marmaraySystem.Yolculuklar)
            {
                toplamUcret += yolculuk.Ucret;
                toplamYolcu++;
                if (yolculuk.IadeYapilacakMi)
                {
                    toplamIadeSayisi++;
                }
            }

            // Rapor metnini oluştur
            rapor.AppendLine("----------------------Z RAPORU------------------------");
            rapor.AppendLine($"Toplam Yolcu Sayısı: {toplamYolcu}");
            rapor.AppendLine($"Toplam Alınan Ücret: {toplamUcret:C}");
            rapor.AppendLine($"Toplam İade Sayısı: {toplamIadeSayisi}");
            rapor.AppendLine("-------------------------------------------------------");
            rapor.AppendLine();
            rapor.AppendLine("-----------------YOLCULUK LİSTESİ----------------------");
            rapor.AppendLine();

            if (_marmaraySystem.Yolculuklar.Count == 0)
            {
                rapor.AppendLine("Henüz yolculuk kaydı bulunmamaktadır.");
            }
            else
            {
                foreach (var yolculuk in _marmaraySystem.Yolculuklar)
                {
                    rapor.AppendLine(yolculuk.ToString());
                }
            }
            rapor.AppendLine("-------------------------------------------------------");

            // RichTextBox'a rapor metnini yazdır
            richTextBox1.Text = rapor.ToString();
        }
    }
}
