using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Hastane_Proje
{
    internal class sqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-ANRHM5JI;Initial Catalog=HastaTakip;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
