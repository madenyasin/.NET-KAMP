using Marmaray_Revize;

namespace Marmaray
{
    public partial class FrmMain : Form
    {
        MarmaraySystem marmaraySystem;
        private List<string> marmarayDuraklari = new List<string> {
          "Gebze", "Dar�ca", "Osmangazi", "GT� � Fatih", "�ay�rova", "Tuzla", "��meler", "Ayd�ntepe", "G�zelyal�",
          "Tersane", "Kaynarca", "Pendik", "Yunus", "Kartal", "Ba�ak", "Atalar", "Cevizli", "Maltepe",
          "S�reyya Plaj�", "�dealtepe", "K���kyal�", "Bostanc�", "Suadiye", "Erenk�y", "G�ztepe", "Feneryolu",
          "S���tl��e�me", "Ayr�l�k �e�mesi", "�sk�dar", "Sirkeci", "Yenikap�", "Kazl��e�me", "Fi�ekhane",
          "Yenimahalle", "Bak�rk�y", "Atak�y", "Ye�ilyurt", "Ye�ilk�y", "Florya Akvaryum", "Florya",
          "K���k�ekmece", "Mustafa Kemal", "Halkal�"
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
