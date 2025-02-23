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
    public partial class frm_doktor_bilgi_guncelle : Form
    {
        public frm_doktor_bilgi_guncelle()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır

        public string TCno;  // TC No dan gelen bilgileri taşımak için

        private void frm_doktor_bilgi_guncelle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TCno;

            SqlCommand komut = new SqlCommand("Select  *From Tbl_Doktorlar Where DoktorTC=@d1", bgl.baglanti());

            komut.Parameters.AddWithValue("@d1", mskTC.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                cmbBrans.Text = dr[3].ToString();
                mskTC.Text = dr[4].ToString();
                txtSifre.Text = dr[5].ToString();
            }
            bgl.baglanti().Close();

            // Branşları combo box a aktarma 
            SqlCommand komut3 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());

            SqlDataReader dr3 = komut3.ExecuteReader();

            while (dr3.Read())
            {
                cmbBrans.Items.Add(dr3[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Doktorlar set DoktorBrans=@d1, DoktorSifre=@d2 where DoktorTC=@d3", bgl.baglanti());

            komut2.Parameters.AddWithValue("@d1", cmbBrans.Text);
            komut2.Parameters.AddWithValue("@d2", txtSifre.Text);
            komut2.Parameters.AddWithValue("@d3", mskTC.Text);

            komut2.ExecuteNonQuery(); //insert, update ve delete işlemlerini gerçekleştirmek için kullanılır

            bgl.baglanti().Close();

            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
