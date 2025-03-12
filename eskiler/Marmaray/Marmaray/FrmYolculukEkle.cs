using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Marmaray_Revize;

namespace Marmaray
{
    internal partial class FrmYolculukEkle : Form
    {
        MarmaraySystem _marmaraySystem;
        public FrmYolculukEkle(MarmaraySystem marmaraySystem)
        {
            InitializeComponent();
            _marmaraySystem = marmaraySystem;
        }

        private void FrmYolculukEkle_Load(object sender, EventArgs e)
        {
            cmbYolcu.DataSource = null;
            cmbBinisDurak.DataSource = null;
            cmbInisDurak.DataSource = null;
            cmbAbonmanTipi.DataSource = null;


            cmbYolcu.DataSource = _marmaraySystem.Kisiler;
            cmbYolcu.DisplayMember = "AdSoyad";

            // Durak listesini kopyalayarak bağımsız kaynaklar oluştur
            cmbBinisDurak.DataSource = _marmaraySystem.Duraklar.ToList(); // .ToList() ile yeni liste oluşturulur
            cmbBinisDurak.DisplayMember = "Name";

            cmbInisDurak.DataSource = _marmaraySystem.Duraklar.ToList(); // Yine .ToList() ile yeni liste
            cmbInisDurak.DisplayMember = "Name";

            cmbAbonmanTipi.DataSource = Enum.GetValues(typeof(AbonmanTuru));
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (cmbYolcu.SelectedItem == null || cmbBinisDurak.SelectedItem == null || cmbInisDurak.SelectedItem == null || cmbAbonmanTipi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen tüm alanları seçiniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Kisi yolcu = (Kisi)cmbYolcu.SelectedItem;
            Durak binisDurak = (Durak)cmbBinisDurak.SelectedItem;
            Durak inisDurak = (Durak)cmbInisDurak.SelectedItem;
            AbonmanTuru abonmanTuru = (AbonmanTuru)cmbAbonmanTipi.SelectedItem;
            bool iadeYapilacakMi = chkIade.Checked;

            Yolculuk yeniYolculuk = new Yolculuk()
            {
                Yolcu = yolcu,
                Binis = binisDurak,
                Inis = inisDurak,
                Abonman = abonmanTuru,
                IadeYapilacakMi = iadeYapilacakMi
            };

            _marmaraySystem.YolculukEkle(yeniYolculuk);
            MessageBox.Show($"{yeniYolculuk.Yolcu.AdSoyad} için yolculuk eklendi. Ücret: {yeniYolculuk.Ucret:C}", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
