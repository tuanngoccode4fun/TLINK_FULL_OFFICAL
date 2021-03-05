using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.MQC
{
    class LoadDefectMapping
    {
        public List<NGItemsMapping> listNGMapping(string Dept,string processname)
        {
            List<NGItemsMapping> nGItemsMappings = new List<NGItemsMapping>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct modelcode, processcode, processname, itemcode, itemname ");
            sql.Append("from m_process ");
            sql.Append("where 1=1 ");
            sql.Append("and modelcode = '" + Dept + "' ");
            sql.Append("and processname = '" + processname + "' ");
            sqlCON sql12 = new sqlCON();
            DataTable dt = new DataTable();
            sql12.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            nGItemsMappings = (from DataRow dr in dt.Rows
                                select new NGItemsMapping()
                                {
                                    Department = dr["modelcode"].ToString(),
                                    NGCode_Process = dr["processcode"].ToString(),
                                    NGCodeName_Process = dr["processname"].ToString(),
                                    NGCode_SFT = dr["itemcode"].ToString(),
                                    NGCodeName_SFT = dr["itemname"].ToString()

                                }).ToList();
            return nGItemsMappings;
        }
        public NGItemsMapping GetNGMapping(string Dept,string process, string NGPLC)
        {
            try
            {
                List<NGItemsMapping> nGItemsMappings = new List<NGItemsMapping>();
                StringBuilder sql = new StringBuilder();
                sql.Append("select distinct modelcode, processcode, processname, itemcode, itemname ");
                sql.Append("from m_process ");
                sql.Append("where 1=1 ");
                sql.Append("and modelcode = '" + Dept + "' ");
                sql.Append("and processcode = '" + NGPLC + "' ");
                sql.Append("and processname = '" + process + "' ");
                sqlCON sql12 = new sqlCON();
                DataTable dt = new DataTable();
                sql12.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
                nGItemsMappings = (from DataRow dr in dt.Rows
                                   select new NGItemsMapping()
                                   {
                                       Department = dr["modelcode"].ToString(),
                                       NGCode_Process = dr["processcode"].ToString(),
                                       NGCodeName_Process = dr["processname"].ToString(),
                                       NGCode_SFT = dr["itemcode"].ToString(),
                                       NGCodeName_SFT = dr["itemname"].ToString()

                                   }).ToList();
                if (nGItemsMappings != null && nGItemsMappings.Count > 0)
                {
                    return nGItemsMappings[0];
                }
                else return null;
            }
            catch (Exception ex)
            {

                throw;
            }
          

        }
        public List<NGItemsMapping> listNGMappingGetReport(string Dept, string processname)
        {
            List<NGItemsMapping> nGItemsMappings = new List<NGItemsMapping>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct modelcode, processcode, processname, itemcode, itemname, note ");
            sql.Append("from m_process ");
            sql.Append("where 1=1 and note like '%Top5%' ");
            sql.Append("and modelcode = '" + Dept + "' ");
            sql.Append("and processname = '" + processname + "' ");
            sqlCON sql12 = new sqlCON();
            DataTable dt = new DataTable();
            sql12.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            nGItemsMappings = (from DataRow dr in dt.Rows
                               select new NGItemsMapping()
                               {
                                   Department = dr["modelcode"].ToString(),
                                   NGCode_Process = dr["processcode"].ToString(),
                                   NGCodeName_Process = dr["processname"].ToString(),
                                   NGCode_SFT = dr["itemcode"].ToString(),
                                   NGCodeName_SFT = dr["itemname"].ToString(),
                                   Note = (dr["note"].ToString().Split(';').Count() == 2) ? int.Parse(dr["note"].ToString().Split(';')[0].Substring(5)) : int.Parse(dr["note"].ToString().Substring(5))

                               }).ToList();
            return nGItemsMappings;
        }
        public List<NGItemsMapping> listNGMappingGetReportTop16(string Dept, string processname)
        {
            List<NGItemsMapping> nGItemsMappings = new List<NGItemsMapping>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct modelcode, processcode, processname, itemcode, itemname, note ");
            sql.Append("from m_process ");
            sql.Append("where 1=1 and note like '%Top16%' ");
            sql.Append("and modelcode = '" + Dept + "' ");
            sql.Append("and processname = '" + processname + "' ");
            sqlCON sql12 = new sqlCON();
            DataTable dt = new DataTable();
            sql12.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            nGItemsMappings = (from DataRow dr in dt.Rows
                               select new NGItemsMapping()
                               {
                                   Department = dr["modelcode"].ToString(),
                                   NGCode_Process = dr["processcode"].ToString(),
                                   NGCodeName_Process = dr["processname"].ToString(),
                                   NGCode_SFT = dr["itemcode"].ToString(),
                                   NGCodeName_SFT = dr["itemname"].ToString(),
                                   Note = (dr["note"].ToString().Split(';').Count() == 2) ? int.Parse(dr["note"].ToString().Split(';')[1].Substring(6)) : int.Parse(dr["note"].ToString().Substring(6))

                               }).ToList();
            return nGItemsMappings;
        }
        public List<NGItemsMapping> listNGMappingGetReportTop13(string Dept, string processname)
        {
            List<NGItemsMapping> nGItemsMappings = new List<NGItemsMapping>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct modelcode, processcode, processname, itemcode, itemname, note ");
            sql.Append("from m_process ");
            sql.Append("where 1=1 and note like '%Top13%' ");
            sql.Append("and modelcode = '" + Dept + "' ");
            sql.Append("and processname = '" + processname + "' ");
            sqlCON sql12 = new sqlCON();
            DataTable dt = new DataTable();
            sql12.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            nGItemsMappings = (from DataRow dr in dt.Rows
                               select new NGItemsMapping()
                               {
                                   Department = dr["modelcode"].ToString(),
                                   NGCode_Process = dr["processcode"].ToString(),
                                   NGCodeName_Process = dr["processname"].ToString(),
                                   NGCode_SFT = dr["itemcode"].ToString(),
                                   NGCodeName_SFT = dr["itemname"].ToString(),
                                   Note = convertStringToInt(dr["note"].ToString().Trim(), "Top13")
                                   //  Note = (dr["note"].ToString().Split(';').Count() == 2) ? int.Parse(dr["note"].ToString().Split(';')[1].Substring(6)) : int.Parse(dr["note"].ToString().Substring(6))

                               }).ToList();
            return nGItemsMappings;
        }
        public int convertStringToInt(string inputStr, string Top)
        {
            int num = 0;
            string[] splitStr = inputStr.Split(';');
            for (int i = 0; i < splitStr.Count(); i++)
            {
                if (splitStr[i].Contains(Top))
                {
                    string temp = splitStr[i].Substring(Top.Length + 1);
                    num = int.Parse(temp);
                }
            }
            return num;
        }
    }
}
