using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UploadDataToDatabase;

namespace UploadDataToDatabase
{
    class SQLHR
    {
        public SqlConnection conn = DBUtils.GetDBHRConnection(); //get from user database
        public string sqlExecuteScalarString(string sql)
        {

            String outstring;
            try
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                outstring = cmd.ExecuteScalar().ToString();
                conn.Close();
                return outstring;
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Database Responce: SQLERPTarget", ex.Message);

                return String.Empty;
            }


        }
        public void getComboBoxData(string sql, ref ComboBox cmb)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sql;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                adapter.Dispose();
                cmd.Dispose();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cmb.Items.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Database Responce: SQLERPTarget", ex.Message);


            }
            conn.Close();
        }
        public void sqlDataAdapterFillDatatable(string sql, ref DataTable dt)
        {
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                {
                    cmd.CommandText = sql;
                    cmd.Connection = conn;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Database Responce: SQLERPTarget", ex.Message);


            }
        }
        public bool sqlExecuteNonQuery(string sql, bool result_message_show)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sql, conn);

                int response = cmd.ExecuteNonQuery();
                if (response >= 1)
                {
                    if (result_message_show)
                    {
                        Logfile.Output(StatusLog.Error, "Successful!", "Database Responce");

                    }
                    conn.Close();
                    return true;
                }
                else
                {
                    Logfile.Output(StatusLog.Error, "Not successful!", "Database Responce");

                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Not successful!: Database Responce", ex.Message);

                conn.Close();
                return false;
            }
        }
    }
}
