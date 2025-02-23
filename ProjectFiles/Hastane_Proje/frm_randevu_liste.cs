using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hastane_Proje
{
    public partial class frm_randevu_liste : Form
    {
        public frm_randevu_liste()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır 

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frm_randevu_liste_Load(object sender, EventArgs e)
        {

            // Randevuları data gride aktarma 

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select RandevuID as 'ID',  RandevuTarih as 'Tarih',  RandevuSaat as 'Saat',  RandevuBrans as 'Branş',  RandevuDoktor as 'Doktor',  RandevuDurum as 'Durum', HastaTC as 'Hasta TC', Sikayet as 'Şikayet' From Tbl_Randevular", bgl.baglanti());
            da.Fill(dt1);

            dataGridView1.DataSource = dt1;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
