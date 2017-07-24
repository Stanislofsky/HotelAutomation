namespace OtelProje
{
    partial class İslemler
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
            this.btnkayit = new System.Windows.Forms.Button();
            this.btndurum = new System.Windows.Forms.Button();
            this.btncik = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnkayit
            // 
            this.btnkayit.Location = new System.Drawing.Point(124, 81);
            this.btnkayit.Name = "btnkayit";
            this.btnkayit.Size = new System.Drawing.Size(109, 57);
            this.btnkayit.TabIndex = 0;
            this.btnkayit.Text = "MÜŞTERİ GİRİŞ/ÇIKIŞ";
            this.btnkayit.UseVisualStyleBackColor = true;
            this.btnkayit.Click += new System.EventHandler(this.btnkayit_Click);
            // 
            // btndurum
            // 
            this.btndurum.Location = new System.Drawing.Point(43, 162);
            this.btndurum.Name = "btndurum";
            this.btndurum.Size = new System.Drawing.Size(109, 57);
            this.btndurum.TabIndex = 2;
            this.btndurum.Text = "ODA DURUMLARI";
            this.btndurum.UseVisualStyleBackColor = true;
            this.btndurum.Click += new System.EventHandler(this.btndurum_Click);
            // 
            // btncik
            // 
            this.btncik.Location = new System.Drawing.Point(389, 277);
            this.btncik.Name = "btncik";
            this.btncik.Size = new System.Drawing.Size(75, 23);
            this.btncik.TabIndex = 4;
            this.btncik.Text = "ÇIKIŞ";
            this.btncik.UseVisualStyleBackColor = true;
            this.btncik.Click += new System.EventHandler(this.btncik_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 57);
            this.button1.TabIndex = 5;
            this.button1.Text = "MÜŞTERİ LİSTESİ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(364, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 108);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // İslemler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(466, 302);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btncik);
            this.Controls.Add(this.btndurum);
            this.Controls.Add(this.btnkayit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "İslemler";
            this.Text = "İslemler";
            this.Load += new System.EventHandler(this.İslemler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnkayit;
        private System.Windows.Forms.Button btndurum;
        private System.Windows.Forms.Button btncik;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}