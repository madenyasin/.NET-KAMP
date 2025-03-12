namespace Marmaray
{
    partial class FrmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnKisileriListele = new Button();
            btnKisiEkle = new Button();
            btnYolculukEkle = new Button();
            btnRapor = new Button();
            SuspendLayout();
            // 
            // btnKisileriListele
            // 
            btnKisileriListele.Location = new Point(251, 73);
            btnKisileriListele.Name = "btnKisileriListele";
            btnKisileriListele.Size = new Size(195, 54);
            btnKisileriListele.TabIndex = 0;
            btnKisileriListele.Text = "Kişi Listele";
            btnKisileriListele.UseVisualStyleBackColor = true;
            btnKisileriListele.Click += btnKisileriListele_Click;
            // 
            // btnKisiEkle
            // 
            btnKisiEkle.Location = new Point(251, 133);
            btnKisiEkle.Name = "btnKisiEkle";
            btnKisiEkle.Size = new Size(195, 54);
            btnKisiEkle.TabIndex = 1;
            btnKisiEkle.Text = "Kişi Ekle";
            btnKisiEkle.UseVisualStyleBackColor = true;
            btnKisiEkle.Click += btnKisiEkle_Click;
            // 
            // btnYolculukEkle
            // 
            btnYolculukEkle.Location = new Point(251, 193);
            btnYolculukEkle.Name = "btnYolculukEkle";
            btnYolculukEkle.Size = new Size(195, 54);
            btnYolculukEkle.TabIndex = 2;
            btnYolculukEkle.Text = "Yolculuk Ekle";
            btnYolculukEkle.UseVisualStyleBackColor = true;
            btnYolculukEkle.Click += btnYolculukEkle_Click;
            // 
            // btnRapor
            // 
            btnRapor.Location = new Point(251, 253);
            btnRapor.Name = "btnRapor";
            btnRapor.Size = new Size(195, 54);
            btnRapor.TabIndex = 3;
            btnRapor.Text = "Z Raporu Görüntüle";
            btnRapor.UseVisualStyleBackColor = true;
            btnRapor.Click += btnRapor_Click;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(734, 363);
            Controls.Add(btnRapor);
            Controls.Add(btnYolculukEkle);
            Controls.Add(btnKisiEkle);
            Controls.Add(btnKisileriListele);
            Name = "FrmMain";
            Text = "Form1";
            Load += FrmMain_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnKisileriListele;
        private Button btnKisiEkle;
        private Button btnYolculukEkle;
        private Button btnRapor;
    }
}
