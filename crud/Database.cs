using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace crud
{
    class Database
    {
        private SqlConnection con;
        private SqlCommand cmd;

        public Database()
        {
            con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-6G6UPA0;Initial Catalog=work2;Integrated Security=True";

        }
        public void opencon()
        {
            con.Open();
        }
        public void closecon()
        {
            con.Close();
        }
        public int save_del_update(string query)
        {
            int rows;
            try
            {
                opencon();
            }
            catch (SqlException es)
            {

                Console.WriteLine(es.ToString());
            }
            cmd = new SqlCommand(query, con);
            rows = cmd.ExecuteNonQuery();
            cmd.Dispose();
            closecon();
            return rows;


        }
        public DataTable GetData(string query)
        {
            try
            {
                opencon();
            }
            catch (SqlException es)
            {

                Console.WriteLine(es.ToString());
            }
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            closecon();
            return dt;
        }

    }
}