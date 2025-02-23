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
    public partial class frm_bilgi_duzenle : Form
    {
        public frm_bilgi_duzenle()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır

        public string TCno;  // TC No dan gelen bilgileri taşımak için

        private void frm_bilgi_duzenle_Load(object sender, EventArgs e)
        {
            mskTC.Text = TCno;

            SqlCommand komut = new SqlCommand("Select  *From Tbl_Hastalar Where HastaTC=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", mskTC.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                txtAd.Text = dr[1].ToString();
                txtSoyad.Text = dr[2].ToString();
                mskTel.Text = dr[4].ToString();
                cmbCinsiyet.Text = dr[5].ToString();
                txtSifre.Text = dr[6].ToString();
                txtEPosta.Text = dr[7].ToString();
                cmbKanGrup.Text = dr[8].ToString();
                txtAlerji.Text = dr[9].ToString();
                txtTani.Text = dr[10].ToString();
                txtIlaclar.Text = dr[11].ToString();
                mskYas.Text = dr[12].ToString();
                mskKilo.Text = dr[13].ToString();
                mskBoy.Text = dr[14].ToString();
                txtAcilKisi.Text = dr[15].ToString();
                mskAcilTelefon.Text = dr[16].ToString();

                bgl.baglanti().Close();

            }


        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {

            SqlCommand komut2 = new SqlCommand("Update Tbl_Hastalar set HastaAd=@p1, HastaSoyad=@p2, HastaTel=@p3, HastaCinsiyet=@p4, HastaSifre=@p5, EPosta=@p6, KanGrup=@p7, Alerjiler=@p8, Tanilar=@p9, Ilaclar=@p10, Yas=@p11, Kilo=@p12, Boy=@p13, AcilDurumKisi=@p14, AcilTel=@p15 where HastaTC=@p16", bgl.baglanti());

            komut2.Parameters.AddWithValue("@p1", txtAd.Text);
            komut2.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut2.Parameters.AddWithValue("@p3", mskTel.Text);
            komut2.Parameters.AddWithValue("@p4", cmbCinsiyet.Text);
            komut2.Parameters.AddWithValue("@p5", txtSifre.Text);
            komut2.Parameters.AddWithValue("@p6", txtEPosta.Text);
            komut2.Parameters.AddWithValue("@p7", cmbKanGrup.Text);
            komut2.Parameters.AddWithValue("@p8", txtAlerji.Text);
            komut2.Parameters.AddWithValue("@p9", txtTani.Text);
            komut2.Parameters.AddWithValue("@p10", txtIlaclar.Text);
            komut2.Parameters.AddWithValue("@p11", mskYas.Text);
            komut2.Parameters.AddWithValue("@p12", mskKilo.Text);
            komut2.Parameters.AddWithValue("@p13", mskBoy.Text);
            komut2.Parameters.AddWithValue("@p14", txtAcilKisi.Text);
            komut2.Parameters.AddWithValue("@p15", mskAcilTelefon.Text);
            komut2.Parameters.AddWithValue("@p16", mskTC.Text);

            komut2.ExecuteNonQuery(); //insert, update ve delete işlemlerini gerçekleştirmek için kullanılır

            bgl.baglanti().Close();

            MessageBox.Show("Bilgileriniz Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
