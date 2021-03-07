using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.Language
{
    public partial class SettingLanguage : CommonFormMetro
    {
        List<LanguageClass> languageClasses = new List<LanguageClass>();
        public SettingLanguage()
        {
            InitializeComponent();
            Class.valiballecommon.GetStorage().UserName = "Toluen";
            Class.valiballecommon.GetStorage().PCName = "MSI";
            
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                LanguageClass language = new LanguageClass();
                language.functionGroup = txt_functionGroup.Text;
                language.functionName = txt_functionName.Text;
                language.Tiengviet = txt_tiengViet.Text;
                language.English = txt_english.Text;
                language.Chinese = txt_Chinese.Text;
                LanguageSetting languageSetting = new LanguageSetting();
                languageSetting.InsertLanguageSetting(language);
              //  languageClasses.Add(language);
                string sqlQuerry = "select FunctionGroup,FunctionName,TiengViet,English,Chinese from t_language   ";
                sqlCON sqlcon = new sqlCON();
                DataTable dt = new DataTable();
                sqlcon.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);

                dtgv_SettingLanguage.DataSource = null;
                dtgv_SettingLanguage.DataSource = dt;
                

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Add Language ", ex.Message);
            }
        }
    

        private void Btn_Update_Click_1(object sender, EventArgs e)
        {
            try
            {
                LanguageClass language = new LanguageClass();
                language.functionGroup = txt_functionGroup.Text;
                language.functionName = txt_functionName.Text;
                language.Tiengviet = txt_tiengViet.Text;
                language.English = txt_english.Text;
                language.Chinese = txt_Chinese.Text;
                LanguageSetting languageSetting = new LanguageSetting();
                languageSetting.UpdateLanguageSetting(language);
             //   languageClasses.Add(language);
                string sqlQuerry = "select FunctionGroup,FunctionName,TiengViet,English,Chinese from t_language   ";
                sqlCON sqlcon = new sqlCON();
                DataTable dt = new DataTable();
                sqlcon.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);

                dtgv_SettingLanguage.DataSource = null;
                dtgv_SettingLanguage.DataSource = dt;


            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "update language", ex.Message);
            }
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                LanguageClass language = new LanguageClass();
                language.functionGroup = txt_functionGroup.Text;
                language.functionName = txt_functionName.Text;
                language.Tiengviet = txt_tiengViet.Text;
                language.English = txt_english.Text;
                language.Chinese = txt_Chinese.Text;
                LanguageSetting languageSetting = new LanguageSetting();
                languageSetting.DeleteRowofLanguageSetting(language);
                
                string sqlQuerry = "select FunctionGroup,FunctionName,TiengViet,English,Chinese from t_language   ";
                sqlCON sqlcon = new sqlCON();
                DataTable dt = new DataTable();
                sqlcon.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);

                dtgv_SettingLanguage.DataSource = null;
                dtgv_SettingLanguage.DataSource = dt;


            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "delete row", ex.Message);
            }
        }

        private void Tabcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    string sqlQuerry = "select FunctionGroup,FunctionName,TiengViet,English,Chinese from t_language   ";
                    sqlCON sqlcon = new sqlCON();
                    DataTable dt = new DataTable();
                    sqlcon.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);

                    dtgv_SettingLanguage.DataSource = null;
                    dtgv_SettingLanguage.DataSource = dt;
                    // Do nothing here (let's suppose that TabPage index 0 is the address information which is already loaded.
                    break;
                case 1:

                    break;
                case 2:
                   


                    break;
            }
        }

        private void Dtgv_SettingLanguage_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
               
                    try
                    {
                    txt_functionGroup.Text = (string)dtgv_SettingLanguage.Rows[e.RowIndex].Cells["functionGroup"].Value;
                    txt_functionName.Text = (string)dtgv_SettingLanguage.Rows[e.RowIndex].Cells["functionName"].Value;
                    txt_tiengViet.Text = (string)dtgv_SettingLanguage.Rows[e.RowIndex].Cells["Tiengviet"].Value;
                    txt_Chinese.Text = (string)dtgv_SettingLanguage.Rows[e.RowIndex].Cells["Chinese"].Value;
                    txt_english.Text = (string)dtgv_SettingLanguage.Rows[e.RowIndex].Cells["English"].Value;


                }
                    catch (Exception ex)
                    {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Dtgv_SettingLanguage_CellContentClick(object sender, DataGridViewCellEventArgs e)", ex.Message);


                    }

            }
        }
        private void MakeUpDatagrid(DataGridView gridView)
        {

            try
            {
                gridView.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);

                gridView.BackgroundColor = Color.LightSteelBlue;
                gridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
                gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;

                gridView.Columns["functionGroup"].HeaderText = "Function Group";
                gridView.Columns["functionName"].HeaderText = "Function Name";
                gridView.Columns["Tiengviet"].HeaderText = "Tiengviet";
                gridView.Columns["Chinese"].HeaderText = "Chinese";
                gridView.Columns["English"].HeaderText = "English";
                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "MakeUpDatagridStockOut(DataGridView gridView)", ex.Message);
            }
        }
        private void SettingLanguage_Load(object sender, EventArgs e)
        {
            try
            {
                string sqlQuerry = "select FunctionGroup,FunctionName,TiengViet,English,Chinese from t_language   ";
                sqlCON sqlcon = new sqlCON();
                DataTable dt = new DataTable();
                sqlcon.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
                dtgv_SettingLanguage.DataSource = null;
                dtgv_SettingLanguage.DataSource = dt;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "SettingLanguage_Load", ex.Message);
            }
           
        }

        private void Dtgv_SettingLanguage_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            MakeUpDatagrid(dtgv_SettingLanguage);
        }

        private void Dtgv_SettingLanguage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {

                try
                {
                    txt_functionGroup.Text = (string)dtgv_SettingLanguage.Rows[e.RowIndex].Cells["functionGroup"].Value;
                    txt_functionName.Text = (string)dtgv_SettingLanguage.Rows[e.RowIndex].Cells["functionName"].Value;
                    txt_tiengViet.Text = (string)dtgv_SettingLanguage.Rows[e.RowIndex].Cells["Tiengviet"].Value;
                    txt_Chinese.Text = (string)dtgv_SettingLanguage.Rows[e.RowIndex].Cells["Chinese"].Value;
                    txt_english.Text = (string)dtgv_SettingLanguage.Rows[e.RowIndex].Cells["English"].Value;


                }
                catch (Exception ex)
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Dtgv_SettingLanguage_CellClick(object sender, DataGridViewCellEventArgs e)", ex.Message);

                }

            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            try
            {
                LanguageClass language = new LanguageClass();
                language.functionGroup = txt_groupFilter.Text.Trim();
                language.functionName = txt_NameFilter.Text.Trim();
                LanguageSetting languageSetting = new LanguageSetting();
                DataTable dt = languageSetting.SearchLanguageSetting(language);
                dtgv_SettingLanguage.DataSource = null;
                dtgv_SettingLanguage.DataSource = dt;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Btn_Search_Click(object sender, EventArgs e)", ex.Message);
            }
           

        }

        private void Btn_Link_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Title = "Browse setting Language Excel Files";
                openFileDialog.DefaultExt = "Excel";
                openFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";
                openFileDialog.CheckFileExists = true;
                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    txt_SettingFile.Text = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Btn_Link_Click(object sender, EventArgs e)", ex.Message);
            }
           

        }

        private void Btn_uploadfile_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_SettingFile.Text != "")
                {
                    DataTable dt = new DataTable();
                    Class.ToolSupport toolSupport = new Class.ToolSupport();
                        dt = toolSupport.ReadexcelToDatatable("SettingLanguage", txt_SettingFile.Text);
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {

                        LanguageClass language = new LanguageClass();
                        language.functionGroup = dt.Rows[i][0].ToString();
                        language.functionName = dt.Rows[i][1].ToString();
                        language.Tiengviet = dt.Rows[i][2].ToString();
                        language.English = dt.Rows[i][3].ToString();
                        language.Chinese = dt.Rows[i][4].ToString();
                        LanguageSetting languageSetting = new LanguageSetting();
                        languageSetting.InsertLanguageSetting(language);
                        //  languageClasses.Add(language);
                        string sqlQuerry = "select FunctionGroup,FunctionName,TiengViet,English,Chinese from t_language   ";
                        sqlCON sqlcon = new sqlCON();
                        DataTable dta = new DataTable();
                        sqlcon.sqlDataAdapterFillDatatable(sqlQuerry, ref dta);

                        dtgv_SettingLanguage.DataSource = null;
                        dtgv_SettingLanguage.DataSource = dta;
                    }
                //    toolSupport.openExcelList("SettingLanguage", txt_SettingFile.Text, ref dt);

                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Btn_uploadfile_Click(object sender, EventArgs e)", ex.Message);
            }
        }
    }
}
