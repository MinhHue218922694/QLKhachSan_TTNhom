using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace QLTV
{
    public class AccessData
    {
        //Thuoc tinh 
        protected string m_connectionString;
        protected SqlConnection connection;
        protected SqlDataAdapter da = null;
        protected SqlCommand command;
        //Phuong thuc  
        public AccessData()
        {
            m_connectionString = @"Data Source=NGOCHOA;Initial Catalog=D:\C#\BAITAP\QLTV\QLTV\BIN\DEBUG\QUANLYTHUVIEN.MDF;Integrated Security=True";//chuoi ket noi csdl
        }
        public string getconnect()
        {
            return @"Data Source=NGOCHOA;Initial Catalog=D:\C#\BAITAP\QLTV\QLTV\BIN\DEBUG\QUANLYTHUVIEN.MDF;Integrated Security=True";
        }
        //Ket noi 
<<<<<<< HEAD
=======
        // ket noi co sở dữ liệu
        // sao không làm theo mô hình 3 lớp nhỉ?
>>>>>>> origin/master
        public void connect()
        {
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể kết nối được với Server\n" + ex.Message, "Lỗi chương trình");
                //Application.Exit(); 
            }
        }
        //Tat ket noi 
        public void disconnect()
        {
            try
            {
                connection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
        //Lay ra du lieu ra table
        DataView dv;
        public DataTable TaoBang(String sqlString)
        {
            connect();
            DataTable ds = new DataTable();
            da = new SqlDataAdapter(sqlString, connection);
            da.Fill(ds);
            dv = new DataView(ds);
            
            disconnect();
            return ds;
        }
<<<<<<< HEAD
=======
        // bài này nhìn quen quen
>>>>>>> origin/master
        //Dung cho cac thao tac insert, delete, update 
        public void ExcuteNonQuery(string sqlString)
        {
            connect();
            command = new SqlCommand(sqlString, connection);
            command.ExecuteNonQuery();
            disconnect();
        }
<<<<<<< HEAD
        //Lay 1 gia tri du lieu ra 
=======
        //Lay 1 gia tri du lieu ra
        //lấy ra đâu nhỉ
>>>>>>> origin/master
        public object executeScalar(string sqlString)
        {
            connect();
            command = new SqlCommand(sqlString, connection);
            object o = command.ExecuteScalar();
            disconnect();
            return o;
        }

        public string ConnectionString
        {
            get
            {
                return m_connectionString;
            }
            set
            {
                m_connectionString = value;
            }
        }
    }
}
