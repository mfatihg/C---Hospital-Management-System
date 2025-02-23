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
    public partial class frm_doktor_paneli : Form
    {
        public frm_doktor_paneli()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır


        private void frm_doktor_paneli_Load(object sender, EventArgs e)
        {
            // Doktorları datagrid de gösterme

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select  DoktorAd as 'Ad', DoktorSoyad as 'Soyad', DoktorBrans as 'Branş', DoktorTC as 'TC No' From Tbl_Doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;


            // Branşları combo box a aktarma 

            SqlCommand komut2 = new SqlCommand("Select BransAd From Tbl_Branslar", bgl.baglanti());

            SqlDataReader dr2 = komut2.ExecuteReader();

            while (dr2.Read())
            {
                cmbBrans.Items.Add(dr2[0]);
            }

            bgl.baglanti().Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            SqlCommand komut1 = new SqlCommand("Insert into Tbl_Doktorlar (DoktorAd, DoktorSoyad, DoktorTC, DoktorBrans, DoktorSifre) values (@d1, @d2, @d3, @d4, @d5)", bgl.baglanti());


            komut1.Parameters.AddWithValue("@d1", txtAd.Text);
            komut1.Parameters.AddWithValue("@d2", txtSoyad.Text);
            komut1.Parameters.AddWithValue("@d3", mskTC.Text);
            komut1.Parameters.AddWithValue("@d4", cmbBrans.Text);
            komut1.Parameters.AddWithValue("@d5", txtSifre.Text);

            komut1.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Doktor Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

            SqlCommand komut4 = new SqlCommand("Update Tbl_Doktorlar set DoktorAd=@d1, DoktorSoyad=@d2, DoktorBrans=@d4, DoktorSifre=@d5 Where DoktorTC=@d3", bgl.baglanti());

            komut4.Parameters.AddWithValue("@d1", txtAd.Text);
            komut4.Parameters.AddWithValue("@d2", txtSoyad.Text);
            komut4.Parameters.AddWithValue("@d3", mskTC.Text);
            komut4.Parameters.AddWithValue("@d4", cmbBrans.Text);
            komut4.Parameters.AddWithValue("@d5", txtSifre.Text);

            komut4.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            SqlCommand komut3 = new SqlCommand("Delete From Tbl_Doktorlar Where DoktorTC=@d1", bgl.baglanti());

            komut3.Parameters.AddWithValue("@d1", mskTC.Text);

            komut3.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtAd.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtSoyad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            mskTC.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();

            //Sifreyi de veritabanından çekme
            SqlCommand komut5 = new SqlCommand("Select  DoktorSifre From Tbl_Doktorlar Where DoktorTC=@d1", bgl.baglanti());

            komut5.Parameters.AddWithValue("@d1", mskTC.Text);

            SqlDataReader dr5 = komut5.ExecuteReader();

            while (dr5.Read())
            {
                txtSifre.Text = dr5[0].ToString();

                bgl.baglanti().Close();
            }
        }
    }
}
