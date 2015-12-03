using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QLBMT_TTNhom
{
    public class DataConnect
    {
        public static string ConnectString = @"Data Source=admin;Initial Catalog=QLBH_MayTinh;Integrated Security=True";
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataAdapter adapter;
        public DataConnect()
        {
            conn = new SqlConnection(ConnectString);

            cmd = new SqlCommand();
            cmd.Connection = conn;

            adapter = new SqlDataAdapter(cmd);
        }
        public void Check()
        {
            conn.Open();
            conn.Close();
        }

        /// <summary>
        /// Thực hiện câu lệnh không truy vấn sử dụng Proc hoặc câu lệnh
        /// </summary>
        /// <param name="query">câu lệnh hoặc tên proc</param>
        /// <param name="sqlParams">danh sách tham số nếu có</param>
        public void ExecuteNonQuery(string query, params SqlParameter[] sqlParams)
        {
            try
            {
                // Kiem tra xem ma trung hay khong
                //Kiểm tra xem là câu lệnh hay là Proc
                if (query.Contains(" "))
                    cmd.CommandType = CommandType.Text;
                else
                    cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = query;

                cmd.Parameters.Clear();
                if (sqlParams.Length > 0) cmd.Parameters.AddRange(sqlParams);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception E)// Cac cong viec can lam khi co loi
            {
                System.Windows.Forms.MessageBox.Show(E.Message);
            }


            finally// Cac cong viec luon can thuc hien du loi hay khong
            {
                conn.Close();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="query"></param>
        /// <param name="sqlParams"></param>
        /// <returns></returns>
        public DataTable ExecuteQuery(string query, params SqlParameter[] sqlParams)
        {

            DataTable table = new DataTable();

            //Kiểm tra xem là câu lệnh hay là Proc
            if (query.Contains(" "))
                cmd.CommandType = CommandType.Text;
            else
                cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = query;

            cmd.Parameters.Clear();
            if (sqlParams.Length > 0)
                cmd.Parameters.AddRange(sqlParams);
            adapter.Fill(table);
            return table;

        }

    }
}
