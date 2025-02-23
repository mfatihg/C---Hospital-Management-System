namespace Hastane_Proje
{
    partial class frm_hasta_bul1
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
            this.btnHastaDetay = new System.Windows.Forms.Button();
            this.mskTC = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHastaDetay
            // 
            this.btnHastaDetay.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.btnHastaDetay.Location = new System.Drawing.Point(275, 177);
            this.btnHastaDetay.Name = "btnHastaDetay";
            this.btnHastaDetay.Size = new System.Drawing.Size(143, 56);
            this.btnHastaDetay.TabIndex = 11;
            this.btnHastaDetay.Text = "Hasta Detay";
            this.btnHastaDetay.UseVisualStyleBackColor = false;
            this.btnHastaDetay.Click += new System.EventHandler(this.btnHastaDetay_Click);
            // 
            // mskTC
            // 
            this.mskTC.Location = new System.Drawing.Point(231, 115);
            this.mskTC.Mask = "00000000000";
            this.mskTC.Name = "mskTC";
            this.mskTC.Size = new System.Drawing.Size(187, 36);
            this.mskTC.TabIndex = 7;
            this.mskTC.ValidatingType = typeof(int);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(215, 28);
            this.label2.TabIndex = 8;
            this.label2.Text = "T.C. Kimlik Numarası:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(194, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 67);
            this.label1.TabIndex = 6;
            this.label1.Text = "Hasta Ara";
            // 
            // frm_hasta_bul1
            // 
            this.AcceptButton = this.btnHastaDetay;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(498, 245);
            this.Controls.Add(this.btnHastaDetay);
            this.Controls.Add(this.mskTC);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Corbel", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frm_hasta_bul1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hasta Ara";
            this.Load += new System.EventHandler(this.frm_hasta_bul1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHastaDetay;
        private System.Windows.Forms.MaskedTextBox mskTC;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}