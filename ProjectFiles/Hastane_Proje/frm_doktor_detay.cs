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
    public partial class frm_doktor_detay : Form
    {
        public frm_doktor_detay()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır

        public string tc;  // TC No yu hasta detaya taşımak için

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void frm_doktor_detay_Load(object sender, EventArgs e)
        {

            lblTC.Text = tc; // TC NO yu taşıma


            // Ad Soyad Çekme

            SqlCommand komut = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar Where DoktorTC=@d1", bgl.baglanti());

            komut.Parameters.AddWithValue("@d1", lblTC.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();

            // Randevu Listesi

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select RandevuTarih as 'Tarih', RandevuSaat as 'Saat', RandevuDurum as 'Durum', HastaTC as 'TC No', Sikayet as 'Şikayet' From Tbl_Randevular Where RandevuDurum=1 and RandevuDoktor='" + lblAdSoyad.Text + "'", bgl.baglanti());

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            bgl.baglanti().Close();
            dataGridView1.ClearSelection();

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select RandevuTarih as 'Tarih', RandevuSaat as 'Saat' From Tbl_Randevular Where RandevuDurum=0 and RandevuDoktor='" + lblAdSoyad.Text + "'", bgl.baglanti());

            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            bgl.baglanti().Close();
            dataGridView2.ClearSelection();



        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            frm_doktor_bilgi_guncelle fr = new frm_doktor_bilgi_guncelle();   // doktor bilgi güncelle forumundan fr isimli nesne türettik 
            fr.TCno = lblTC.Text;    // bilgi_düzenle deki public olan TCno ya deger ataması yaptık 
            fr.Show();      // yeni formu getir
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            frm_duyurular fr = new frm_duyurular();   // duyurular  forumundan fr isimli nesne türettik 
            fr.Show();      // yeni formu getir
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            frm_girisler frb = new frm_girisler();   // sekreter detay forumundan fr isimli nesne türettik 
            frb.Show();      // yeni formu getir
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Randevu Detay kısmında Şikayeti göster

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            rchSikayet.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            
        
    }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

   
    }
    }

