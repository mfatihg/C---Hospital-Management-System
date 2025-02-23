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
    public partial class frm_hasta_detay : Form
    {
        public frm_hasta_detay()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır

        public string tc;  // TC No yu hasta detaya taşımak için

        private void frm_hasta_detay_Load(object sender, EventArgs e)
        {

            lblTC.Text = tc; // TC NO yu taşıma

            // Hasta Bilgiler Çekme

            SqlCommand komut = new SqlCommand("Select HastaAd, HastaSoyad, HastaTel, EPosta, KanGrup, Yas, Kilo, Boy From Tbl_Hastalar Where HastaTC=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", lblTC.Text);

            SqlDataReader dr = komut.ExecuteReader();

            while (dr.Read())
            {
                lblAdSoyad.Text = dr[0] + " " + dr[1];
                lblTelefon.Text = dr[2].ToString();
                lblEPosta.Text = dr[3].ToString();
                lblKanGrup.Text = dr[4].ToString();
                lblYas.Text = dr[5].ToString();
                lblKilo.Text = dr[6].ToString();
                lblBoy.Text = dr[7].ToString();

            }
            bgl.baglanti().Close();

            // Randevu Geçmişi

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select RandevuID as 'ID', RandevuTarih as 'Tarih', RandevuSaat as 'Saat', RandevuBrans as 'Branş', RandevuDoktor as 'Doktor', Sikayet as 'Şikayet' From Tbl_Randevular Where RandevuDurum=1 and HastaTC='" + lblTC.Text + "'", bgl.baglanti());

            da.Fill(dt);
            dataGridView1.DataSource = dt;


            // Branş Çekme 
            // komut2 ve dr2 kullanıldı dr ve komut zaten bu kod metninde kullanıldığı için

            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());

            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }

            bgl.baglanti().Close();

            dataGridView1.ClearSelection();

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            // branşı seçince veriler gelsin (doktor çekme)
            cmbDoktor.Items.Clear(); // cmb içini temizle
            SqlCommand komut3 = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());

            komut3.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr3 = komut3.ExecuteReader();

            while (dr3.Read())
            {
                cmbDoktor.Items.Add(dr3[0] + " " + dr3[1]);
            }

            bgl.baglanti().Close();

        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select *From Tbl_Randevular where RandevuBrans='" + cmbBrans.Text + "' and RandevuDoktor='" + cmbDoktor.Text + "' and RandevuDurum=0", bgl.baglanti());
            da.Fill(dt);

            dataGridView2.DataSource = dt;
        }

        private void lnkBilgiGuncelle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            frm_bilgi_duzenle fr = new frm_bilgi_duzenle();   // bilgi düzenle  forumundan fr isimli nesne türettik 
            fr.TCno = lblTC.Text;    // bilgi_düzenle deki public olan TCno ya deger ataması yaptık 
            fr.Show();      // yeni formu getir


        }

        private void btnCikis_Click(object sender, EventArgs e)
        {

            frm_girisler frb = new frm_girisler();   // sekreter detay forumundan fr isimli nesne türettik 
            frb.Show();      // yeni formu getir
            this.Hide();
        }

        private void btnRandevuIptal_Click(object sender, EventArgs e)
        {
            SqlCommand komut8 = new SqlCommand("Update Tbl_Randevular set RandevuDurum=0, HastaTC='', Sikayet='' Where RandevuDurum=1 and RandevuID='" + txtRandevuID.Text + "'", bgl.baglanti());

            komut8.ExecuteNonQuery();

            bgl.baglanti().Close();

            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            string tarih= dataGridView2.Rows[secilen].Cells[1].Value.ToString();


            MessageBox.Show(tarih + " Tarihli Randevunuz İptal Edildi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            txtRandevuID.Clear();
            cmbBrans.SelectedIndex = -1;
            cmbDoktor.SelectedIndex = -1;
            rchsikayet.Clear();

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            cmbBrans.SelectedIndex = -1;
            cmbDoktor.SelectedIndex = -1;
            rchsikayet.Clear();

            int secilen = dataGridView2.SelectedCells[0].RowIndex;

            txtRandevuID.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
            cmbBrans.Text = dataGridView2.Rows[secilen].Cells[3].Value.ToString();
            cmbDoktor.Text = dataGridView2.Rows[secilen].Cells[4].Value.ToString();
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {

            SqlCommand komut4 = new SqlCommand("Update Tbl_Randevular set RandevuDurum=1, HastaTC=@r1, Sikayet=@r2 Where RandevuID=@r3", bgl.baglanti());

            komut4.Parameters.AddWithValue("@r1", lblTC.Text);
            komut4.Parameters.AddWithValue("@r2", rchsikayet.Text);
            komut4.Parameters.AddWithValue("@r3", txtRandevuID.Text);
 
            komut4.ExecuteNonQuery(); //insert, update ve delete işlemlerini gerçekleştirmek için kullanılır

            bgl.baglanti().Close();

            MessageBox.Show("Randevu Alındı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            txtRandevuID.Clear();
            cmbBrans.SelectedIndex = -1;
            cmbDoktor.SelectedIndex = -1;
            rchsikayet.Clear();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            cmbBrans.SelectedIndex = -1;
            cmbDoktor.SelectedIndex = -1;
            rchsikayet.Clear();

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtRandevuID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            cmbDoktor.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            rchsikayet.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();

        }

        private void lnkTumBilgiler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            SqlCommand komut = new SqlCommand("Select *From Tbl_Hastalar Where HastaTC=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", lblTC.Text);

            SqlDataReader dr = komut.ExecuteReader();

            if (dr.Read())
            {
                frm_hasta_tum_bilgi fr = new frm_hasta_tum_bilgi();   // branş paneli forumundan fr isimli nesne türettik 
                fr.tc = lblTC.Text; // tc public olduğu için fr ile eriştim ve mskTC ye eşitledim
                fr.Show();      // yeni formu getir
            }
        }
    }
}
