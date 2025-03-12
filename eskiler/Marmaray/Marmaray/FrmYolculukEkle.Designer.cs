namespace Marmaray
{
    partial class FrmYolculukEkle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnKaydet = new Button();
            label1 = new Label();
            chkIade = new CheckBox();
            cmbYolcu = new ComboBox();
            label2 = new Label();
            cmbBinisDurak = new ComboBox();
            label3 = new Label();
            cmbInisDurak = new ComboBox();
            label4 = new Label();
            cmbAbonmanTipi = new ComboBox();
            SuspendLayout();
            // 
            // btnKaydet
            // 
            btnKaydet.Location = new Point(204, 215);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(268, 29);
            btnKaydet.TabIndex = 5;
            btnKaydet.Text = "Kaydet";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(131, 52);
            label1.Name = "label1";
            label1.Size = new Size(44, 20);
            label1.TabIndex = 1;
            label1.Text = "Yolcu";
            // 
            // chkIade
            // 
            chkIade.AutoSize = true;
            chkIade.Location = new Point(204, 185);
            chkIade.Name = "chkIade";
            chkIade.Size = new Size(154, 24);
            chkIade.TabIndex = 4;
            chkIade.Text = "İade yapılacak mı?";
            chkIade.UseVisualStyleBackColor = true;
            // 
            // cmbYolcu
            // 
            cmbYolcu.FormattingEnabled = true;
            cmbYolcu.Location = new Point(204, 49);
            cmbYolcu.Name = "cmbYolcu";
            cmbYolcu.Size = new Size(268, 28);
            cmbYolcu.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(78, 83);
            label2.Name = "label2";
            label2.Size = new Size(97, 20);
            label2.TabIndex = 1;
            label2.Text = "Binilen Durak";
            // 
            // cmbBinisDurak
            // 
            cmbBinisDurak.FormattingEnabled = true;
            cmbBinisDurak.Location = new Point(204, 83);
            cmbBinisDurak.Name = "cmbBinisDurak";
            cmbBinisDurak.Size = new Size(268, 28);
            cmbBinisDurak.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(85, 117);
            label3.Name = "label3";
            label3.Size = new Size(88, 20);
            label3.TabIndex = 1;
            label3.Text = "İnilen Durak";
            // 
            // cmbInisDurak
            // 
            cmbInisDurak.FormattingEnabled = true;
            cmbInisDurak.Location = new Point(204, 117);
            cmbInisDurak.Name = "cmbInisDurak";
            cmbInisDurak.Size = new Size(268, 28);
            cmbInisDurak.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(68, 154);
            label4.Name = "label4";
            label4.Size = new Size(107, 20);
            label4.TabIndex = 1;
            label4.Text = "Abonman Türü";
            // 
            // cmbAbonmanTipi
            // 
            cmbAbonmanTipi.FormattingEnabled = true;
            cmbAbonmanTipi.Location = new Point(204, 151);
            cmbAbonmanTipi.Name = "cmbAbonmanTipi";
            cmbAbonmanTipi.Size = new Size(268, 28);
            cmbAbonmanTipi.TabIndex = 3;
            // 
            // FrmYolculukEkle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(579, 335);
            Controls.Add(cmbAbonmanTipi);
            Controls.Add(cmbInisDurak);
            Controls.Add(label4);
            Controls.Add(cmbBinisDurak);
            Controls.Add(label3);
            Controls.Add(cmbYolcu);
            Controls.Add(label2);
            Controls.Add(chkIade);
            Controls.Add(label1);
            Controls.Add(btnKaydet);
            Name = "FrmYolculukEkle";
            Text = "FrmYolculukEkle";
            Load += FrmYolculukEkle_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnKaydet;
        private Label label1;
        private CheckBox chkIade;
        private ComboBox cmbYolcu;
        private Label label2;
        private ComboBox cmbBinisDurak;
        private Label label3;
        private ComboBox cmbInisDurak;
        private Label label4;
        private ComboBox cmbAbonmanTipi;
    }
}