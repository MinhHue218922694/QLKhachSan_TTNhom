using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


public class Database
{


    private SqlConnection sqlConnect;
    private SqlCommand sqlCom;
    private DataTable dt;
    SqlDataAdapter sqlDataAdapter = null;

    private string strConnect = @"Data Source=NANA;Initial Catalog=QuanLyThuVien;Integrated Security=True";



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
        Connect();
        dt = new DataTable();
        sqlCom = new SqlCommand(query, sqlConnect);
        sqlCom.CommandType = CommandType.StoredProcedure;
        sqlCom.Parameters.AddRange(parameter);
        try
        {
            dt.Load(sqlCom.ExecuteReader());
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        finally
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

        sqlDataAdapter.Fill(dt);
        return dt;
    }
    public void Execute(string query, params SqlParameter[] parameter)
    {
        try
        {
            Connect();
            sqlCom = new SqlCommand(query, sqlConnect);
            sqlCom.CommandType = CommandType.StoredProcedure;
            sqlCom.Parameters.AddRange(parameter);
            sqlCom.ExecuteNonQuery();
            Disconnect();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
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

    public void Exe(string command)
    {
        Connect();
        sqlCom.CommandType = CommandType.Text;

        Disconnect();
    }
}
