using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane_Proje
{
    public partial class frm_hasta_giris : Form
    {
        public frm_hasta_giris()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır


        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void frm_hasta_giris_Load(object sender, EventArgs e)
        {

        }

        private void linkUyeOl_Click(object sender, EventArgs e)
        {
            frm_hasta_uye_ol fr = new frm_hasta_uye_ol();   // hasta giriş forumundan fr isimli nesne türettik 
            fr.Show();      // yeni formu getir
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select *From Tbl_Hastalar Where HastaTC=@p1 and HastaSifre=@p2", bgl.baglanti());


            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                frm_hasta_detay fr = new frm_hasta_detay();   // hasta detay forumundan fr isimli nesne türettik 
                fr.tc = mskTC.Text; // tc public olduğu için fr ile eriştim ve mskTC ye eşitledim
                fr.Show();      // yeni formu getir
                this.Hide();  // üstüne tıklanan formu gizle
            }

            else
            {
                MessageBox.Show("Hatalı T.C. No veya Şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bgl.baglanti().Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frm_girisler fr = new frm_girisler();   //  girişler forumundan fr isimli nesne türettik 
            fr.Show();      // yeni formu getir
            this.Hide(); 
        }
    }
}
