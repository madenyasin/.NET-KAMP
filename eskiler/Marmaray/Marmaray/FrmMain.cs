using Marmaray_Revize;

namespace Marmaray
{
    public partial class FrmMain : Form
    {
        MarmaraySystem marmaraySystem;
        private List<string> marmarayDuraklari = new List<string> {
          "Gebze", "Darýca", "Osmangazi", "GTÜ – Fatih", "Çayýrova", "Tuzla", "Ýçmeler", "Aydýntepe", "Güzelyalý",
          "Tersane", "Kaynarca", "Pendik", "Yunus", "Kartal", "Baþak", "Atalar", "Cevizli", "Maltepe",
          "Süreyya Plajý", "Ýdealtepe", "Küçükyalý", "Bostancý", "Suadiye", "Erenköy", "Göztepe", "Feneryolu",
          "Söðütlüçeþme", "Ayrýlýk Çeþmesi", "Üsküdar", "Sirkeci", "Yenikapý", "Kazlýçeþme", "Fiþekhane",
          "Yenimahalle", "Bakýrköy", "Ataköy", "Yeþilyurt", "Yeþilköy", "Florya Akvaryum", "Florya",
          "Küçükçekmece", "Mustafa Kemal", "Halkalý"
        };

        public FrmMain()
        {
            InitializeComponent();
            marmaraySystem = new MarmaraySystem();
            DuraklariEkle();

        }
        private void DuraklariEkle()
        {
            int counter = 0;
            foreach (var item in marmarayDuraklari)
            {
                marmaraySystem.DurakEkle(new Durak { Name = item, Id = counter });
                counter++;
            }
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnKisiEkle_Click(object sender, EventArgs e)
        {
            FrmKisiEkle frmKisiEkle = new FrmKisiEkle(marmaraySystem);
            frmKisiEkle.ShowDialog();
        }

        private void btnKisileriListele_Click(object sender, EventArgs e)
        {
            FrmKisiListele frmKisiListele = new FrmKisiListele(marmaraySystem);
            frmKisiListele.ShowDialog();

        }

        private void btnYolculukEkle_Click(object sender, EventArgs e)
        {
            FrmYolculukEkle frmYolculukEkle = new FrmYolculukEkle(marmaraySystem);
            frmYolculukEkle.ShowDialog();
        }

        private void btnRapor_Click(object sender, EventArgs e)
        {
            FrmRapor frmRapor = new FrmRapor(marmaraySystem);
            frmRapor.ShowDialog();
        }
    }
}
