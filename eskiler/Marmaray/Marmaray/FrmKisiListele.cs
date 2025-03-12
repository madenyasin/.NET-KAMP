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
    internal partial class FrmKisiListele : Form
    {
        private MarmaraySystem _marmaraySystem;
        public FrmKisiListele(MarmaraySystem marmaraySystem)
        {
            InitializeComponent();
            _marmaraySystem = marmaraySystem;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FrmKisiListele_Load(object sender, EventArgs e)
        {
            listBoxKisiler.Items.Clear();
            foreach (Kisi? kisi in _marmaraySystem.Kisiler)
            {
                listBoxKisiler.Items.Add(kisi.ToString());
            }

        }
    }
}
