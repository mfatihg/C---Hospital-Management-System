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
    public partial class frm_hasta_uye_ol : Form
    {
        public frm_hasta_uye_ol()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnKayit_Click(object sender, EventArgs e)
        {

           SqlCommand komut = new SqlCommand("insert into tbl_Hastalar (HastaAd, HastaSoyad, HastaTC, HastaTel, HastaCinsiyet, HastaSifre, EPosta, KanGrup, Alerjiler, Tanilar, Ilaclar, Yas, Kilo, Boy, AcilDurumKisi, AcilTel) values (@p1, @p2, @p3, @p4, @p5, @p6, @p7, @p8, @p9, @p10, @p11, @p12, @p13, @p14, @p15, @p16)", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTC.Text);
            komut.Parameters.AddWithValue("@p4", mskTel.Text);
            komut.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            komut.Parameters.AddWithValue("@p6", txtSifre.Text);
            komut.Parameters.AddWithValue("@p7", txtEPosta.Text);
            komut.Parameters.AddWithValue("@p8", cmbKanGrup.Text);
            komut.Parameters.AddWithValue("@p9", txtAlerji.Text);
            komut.Parameters.AddWithValue("@p10", txtTani.Text);
            komut.Parameters.AddWithValue("@p11", txtIlaclar.Text);
            komut.Parameters.AddWithValue("@p12", mskYas.Text);
            komut.Parameters.AddWithValue("@p13", mskKilo.Text);
            komut.Parameters.AddWithValue("@p14", mskBoy.Text);
            komut.Parameters.AddWithValue("@p15", txtAcilKisi.Text);
            komut.Parameters.AddWithValue("@p16", mskAcilTelefon.Text);

            komut.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Kaydınız Gerçekleşmiştir. Şifreniz: " + txtSifre.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void frm_hasta_uye_ol_Load(object sender, EventArgs e)
        {

        }
    }
}
    

