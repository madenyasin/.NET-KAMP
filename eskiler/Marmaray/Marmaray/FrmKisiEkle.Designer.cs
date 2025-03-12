namespace Marmaray
{
    partial class FrmKisiEkle
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
            btnKisiEkle = new Button();
            txtId = new TextBox();
            txtAdSoyad = new TextBox();
            SuspendLayout();
            // 
            // btnKisiEkle
            // 
            btnKisiEkle.Location = new Point(74, 130);
            btnKisiEkle.Name = "btnKisiEkle";
            btnKisiEkle.Size = new Size(218, 29);
            btnKisiEkle.TabIndex = 2;
            btnKisiEkle.Text = "Ekle";
            btnKisiEkle.UseVisualStyleBackColor = true;
            btnKisiEkle.Click += btnKisiEkle_Click;
            // 
            // txtId
            // 
            txtId.Location = new Point(74, 64);
            txtId.Name = "txtId";
            txtId.PlaceholderText = "Kişi Id";
            txtId.Size = new Size(218, 27);
            txtId.TabIndex = 0;
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(74, 97);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.PlaceholderText = "Ad Soyad";
            txtAdSoyad.Size = new Size(218, 27);
            txtAdSoyad.TabIndex = 1;
            // 
            // FrmKisiEkle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 238);
            Controls.Add(txtAdSoyad);
            Controls.Add(txtId);
            Controls.Add(btnKisiEkle);
            Name = "FrmKisiEkle";
            Text = "FrmKisiEkle";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnKisiEkle;
        private TextBox txtId;
        private TextBox txtAdSoyad;
    }
}