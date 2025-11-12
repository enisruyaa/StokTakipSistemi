namespace StokTakipSistemi
{
    partial class Form2
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
            this.cmbUrunler = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.numAdet = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lstsSiparisler = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numAdet)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbUrunler
            // 
            this.cmbUrunler.FormattingEnabled = true;
            this.cmbUrunler.Location = new System.Drawing.Point(52, 127);
            this.cmbUrunler.Name = "cmbUrunler";
            this.cmbUrunler.Size = new System.Drawing.Size(222, 21);
            this.cmbUrunler.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(73, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ürün Seçiniz:";
            // 
            // numAdet
            // 
            this.numAdet.Location = new System.Drawing.Point(294, 181);
            this.numAdet.Name = "numAdet";
            this.numAdet.Size = new System.Drawing.Size(68, 20);
            this.numAdet.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(46, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ürün Adedi Seçiniz:";
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnGuncelle.ForeColor = System.Drawing.Color.Gray;
            this.btnGuncelle.Location = new System.Drawing.Point(146, 295);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(135, 74);
            this.btnGuncelle.TabIndex = 7;
            this.btnGuncelle.Text = "Siparis Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            // 
            // btnSil
            // 
            this.btnSil.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnSil.ForeColor = System.Drawing.Color.Gray;
            this.btnSil.Location = new System.Drawing.Point(209, 236);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(135, 40);
            this.btnSil.TabIndex = 8;
            this.btnSil.Text = "Siparis Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            // 
            // btnEkle
            // 
            this.btnEkle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.btnEkle.ForeColor = System.Drawing.Color.Gray;
            this.btnEkle.Location = new System.Drawing.Point(52, 236);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(135, 40);
            this.btnEkle.TabIndex = 9;
            this.btnEkle.Text = "Siparis Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnTemizle
            // 
            this.btnTemizle.ForeColor = System.Drawing.Color.Gray;
            this.btnTemizle.Location = new System.Drawing.Point(604, 34);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(100, 21);
            this.btnTemizle.TabIndex = 25;
            this.btnTemizle.Text = "Seçim Temizle";
            this.btnTemizle.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 17F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(408, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 29);
            this.label4.TabIndex = 24;
            this.label4.Text = "SİPARİŞLER";
            // 
            // lstsSiparisler
            // 
            this.lstsSiparisler.FormattingEnabled = true;
            this.lstsSiparisler.Location = new System.Drawing.Point(394, 67);
            this.lstsSiparisler.Name = "lstsSiparisler";
            this.lstsSiparisler.Size = new System.Drawing.Size(358, 355);
            this.lstsSiparisler.TabIndex = 23;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTemizle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstsSiparisler);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.numAdet);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbUrunler);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.numAdet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUrunler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numAdet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnTemizle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lstsSiparisler;
    }
}