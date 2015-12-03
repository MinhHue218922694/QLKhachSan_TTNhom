using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.DB
{
    public class MyConnection
    {
        public static string ConnectionString { get; set; }
        private SqlConnection _conn = new SqlConnection();
        private SqlCommand _command = new SqlCommand();
        private SqlDataAdapter _adapter;

        public MyConnection()
        {
            _command.Connection = _conn;
            _adapter = new SqlDataAdapter(_command);
        }

        public MyConnection(string s)
        {
            ConnectionString = s;
            _conn.ConnectionString = s;
            _command.Connection = _conn;
            _adapter = new SqlDataAdapter(_command);
        }
        private void Connect()
        {
            _conn.ConnectionString = ConnectionString;
            _conn.Open();
        }

        private void Disconnect()
        {
            _command.Parameters.Clear();
            _conn.Dispose();
        }
        public void ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            _command.CommandText = query;
            if (query.Contains(" "))
                _command.CommandType = CommandType.Text;
            else
                _command.CommandType = CommandType.StoredProcedure;

            if (parameters.Length > 0)
                _command.Parameters.AddRange(parameters);

            Connect();
            _command.ExecuteNonQuery();
            Disconnect();
        }

        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            _command.CommandText = query;
            if (query.Contains(" "))
                _command.CommandType = CommandType.Text;
            else
                _command.CommandType = CommandType.StoredProcedure;

            if (parameters.Length > 0)
                _command.Parameters.AddRange(parameters);

            DataTable table = new DataTable();
           
            _adapter.Fill(table);
            
            return table;
        }
    }


}
