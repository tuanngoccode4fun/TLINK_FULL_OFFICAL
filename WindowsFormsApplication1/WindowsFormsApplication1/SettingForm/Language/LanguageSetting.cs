using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.SettingForm.Language
{
    class LanguageSetting
    {

        public bool InsertLanguageSetting(LanguageClass language)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                string user = Class.valiballecommon.GetStorage().UserName;
                string CreateDate = DateTime.Now.ToString("yyyyMMdd");
                string PC = Class.valiballecommon.GetStorage().PCName;
                stringBuilder.Append(" insert into t_language (Create_User, Create_Date, Create_App, Modifier,Modify_Date,Modify_App,FunctionGroup,FunctionName,TiengViet,English,Chinese,DateTime ) values  ");
                stringBuilder.Append("( '");
                stringBuilder.Append( user + "','" +CreateDate+"','"+PC+"','"+""+"','"+""+"','"+""+"','"+language.functionGroup+"','"+language.functionName+"','"+language.Tiengviet+"','"+language.English+"','"+language.Chinese + "',"+ "GETDATE()");
                stringBuilder.Append(") ");
                sqlCON sqlCON = new sqlCON();
              return sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertLanguageSetting(LanguageClass language)", ex.Message);
                return false;
            }
           
        }
        public bool UpdateLanguageSetting(LanguageClass language)
        {
            try
            {
                string user = Class.valiballecommon.GetStorage().UserName;
                string CreateDate = DateTime.Now.ToString("yyyyMMdd");
                string PC = Class.valiballecommon.GetStorage().PCName;
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" update t_language ");
                stringBuilder.Append(" set  Modifier = '" + user + "' , ");
                stringBuilder.Append("  Modify_Date = '" + CreateDate + "' , ");
                stringBuilder.Append("  Modify_App = '" + PC + "', ");
                stringBuilder.Append("  TiengViet = '" + language.Tiengviet + "', ");
                stringBuilder.Append("  English = '" + language.English + "', ");
                stringBuilder.Append("  Chinese = '" + language.Chinese + "' ");
                stringBuilder.Append(" where 1=1 ");
                stringBuilder.Append(" and  FunctionGroup = '" + language.functionGroup + "' ");
                stringBuilder.Append(" and  FunctionName = '" + language.functionName + "' ");
                sqlCON sqlCON = new sqlCON();
                return sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateLanguageSetting(LanguageClass language)", ex.Message);
                return false;
            }

        }
       

        public bool DeleteRowofLanguageSetting(LanguageClass language)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" delete from  t_language ");
                stringBuilder.Append(" where 1=1 ");
                stringBuilder.Append(" and  FunctionGroup = '" + language.functionGroup + "' ");
                stringBuilder.Append(" and  FunctionName = '" + language.functionName + "' ");
                sqlCON sqlCON = new sqlCON();
                return sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "DeleteRowofLanguageSetting(LanguageClass language)", ex.Message);
                return false;
            }


        }
        public DataTable SearchLanguageSetting(LanguageClass language)
        {
            DataTable dt = new DataTable();
            try
            {
               
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select FunctionGroup,FunctionName,TiengViet,English,Chinese  from  t_language ");
                stringBuilder.Append(" where 1=1 ");
                if(language.functionGroup != "")
                stringBuilder.Append(" and  FunctionGroup like '%" + language.functionGroup + "%' ");
                if (language.functionName != "")
                    stringBuilder.Append(" and  FunctionName like '%" + language.functionName + "%' ");
                sqlCON sqlCON = new sqlCON();
                 sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                return dt;
            }
            catch (Exception)
            {

                return dt;
            }

        }
        public Dictionary<string,string> GetNameTranslate (string Language, string FunctionGroup)
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select * from t_language where FunctionGroup = '" + FunctionGroup + "' ");
                DataTable dt = new DataTable();
                sqlCON sqlcon = new sqlCON();
                sqlcon.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    
                        keyValuePairs.Add(dt.Rows[i]["FunctionName"].ToString().Trim(), dt.Rows[i][Language].ToString().Trim());
                   
                }
                
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Dictionary<string,string> GetNameTranslate (LanguageEnum Language, string FunctionGroup, string FunctionName)", ex.Message);
            }
            return keyValuePairs;
        }
    }
}
