using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    class SqlTLVN2
    {
        public SqlConnection conn = DBUtils.GetTLVN2DBConnection(); //get from user database

        public string sqlExecuteScalarString(string sql)
        {
            String outstring;
            conn.Open();
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                if (cmd.ExecuteScalar() != null)
                {
                    outstring = cmd.ExecuteScalar().ToString();
                    conn.Close();
                    return outstring;
                }
                else
                {
                    conn.Close();
                    return String.Empty;
                }
            }
            catch (Exception ex)
            {
               SystemLog.Output(SystemLog.MSG_TYPE.Err, "sqlExecuteScalarString(string sql)", ex.Message);
                conn.Close();
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
               SystemLog.Output(SystemLog.MSG_TYPE.Err, "getComboBoxData(string sql, ref ComboBox cmb)", ex.Message);

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
               SystemLog.Output(SystemLog.MSG_TYPE.Err, " getComboBoxData(string sql, ref ComboBox cmb, ref ComboBox cmb2)", ex.Message);

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
               SystemLog.Output(SystemLog.MSG_TYPE.Err, " sqlDataAdapterFillDatatable(string sql, ref DataTable dt)", ex.Message);
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
                    if (result_message_show) { MessageBox.Show("Successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Information); }
                    conn.Close();
                    return true;
                }
                else
                {
                 //   MessageBox.Show("Not successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
               SystemLog.Output(SystemLog.MSG_TYPE.Err, " sqlExecuteNonQuery(string sql, bool result_message_show)", ex.Message);
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
               SystemLog.Output(SystemLog.MSG_TYPE.Err, " sqlDatatablePermision(string buttonText, Button btn_common)", ex.Message);

            }
        }
        }
}
