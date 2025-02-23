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
    public partial class frm_brans_paneli : Form
    {
        public frm_brans_paneli()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır

        private void frm_brans_paneli_Load(object sender, EventArgs e)
        {

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select  BransID as 'ID', BransAd as 'Branş' From Tbl_Branslar", bgl.baglanti());
            da1.Fill(dt1);
            dataGridView1.DataSource = dt1;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {

            //Branş ekle

            SqlCommand komut1 = new SqlCommand("Insert into Tbl_Branslar (BransAd) values (@b1)", bgl.baglanti());


            komut1.Parameters.AddWithValue("@b1", txtBransAd.Text);

            komut1.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Branş Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            SqlCommand komut2 = new SqlCommand("Delete From Tbl_Branslar Where BransID=@b1", bgl.baglanti());

            komut2.Parameters.AddWithValue("@b1", txtID.Text);

            komut2.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("Update Tbl_Branslar set BransAd=@b1 Where BransID=@b2", bgl.baglanti());

            komut3.Parameters.AddWithValue("@b1", txtBransAd.Text);
            komut3.Parameters.AddWithValue("@b2", txtID.Text);
         

            komut3.ExecuteNonQuery();

            bgl.baglanti().Close();
            MessageBox.Show("Kayıt Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            txtID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtBransAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
      
        }
    }
}
