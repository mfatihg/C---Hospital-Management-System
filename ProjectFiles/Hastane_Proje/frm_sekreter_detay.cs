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
    public partial class frm_sekreter_detay : Form
    {
        public frm_sekreter_detay()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır

        public string sekreter_tc;  // TC No yu hasta detaya taşımak için

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rchDuyuru_TextChanged(object sender, EventArgs e)
        {

        }

        private void frm_sekreter_detay_Load(object sender, EventArgs e)
        {
            
            lblTC.Text = sekreter_tc; // TC NO yu taşıma

            // Sekreter Bilgi Çekme

            SqlCommand komut = new SqlCommand("Select SekreterAdSoyad, SekreterTelefon, SekreterPosta From Tbl_Sekreter Where SekreterTC=@p1", bgl.baglanti());

            komut.Parameters.AddWithValue("@p1", lblTC.Text);

            SqlDataReader dr1 = komut.ExecuteReader();

            while (dr1.Read())
            {
                lblAdSoyad.Text = dr1[0].ToString();
                lblTelefon.Text = dr1[1].ToString();
                lblPosta.Text = dr1[2].ToString();
            }
            bgl.baglanti().Close();


            // Branşları data gride aktarma 

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select BransAd as 'Branşlar' From Tbl_Branslar", bgl.baglanti());
            da.Fill(dt1);

            dataGridView1.DataSource = dt1;

            // Doktorları data gride aktarma 

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select (DoktorAd + ' ' + DoktorSoyad) as 'Ad Soyad', DoktorBrans as 'Branş' From Tbl_Doktorlar", bgl.baglanti());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            // Branşları combo box a aktarma 


            SqlCommand komut3 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());

            SqlDataReader dr3 = komut3.ExecuteReader();

            while (dr3.Read())
            {
                cmbBrans.Items.Add(dr3[0]);
            }

            bgl.baglanti().Close();

            // Akitf Randevuları Çekme

            DataTable dt7 = new DataTable();
            SqlDataAdapter da7 = new SqlDataAdapter("Select RandevuID as 'ID', RandevuTarih as 'Tarih', RandevuSaat as 'Saat', RandevuBrans as 'Branş', RandevuDoktor as 'Doktor', HastaTC as 'TC', Sikayet as 'Şikayet' From Tbl_Randevular where RandevuDurum=1", bgl.baglanti());
            da7.Fill(dt7);

            dataGridView3.DataSource = dt7;

            // Müsait Randevuları Çekme

            DataTable dt8 = new DataTable();
            SqlDataAdapter da8 = new SqlDataAdapter("Select RandevuID as 'ID', RandevuTarih as 'Tarih', RandevuSaat as 'Saat', RandevuBrans as 'Branş', RandevuDoktor as 'Doktor' From Tbl_Randevular where RandevuDurum=0", bgl.baglanti());
            da8.Fill(dt8);

            dataGridView4.DataSource = dt8;

        }

        private void lblTC_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRandevuKaydet_Click(object sender, EventArgs e)
        {
            // sekreter randevu olustur

            SqlCommand komut2 = new SqlCommand("Insert into Tbl_Randevular (RandevuTarih, RandevuSaat, RandevuBrans, RandevuDoktor, RandevuDurum, HastaTC, Sikayet) values (@r1, @r2, @r3, @r4, @r5, @r6, @r7)", bgl.baglanti());

            komut2.Parameters.AddWithValue("@r1", mskTarih.Text);
            komut2.Parameters.AddWithValue("@r2", mskSaat.Text);
            komut2.Parameters.AddWithValue("@r3", cmbBrans.Text);
            komut2.Parameters.AddWithValue("@r4", cmbDoktor.Text);
            komut2.Parameters.AddWithValue("@r5", chkDurum.Checked);
            komut2.Parameters.AddWithValue("@r6", mskTC.Text);
            komut2.Parameters.AddWithValue("@r7", rchSikayet.Text);



            komut2.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Randevu Oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            // branşı seçince veriler gelsin (doktor çekme)
            cmbDoktor.Items.Clear(); // cmbDoktor içini temizle Branş değiştikçe
            SqlCommand komut4 = new SqlCommand("Select DoktorAd, DoktorSoyad From Tbl_Doktorlar where DoktorBrans=@p1", bgl.baglanti());

            komut4.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dr4 = komut4.ExecuteReader();

            while (dr4.Read())
            {
                cmbDoktor.Items.Add(dr4[0] + " " + dr4[1]);
            }

            bgl.baglanti().Close();
        }

        private void btnDuyuruOlustur_Click(object sender, EventArgs e)
        {

            SqlCommand komut5 = new SqlCommand("Insert into Tbl_Duyurular (Duyuru) values (@d1)", bgl.baglanti());

            komut5.Parameters.AddWithValue("@d1", rchDuyuru.Text);
            
            SqlDataReader dr5 = komut5.ExecuteReader();

            bgl.baglanti().Close();

            MessageBox.Show("Duyuru Oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void btnDoktorPaneli_Click(object sender, EventArgs e)
        {

            frm_doktor_paneli drp = new frm_doktor_paneli();   // doktor panel forumundan fr isimli nesne türettik 
            drp.Show();      // yeni formu getir

        }

        private void btnBransPaneli_Click(object sender, EventArgs e)
        {

            frm_brans_paneli frb = new frm_brans_paneli();   // branş paneli forumundan fr isimli nesne türettik 
            frb.Show();      // yeni formu getir
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRandevuListesi_Click(object sender, EventArgs e)
        {

            frm_randevu_liste frb = new frm_randevu_liste();   // branş paneli forumundan fr isimli nesne türettik 
            frb.Show();      // yeni formu getir
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void btnRandevuGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut6 = new SqlCommand("Update Tbl_Randevular set RandevuTarih=@r1, RandevuSaat=@r2, RandevuBrans=@r3, RandevuDoktor=@r4, RandevuDurum=@r5, HastaTC= @r6, Sikayet=@r7 Where RandevuID=@r8", bgl.baglanti());

            komut6.Parameters.AddWithValue("@r1", mskTarih.Text);
            komut6.Parameters.AddWithValue("@r2", mskSaat.Text);
            komut6.Parameters.AddWithValue("@r3", cmbBrans.Text);
            komut6.Parameters.AddWithValue("@r4", cmbDoktor.Text);
            komut6.Parameters.AddWithValue("@r5", chkDurum.Checked);
            komut6.Parameters.AddWithValue("@r6", mskTC.Text);
            komut6.Parameters.AddWithValue("@r7", rchSikayet.Text);
            komut6.Parameters.AddWithValue("@r8", txtID.Text);



            komut6.ExecuteNonQuery(); //insert, update ve delete işlemlerini gerçekleştirmek için kullanılır

            bgl.baglanti().Close();

            MessageBox.Show("Randevu Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void btnHastaKaydet_Click(object sender, EventArgs e)
        {
            frm_hasta_bul1 frb = new frm_hasta_bul1();   // sekreter detay forumundan fr isimli nesne türettik 
            frb.Show();      // yeni formu getir
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            cmbBrans.SelectedIndex = -1;
            cmbDoktor.SelectedIndex = -1;
            mskTC.Clear();
            rchSikayet.Clear();
            chkDurum.Checked = false;

            int secilen = dataGridView3.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView3.Rows[secilen].Cells[0].Value.ToString();
            mskTarih.Text = dataGridView3.Rows[secilen].Cells[1].Value.ToString();
            mskSaat.Text = dataGridView3.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView3.Rows[secilen].Cells[3].Value.ToString();
            cmbDoktor.Text = dataGridView3.Rows[secilen].Cells[4].Value.ToString();
            mskTC.Text = dataGridView3.Rows[secilen].Cells[5].Value.ToString();
            rchSikayet.Text = dataGridView3.Rows[secilen].Cells[6].Value.ToString();

            SqlCommand komut = new SqlCommand("SELECT RandevuDurum FROM Tbl_Randevular WHERE HastaTC = @p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", mskTC.Text);

            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                // RandevuDurum kolonu 0/1 ya da True/False olarak geliyorsa, bool'a çevirip CheckBox'ı ayarla
                chkDurum.Checked = Convert.ToBoolean(dr["RandevuDurum"]);
            }
            dr.Close();

            // Gerekliyse bağlantıyı kapatın
            bgl.baglanti().Close();




        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            cmbBrans.SelectedIndex = -1;
            cmbDoktor.SelectedIndex = -1;
            mskTC.Clear();
            rchSikayet.Clear();
            chkDurum.Checked = false;

            int secilen = dataGridView4.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView4.Rows[secilen].Cells[0].Value.ToString();
            mskTarih.Text = dataGridView4.Rows[secilen].Cells[1].Value.ToString();
            mskSaat.Text = dataGridView4.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView4.Rows[secilen].Cells[3].Value.ToString();
            cmbDoktor.Text = dataGridView4.Rows[secilen].Cells[4].Value.ToString();

        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Randevular set RandevuDurum=0, HastaTC='', Sikayet='' Where RandevuID=@r1", bgl.baglanti());

            komut2.Parameters.AddWithValue("@r1", txtID.Text);

            komut2.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Randevu İptal Edildi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnTumIptal_Click(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Update Tbl_Randevular set RandevuDurum=0, HastaTC='', Sikayet='' Where RandevuDurum=1 and RandevuTarih='" + mskTarih.Text + "'", bgl.baglanti());

            komut2.ExecuteNonQuery();

            bgl.baglanti().Close();

            MessageBox.Show(mskTarih.Text + " Tarihli Randevuların Hepsi İptal Edildi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
    }


