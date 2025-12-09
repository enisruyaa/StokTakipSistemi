namespace StokTakipSistemi
{
    partial class Form3
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnSiparis = new System.Windows.Forms.Button();
            this.btnUrun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(26, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(415, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yapmak İstediğiniz İçlemi Seçiniz";
            // 
            // btnSiparis
            // 
            this.btnSiparis.Location = new System.Drawing.Point(242, 101);
            this.btnSiparis.Name = "btnSiparis";
            this.btnSiparis.Size = new System.Drawing.Size(127, 23);
            this.btnSiparis.TabIndex = 1;
            this.btnSiparis.Text = "Sipariş Eklemek İçin Tıklayınız";
            this.btnSiparis.UseVisualStyleBackColor = true;
            this.btnSiparis.Click += new System.EventHandler(this.btnSiparis_Click);
            // 
            // btnUrun
            // 
            this.btnUrun.Location = new System.Drawing.Point(109, 101);
            this.btnUrun.Name = "btnUrun";
            this.btnUrun.Size = new System.Drawing.Size(127, 23);
            this.btnUrun.TabIndex = 1;
            this.btnUrun.Text = "Ürün Eklemek İçin Tıklayınız";
            this.btnUrun.UseVisualStyleBackColor = true;
            this.btnUrun.Click += new System.EventHandler(this.btnUrun_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(467, 191);
            this.Controls.Add(this.btnUrun);
            this.Controls.Add(this.btnSiparis);
            this.Controls.Add(this.label1);
            this.Name = "Form3";
            this.Text = "Hoş Geldiniz";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSiparis;
        private System.Windows.Forms.Button btnUrun;
    }
}