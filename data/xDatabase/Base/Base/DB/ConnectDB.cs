using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DB
{
    public class ConnectDB
    {
        #region Bien
        SqlConnection sqlConnect;
        SqlCommand sqlCom;
        DataTable dt;
        SqlDataAdapter sqlDataAdapter;
        string strConnect = "Data Source=HOANGTHIANH\\SQL2012;Initial Catalog=QLKS;Integrated Security=True";
        #endregion

        public void Connect()
        {
            sqlConnect = new SqlConnection(strConnect);
            sqlConnect.Open();
        }

        public void Disconnect()
        {
            sqlConnect.Close();
            sqlConnect.Dispose();
        }

        public DataTable GetTable(string query, params SqlParameter[] parameter)
        {
            dt = new DataTable();
            sqlCom = new SqlCommand(query, sqlConnect);
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.Parameters.AddRange(parameter);
            dt.Load(sqlCom.ExecuteReader());
            sqlCom.Parameters.Clear();
            sqlCom.Dispose();
            Disconnect();
            return dt;
        }
        public DataTable GetTable(string query)
        {
            sqlDataAdapter = new SqlDataAdapter(query, strConnect);
            dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            return dt;
        }

        public void Excute(string query, params SqlParameter[] parameter)
        {
            Connect();
            sqlCom = new SqlCommand(query, sqlConnect);
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.Parameters.AddRange(parameter);
            sqlCom.ExecuteNonQuery();
            Disconnect();
        }

        public bool Check(string query, params SqlParameter[] parameter)
        {
            return GetTable(query, parameter).Rows.Count > 0;
        }

        public bool Check(string query)
        {
            return GetTable(query).Rows.Count > 0;
        }

    }
}
