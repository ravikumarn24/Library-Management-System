using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAssignment
{
    class DBConnection
    {
        private string conn, sql_str;
        System.Data.SqlClient.SqlDataAdapter da;
        public string ConnectionString
        {
            set
            {
                conn = value;
            }
        }
        public string SqlString
        {
            set
            {
                sql_str = value;
            }
        }
        public System.Data.DataSet getConnection
        {
           get { return myDataset(); }
        }
        private System.Data.DataSet myDataset()
        {
        System.Data.SqlClient.SqlConnection c = new System.Data.SqlClient.SqlConnection(conn);
            c.Open();
            da = new System.Data.SqlClient.SqlDataAdapter(sql_str, c);
            System.Data.DataSet ds = new System.Data.DataSet();
            da.Fill(ds, "Table_data_1");
            c.Close();
            return ds;

        }
        public void UpdateDatabase(System.Data.DataSet ds)
        {
            System.Data.SqlClient.SqlCommandBuilder build= new System.Data.SqlClient.SqlCommandBuilder(da);
            da.Update(ds);
        }
    }
}
