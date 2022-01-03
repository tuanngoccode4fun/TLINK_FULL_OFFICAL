using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using UploadDataToDatabase;

namespace UploadDataToDatabase
{
   public class sqlSFT
    {

        public SqlConnection conn = DBUtils.GetSFTDBConnection(); //get from user database

        public string sqlExecuteScalarString(string sql)
        {
            String outstring;
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                outstring = cmd.ExecuteScalar().ToString();
                return outstring;
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "sqlSFT : sqlExecuteScalarString(string sql)", ex.Message);
              
                return String.Empty;
            }
            //    conn.Close();

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
                cmb.Items.Clear();

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    cmb.Items.Add(row[0].ToString());
                }
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "SFT : getComboBoxData(string sql, ref ComboBox cmb)", ex.Message);
               

            }
            conn.Close();
        }
        public void getComboBoxData(string sql, ref ComboBox cmb, ref ComboBox cmb2)
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
                cmb.Items.Clear();
                cmb2.Items.Clear();
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    if (cmb.Items != null && cmb.Items.Contains(row[0].ToString()) == false)
                        cmb.Items.Add(row[0].ToString());
                    if (cmb2.Items != null && cmb2.Items.Contains(row[1].ToString()) == false)
                        cmb2.Items.Add(row[1].ToString());
                }
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "SFT :  getComboBoxData", ex.Message);
               

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
                Logfile.Output(StatusLog.Error, "SFT : Database Responce", ex.Message);
              

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
                    if (result_message_show) {
                        Logfile.Output(StatusLog.Normal, "Successful!", "Database Responce");
                       
                    }
                    conn.Close();
                    return true;
                }
                else
                {
                    Logfile.Output(StatusLog.Normal, "Not successful!", "Database Responce");
                  
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Not successful!", ex.Message);
             
                conn.Close();
                return false;
            }
        }

        public void sqlDatatablePermision(string buttonText, Button btn_common)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlCommand cmd = new SqlCommand();
                SqlDataAdapter adapter = new SqlDataAdapter();
                {
                    cmd.CommandText = "select  button , status from m_permission where permission =  '" + Class.valiballecommon.GetStorage().Permission + "'";
                    cmd.Connection = conn;
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dt);
                }
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i][0].ToString() == buttonText)
                        {
                            if (dt.Rows[i][1].ToString() == "True")
                            { btn_common.Enabled = true; }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Database Responce", ex.Message);
               


            }

        }
    }
}
