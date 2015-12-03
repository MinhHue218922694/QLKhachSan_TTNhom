using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


public class Database
{
    #region Bien
    //region để tạo biên
    private SqlConnection sqlConnect;
    private SqlCommand sqlCom;
    private DataTable dt;
    SqlDataAdapter sqlDataAdapter = null;

    private string strConnect = @"Data Source=./;Initial Catalog=QL_KHO;Integrated Security=True";

    #endregion

    public void Connect()   //kết nối
    {
        sqlConnect = new SqlConnection(strConnect);
        sqlConnect.Open();
    }

    public void Disconnect()  //đóng kết nối
    {
        sqlConnect.Close();
        sqlConnect.Dispose();
    }

    public DataTable GetTable(string query, params SqlParameter[] parameter)
    {
        Connect();
        dt = new DataTable();
        sqlCom = new SqlCommand(query, sqlConnect);
        sqlCom.CommandType = CommandType.StoredProcedure; //kết nối vào stor
        sqlCom.Parameters.AddRange(parameter);
        try
        {
            dt.Load(sqlCom.ExecuteReader());  //try catch để bắt lỗi
        }
        catch
        {
            MessageBox.Show("Lỗi kết nối cơ sở dữ liệu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
            finally           //
        {
            sqlCom.Parameters.Clear();
            sqlCom.Dispose();
            Disconnect();
        }
        return dt;
    }
    public DataTable GetTable(string query)
    {
        sqlDataAdapter = new SqlDataAdapter(query, strConnect);
        dt = new DataTable();
        //try
        //{
        sqlDataAdapter.Fill(dt);
        //}
        //catch
        //{
        //    MessageBox.Show("Lỗi kết nối", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //}
        return dt;
    }
    public void Execute(string query, params SqlParameter[] parameter)  //thực thi câu lệnh
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

    public string GetString(string query)
    {
        string s = "";
        dt = GetTable(query);
        if (dt.Rows.Count == 0)
            return s;
        return dt.Rows[0][0].ToString();
    }
}
