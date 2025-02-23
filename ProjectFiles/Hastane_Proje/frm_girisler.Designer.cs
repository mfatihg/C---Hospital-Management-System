namespace Hastane_Proje
{
    partial class frm_girisler
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_girisler));
            this.btnHastaGirisi = new System.Windows.Forms.Button();
            this.btnSekreterGirisi = new System.Windows.Forms.Button();
            this.btnDoktorGirisi = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCikis = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnHastaGirisi
            // 
            this.btnHastaGirisi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnHastaGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHastaGirisi.BackgroundImage")));
            this.btnHastaGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHastaGirisi.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnHastaGirisi.Location = new System.Drawing.Point(26, 255);
            this.btnHastaGirisi.Name = "btnHastaGirisi";
            this.btnHastaGirisi.Size = new System.Drawing.Size(234, 207);
            this.btnHastaGirisi.TabIndex = 0;
            this.btnHastaGirisi.UseVisualStyleBackColor = false;
            this.btnHastaGirisi.Click += new System.EventHandler(this.btnHastaGirisi_Click);
            // 
            // btnSekreterGirisi
            // 
            this.btnSekreterGirisi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSekreterGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSekreterGirisi.BackgroundImage")));
            this.btnSekreterGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSekreterGirisi.Location = new System.Drawing.Point(529, 255);
            this.btnSekreterGirisi.Name = "btnSekreterGirisi";
            this.btnSekreterGirisi.Size = new System.Drawing.Size(234, 207);
            this.btnSekreterGirisi.TabIndex = 1;
            this.btnSekreterGirisi.UseVisualStyleBackColor = false;
            this.btnSekreterGirisi.Click += new System.EventHandler(this.btnSekreterGirisi_Click);
            // 
            // btnDoktorGirisi
            // 
            this.btnDoktorGirisi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDoktorGirisi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDoktorGirisi.BackgroundImage")));
            this.btnDoktorGirisi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoktorGirisi.Location = new System.Drawing.Point(279, 255);
            this.btnDoktorGirisi.Name = "btnDoktorGirisi";
            this.btnDoktorGirisi.Size = new System.Drawing.Size(234, 207);
            this.btnDoktorGirisi.TabIndex = 2;
            this.btnDoktorGirisi.UseVisualStyleBackColor = false;
            this.btnDoktorGirisi.Click += new System.EventHandler(this.btnDoktorGirisi_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(123, 474);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 18);
            this.label1.TabIndex = 3;
            this.label1.Text = "Hasta";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(369, 474);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Doktor";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(613, 474);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Sekreter";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(601, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 135);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Segoe Script", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textBox1.Location = new System.Drawing.Point(26, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(569, 70);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "KEVSER HASTANESİ";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // btnCikis
            // 
            this.btnCikis.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnCikis.Location = new System.Drawing.Point(193, 579);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(448, 42);
            this.btnCikis.TabIndex = 8;
            this.btnCikis.Text = "Çıkış";
            this.btnCikis.UseVisualStyleBackColor = true;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // frm_girisler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(808, 679);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDoktorGirisi);
            this.Controls.Add(this.btnSekreterGirisi);
            this.Controls.Add(this.btnHastaGirisi);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_girisler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giriş";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSekreterGirisi;
        private System.Windows.Forms.Button btnDoktorGirisi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnHastaGirisi;
        private System.Windows.Forms.Button btnCikis;
    }
}

