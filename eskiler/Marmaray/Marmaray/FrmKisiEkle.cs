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
    internal partial class FrmKisiEkle : Form
    {
        MarmaraySystem _marmaraySystem;
        public FrmKisiEkle(MarmaraySystem marmaraySystem)
        {
            InitializeComponent();
            _marmaraySystem = marmaraySystem;
        }

        private void btnKisiEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAdSoyad.Text) || !int.TryParse(txtId.Text, out int kisiId))
            {
                MessageBox.Show("Lütfen geçerli ad soyad ve ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Kisi yeniKisi = new Kisi()
            {
                AdSoyad = txtAdSoyad.Text,
                Id = kisiId
            };

            _marmaraySystem.KisiEkle(yeniKisi);
            MessageBox.Show("Kişi başarıyla eklendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
