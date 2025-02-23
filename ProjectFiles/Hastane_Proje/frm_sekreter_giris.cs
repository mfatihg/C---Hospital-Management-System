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
    public partial class frm_sekreter_giris : Form
    {
        public frm_sekreter_giris()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır

        private void frm_sekreter_giris_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select *From Tbl_Sekreter Where SekreterTC=@p1 and SekreterSifre=@p2", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", mskTC.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                frm_sekreter_detay frs = new frm_sekreter_detay();   // hasta detay forumundan fr isimli nesne türettik 
                frs.sekreter_tc = mskTC.Text; // sekreter_tc public olduğu için frs ile eriştim ve mskTC ye eşitledim
                frs.Show();      // yeni formu getir
                this.Hide();  // üstüne tıklanan formu gizle
            }

            else
            {
                MessageBox.Show("Hatalı T.C. No veya Şifre");
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
