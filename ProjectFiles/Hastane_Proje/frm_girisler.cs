using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Proje
{
    public partial class frm_girisler : Form
    {
        public frm_girisler()
        {
            InitializeComponent();
        }

        private void btnHastaGirisi_Click(object sender, EventArgs e)
        {
            frm_hasta_giris fr = new frm_hasta_giris();   // hasta giriş forumundan fr isimli nesne türettik 
            fr.Show();      // yeni formu getir
            this.Hide();  // üstüne tıklanan formu gizle
        }

        private void btnDoktorGirisi_Click(object sender, EventArgs e)
        {
            frm_doktor_giris fr = new frm_doktor_giris();   // doktor giriş forumundan fr isimli nesne türettik 
            fr.Show();      // yeni formu getir
            this.Hide();  // üstüne tıklanan formu gizle
        }

        private void btnSekreterGirisi_Click(object sender, EventArgs e)
        {
            frm_sekreter_giris fr = new frm_sekreter_giris();   // doktor giriş forumundan fr isimli nesne türettik 
            fr.Show();      // yeni formu getir
            this.Hide();  // üstüne tıklanan formu gizle
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
