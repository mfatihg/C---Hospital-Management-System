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
    public partial class frm_hasta_tum_bilgi : Form
    {
        public frm_hasta_tum_bilgi()
        {
            InitializeComponent();
        }

        sqlBaglantisi bgl = new sqlBaglantisi();  // bgl çağır 
        public string tc;  // TC No yu hasta detaya taşımak için

        private void frm_hasta_tum_bilgi_Load(object sender, EventArgs e)
        {



            // Hastanın Tüm Bilgilerini data gride aktarma 

            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select HastaAd as 'Ad', HastaSoyad as 'Soyad', HastaTel as 'Telefon', EPosta as 'E-Posta', KanGrup as 'Kan Grubu', Yas as 'Yaş', Kilo as 'Kilo', Boy as 'Boy (cm)' From Tbl_Hastalar Where HastaTC=" + tc, bgl.baglanti());
            da.Fill(dt1);

            dataGridView1.DataSource = dt1;
        }
    }
}
