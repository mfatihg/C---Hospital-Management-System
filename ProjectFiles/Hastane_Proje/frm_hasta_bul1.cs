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
    public partial class frm_hasta_bul1 : Form
    {
        public frm_hasta_bul1()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır

        private void frm_hasta_bul1_Load(object sender, EventArgs e)
        {

        }

        private void btnHastaDetay_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select *From Tbl_Hastalar Where HastaTC=@p1", bgl.baglanti());


            komut.Parameters.AddWithValue("@p1", mskTC.Text);

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
                MessageBox.Show("Hatalı T.C. No", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            bgl.baglanti().Close();
        }
    }
}
