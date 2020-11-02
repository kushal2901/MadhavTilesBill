using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace MadhavTilesBill
{
    class Connectionclass
    {
        public SqlConnection con;

        public void getconnection()
        {
            con = new SqlConnection(@"Data Source=LAPTOP-4CLJBGMO\MSSQLSERVER02;Initial Catalog=Billdata;Integrated Security=True");
            con.Open();
        }
        public void closeconnection()
        {
            con.Close();
        }
    }
}
