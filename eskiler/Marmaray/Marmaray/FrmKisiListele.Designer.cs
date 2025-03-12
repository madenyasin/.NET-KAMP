namespace Marmaray
{
    partial class FrmKisiListele
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
            listBoxKisiler = new ListBox();
            SuspendLayout();
            // 
            // listBoxKisiler
            // 
            listBoxKisiler.FormattingEnabled = true;
            listBoxKisiler.Location = new Point(12, 12);
            listBoxKisiler.Name = "listBoxKisiler";
            listBoxKisiler.Size = new Size(776, 424);
            listBoxKisiler.TabIndex = 0;
            listBoxKisiler.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // FrmKisiListele
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxKisiler);
            Name = "FrmKisiListele";
            Text = "FrmKisiListele";
            Load += FrmKisiListele_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxKisiler;
    }
}