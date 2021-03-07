using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using WindowsFormsApplication1.WMS.Model;

namespace WindowsFormsApplication1.WMS
{
    class DBOperation
    {
        public List<InvertoryItem> GetInvertoryItems(DateTime InventoryDate)
        {
            List<InvertoryItem> invertoryItems = new List<InvertoryItem>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select TD001, TD003,TD006, TD005,TD018, TD002 from INVTD where 1=1 ");
                stringBuilder.Append(" and CONVERT(date,TD002) >= '" + InventoryDate.ToString("yyyyMMdd") + "'");
                sqlERPCON sqlERPCON = new sqlERPCON();
                DataTable dt = new DataTable();
                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                invertoryItems = (from DataRow dr in dt.Rows
                                  select new InvertoryItem()
                                  {
                                      KeyID = dr["TD001"].ToString().Trim(),
                                      Material = dr["TD003"].ToString().Trim(),
                                      Quantity = (dr["TD006"].ToString().Trim() != "") ? double.Parse(dr["TD006"].ToString().Trim()) : 0,
                                      Warehouse = dr["TD005"].ToString().Trim(),
                                      Position = dr["TD018"].ToString().Trim(),

                                      InvertoryDate= (dr["TD002"].ToString() != "") ? DateTime.ParseExact(dr["TD002"].ToString(),"yyyyMMdd", CultureInfo.InvariantCulture) : DateTime.MinValue,


                                  }).ToList();
                dt = null;

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<InvertoryItem> GetInvertoryItems(DateTime InventoryDate)", ex.Message);
            }
            return invertoryItems;
        }
        public List<InvertoryItem> GetInvertoryItemsFillter(DateTime InventoryDate, string warehouse)
        {
            List<InvertoryItem> invertoryItems = new List<InvertoryItem>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select TD001, TD003,TD004, TD006, TD005,TD018, TD002 from INVTD where 1=1 ");
                stringBuilder.Append(" and CONVERT(date,TD002) >= '" + InventoryDate.ToString("yyyyMMdd") + "'");
                stringBuilder.Append(" and TD005 = '" +warehouse+ "'");
                sqlERPCON sqlERPCON = new sqlERPCON();
                DataTable dt = new DataTable();
                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                invertoryItems = (from DataRow dr in dt.Rows
                                  select new InvertoryItem()
                                  {
                                      KeyID = dr["TD001"].ToString().Trim(),
                                      Material = dr["TD003"].ToString().Trim(),
                                      LotPo = dr["TD004"].ToString().Trim(),
                                      Quantity = (dr["TD006"].ToString().Trim() != "") ? double.Parse(dr["TD006"].ToString().Trim()) : 0,
                                      Warehouse = dr["TD005"].ToString().Trim(),
                                      Position = dr["TD018"].ToString().Trim(),

                                      InvertoryDate = (dr["TD002"].ToString() != "") ? DateTime.ParseExact(dr["TD002"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture) : DateTime.MinValue,


                                  }).ToList();
                dt = null;

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<InvertoryItem> GetInvertoryItems(DateTime InventoryDate)", ex.Message);
            }
            return invertoryItems;
        }
        public List<InOutItem> GetInOutItems(DateTime InventoryDate)
        {
            List<InOutItem> invertoryItems = new List<InOutItem>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select LA006 AS CODE,LA007 AS CodeNo, LA008 as STT, LA001 AS SP, LA005 AS INOUT,LA011 as Quantity,
LA009 as Kho,LA022 as Position,LA004 AS NGAY from INVLA WHERE  1=1  ");
                stringBuilder.Append(" and CONVERT(date,TD002) >= '" + InventoryDate.ToString("yyyyMMdd") + "'");
              
                sqlERPCON sqlERPCON = new sqlERPCON();
                DataTable dt = new DataTable();
                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                invertoryItems = (from DataRow dr in dt.Rows
                                  select new InOutItem()
                                  {
                                      Code = dr["CODE"].ToString().Trim()+"-" + dr["CodeNo"].ToString().Trim(),
                                      STT = dr["STT"].ToString().Trim(),
                                      MaterialCode = dr["SP"].ToString().Trim(),
                                      InOut= dr["INOUT"].ToString().Trim(),
                                      Quantity = dr["Quantity"].ToString().Trim() != "" ? double.Parse(dr["Quantity"].ToString().Trim()):0,
                                      Warehouse = dr["Kho"].ToString().Trim(),

                                      Position = dr["Position"].ToString() ,
                                      DateTime = DateTime.ParseExact(dr["NGAY "].ToString().Trim(),"yyyyMMdd", CultureInfo.InvariantCulture)


                                  }).ToList();
                dt = null;

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<InvertoryItem> GetInvertoryItems(DateTime InventoryDate)", ex.Message);
            }
            return invertoryItems;
        }

        
        public string GetMaxIndexLA007(string LA006, string LA005)
        {
            string _LA007 = "";
            string dateFormat = DateTime.Now.ToString("yyMM");
            string countFormatReset = "0001";
            int countUp = 0;
            sqlERPCON sqlERPCON = new sqlERPCON();
            string strData = sqlERPCON.sqlExecuteScalarString(" select max(LA007) from INVLA where  LA006 ='" +LA006 +"' and LA005 ='" + LA005+"'") ;
            {
                string DateDatabase = strData.Trim().Substring(0, 4);
                string strCount = strData.Trim().Substring(4);
                if (dateFormat == DateDatabase)
                {
                    countUp = int.Parse(strCount) + 1;
                    string countFormatup = countUp.ToString("0000");
                    _LA007 = dateFormat + countFormatup;
                }
                else
                {
                    _LA007 = dateFormat + countFormatReset;
                }
            }

            return _LA007;
        }
        public DataTable GetTop1DataForInsertINVLA()
        {
            DataTable data = new DataTable();
            string SqlQuerry = "select top(1) * from INVLA ";
            sqlERPCON sqlERPCON = new sqlERPCON();
            sqlERPCON.sqlDataAdapterFillDatatable(SqlQuerry, ref data);
            return data;
        }
     
        public List<PURTD> GetPURTDsfromQRCode(string QRcode)
        {
            List<PURTD> pURTDs = new List<PURTD>();
            if (QRcode.Contains('-'))
            {
                try
                {

              
                string Ma = QRcode.Split('-')[0];
                string code = QRcode.Split('-')[1];
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select TD001, TD002, TD003, TD004, TD005,TD007,TD008,TD009,TD012,TD015, TD018 from PURTD where 1=1 ");
                stringBuilder.Append(" and TD001 = '" + Ma + "' ");
                stringBuilder.Append(" and TD002 = '" + code + "' ");
                DataTable dt = new DataTable();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                pURTDs = (from DataRow dr in dt.Rows
                                  select new PURTD()
                                  {
                                      TD001_Ma = dr["TD001"].ToString().Trim(),
                                      TD002_Code = dr["TD002"].ToString().Trim(),
                                      TD003_STT = dr["TD003"].ToString().Trim(),
                                      TD004_MaSP = dr["TD004"].ToString().Trim(),
                                      TD005_TenSP = dr["TD005"].ToString().Trim(),
                                      TD007_Kho = dr["TD007"].ToString().Trim(),

                                      TD008_SL = dr["TD008"].ToString().Trim() !="" ? double.Parse(dr["TD008"].ToString().Trim()) :0,
                                      TD009_Unit = dr["TD009"].ToString().Trim(),
                                      TD012_DeliveryEstimate = DateTime.ParseExact(dr["TD012"].ToString().Trim(), "yyyyMMdd", CultureInfo.InvariantCulture),
                                      TD015_SLDaGiao = dr["TD015"].ToString().Trim() != "" ? double.Parse(dr["TD015"].ToString().Trim()) : 0,
                                      TD018_MaXacNhan = dr["TD018"].ToString().Trim()

                                  }).ToList();
                dt = null;


                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "List < PURTD > GetPURTDsfromQRCode(string QRcode)", ex.Message);
                }
            }
            return pURTDs;
        }

      public List<InforWH> GetInforWHs()
        {
            List<InforWH> inforWHs = new List<InforWH>();
            try
            {
                string sqlWh = "select distinct MC001,MC002 from CMSMC ";
                DataTable dt = new DataTable();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(sqlWh, ref dt);
                inforWHs = (from DataRow dr in dt.Rows
                                  select new InforWH()
                                  {
                                      WH = dr["MC001"].ToString().Trim(),
                                      Name = dr["MC002"].ToString().Trim()

                                  }).ToList();
                foreach (var item in inforWHs)
                {
                    string SQLvitriKho = " select distinct NL002  from CMSNL where NL001 ='" + item.WH + "'";
                    DataTable dta = new DataTable();
                    sqlTLVN2 = new SqlTLVN2();
                    sqlTLVN2.sqlDataAdapterFillDatatable(SQLvitriKho, ref dta);
                    item.positions = new List<Position>();
                    item.positions = (from DataRow dr in dta.Rows
                                   select new Position()
                                   {
                                      position = dr["NL002"].ToString().Trim()

                                   }).ToList();
                    dta = null;
                }
                dt = null;

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<InforWH> GetInforWHs()", ex.Message);
            }
            return inforWHs;
        }
        public string GetMaxIndexTG002()
        {
            string _TG002 = "";
            string dateFormat = DateTime.Now.ToString("yyMM");
            string countFormatReset = "0001";
           
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            var strData = sqlTLVN2.sqlExecuteScalarString("SELECT MAX(TG002)+1 from PURTG where TG001 ='3401' and TG002 like '" + dateFormat +"%'");
            if (strData == "" || strData == String.Empty || strData == null)
                _TG002 = dateFormat + countFormatReset;
            else _TG002 = strData;

            return _TG002;
        }
        public DataTable GetDataTableTop1PURTG()
        {
            DataTable dt = new DataTable();
            string sqlQuerry = "Select top(1) * from PURTG ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
            return dt;
        }
        public DataTable GetDataTableTop1PURTH()
        {
            DataTable dt = new DataTable();
            string sqlQuerry = "Select top(1) * from PURTH ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
            return dt;
        }
        public bool GeneratePURTH(DataTable dtHeader, List<gridviewInStock> gridviewInStocks, string IndexGenerate)
        {
            
         //   string IndexGenerate = GetMaxIndexTG002();
            try
            {
                int countSTT = 0;
                foreach (var inStock in gridviewInStocks)
                {
                    DataTable dataPURTD = GetDataTablePURTD(inStock.TD001_Ma, inStock.TD002_Code, inStock.TD004_MaSP);
                    DataTable dataPURTC = GetDataTablePURTC(inStock.TD001_Ma, inStock.TD002_Code);
                    DataTable dataINVMB = GetDataTableINVMB(dataPURTD.Rows[0]["TD004"].ToString());
                    DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                    StringBuilder stringBuilder = new StringBuilder();
                    StringBuilder stringFun = new StringBuilder();
                    stringBuilder.Append("insert into PURTH ( ");
                    for (int i = 0; i < dtHeader.Columns.Count; i++)
                    {if(i< dtHeader.Columns.Count-1)
                        stringBuilder.Append(dtHeader.Columns[i].ColumnName + ",");
                        else stringBuilder.Append(dtHeader.Columns[i].ColumnName + ") values ( ");
                    }

                    for (int i = 0; i < dtHeader.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtHeader.Columns.Count; j++)
                        {
                            string valueCell = "";
                            #region PURTH
                            if(dtHeader.Columns[j].ColumnName == "CREATOR")
                            {
                                valueCell = Class.valiballecommon.GetStorage().UserName;
                            }
                       else     if (dtHeader.Columns[j].ColumnName == "COMPANY")
                            {
                                valueCell = "TLNV2";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "USR_GROUP")
                            {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                                if (dataADMMF !=null && dataADMMF.Rows.Count ==1)
                                    valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "CREATE_DATE")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "MODIFIER")
                            {
                                valueCell ="";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "MODI_DATE")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "FLAG")
                            {
                                valueCell = "1";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "CREATE_TIME")
                            {
                                valueCell = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "CREATE_AP")
                            {
                                valueCell =   Class.valiballecommon.GetStorage().PCName;
                            }
                            else if (dtHeader.Columns[j].ColumnName == "CREATE_PRID")
                            {
                                valueCell = "PURI09";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "MODI_TIME")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "MODI_AP")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "MODI_PRID")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH001")
                            {
                                valueCell = "3401";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH002")
                            {
                                valueCell = IndexGenerate;
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH003")
                            {
                                valueCell =(countSTT + 1).ToString("0000");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH004")
                            {
                                valueCell = dataPURTD.Rows[0]["TD004"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH005")
                            {
                                valueCell = dataPURTD.Rows[0]["TD005"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH005")
                            {
                                valueCell = dataPURTD.Rows[0]["TD005"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH006")
                            {
                                valueCell = dataPURTD.Rows[0]["TD006"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH007")
                            {
                                valueCell =inStock.SLThucte.ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH008")
                            {
                                valueCell = dataPURTD.Rows[0]["TD009"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH009")
                            {
                                valueCell = inStock._Kho;
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH010")
                            {
                                valueCell = inStock.Lot;
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH011")
                            {
                                valueCell = dataPURTD.Rows[0]["TD001"].ToString(); 
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH012")
                            {
                                valueCell = dataPURTD.Rows[0]["TD002"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH013")
                            {
                                valueCell = dataPURTD.Rows[0]["TD003"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH014")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH015")
                            {
                                valueCell = inStock.SLThucte.ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH016")
                            {
                                valueCell = inStock.SLThucte.ToString();// Day la so luong tinh gia, se tinh toan lai sau
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH017")
                            {
                                valueCell = 0.ToString();// Day la so luong tinh gia, se tinh toan lai sau
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH018")
                            {
                                valueCell = dataPURTD.Rows[0]["TD010"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH019")
                            {
                                valueCell = (inStock.SLThucte * double.Parse(dataPURTD.Rows[0]["TD010"].ToString())).ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH019")
                            {
                                valueCell = (inStock.SLThucte * double.Parse(dataPURTD.Rows[0]["TD010"].ToString())).ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH020")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH021")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH022")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH023")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH024")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH025")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH026")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH027")
                            {
                                DateTime date = DateTime.ParseExact(dataPURTD.Rows[0]["TD012"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture);
                                if(DateTime.Now.Date >= date)
                                valueCell = "Y";
                                else valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH028")
                            {
                                valueCell = dataINVMB.Rows[0]["MB043"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH029")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH030")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH031")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH032")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH033")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH034")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH035")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH036")
                            {
                                valueCell =inStock._ExpiryDay.ToString("yyyyMMdd");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH037")
                            {
                                valueCell = inStock._ExpiryDay.ToString("yyyyMMdd");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH038")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH039")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH040")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH041")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH042")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH043")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH044")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH045")
                            {
                                valueCell = (inStock.SLThucte * double.Parse(dataPURTD.Rows[0]["TD010"].ToString())).ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH046")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH047")
                            {
                                valueCell = (inStock.SLThucte * double.Parse(dataPURTD.Rows[0]["TD010"].ToString()) * double.Parse(dataPURTC.Rows[0]["TC006"].ToString())).ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH048")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH049")
                            {
                                valueCell = dataPURTD.Rows[0]["TD030"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH050")
                            {
                                valueCell = dataPURTD.Rows[0]["TD030"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH051")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH052")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH053")
                            {
                                valueCell = dataPURTD.Rows[0]["TD032"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH054")
                            {
                                valueCell = dataINVMB.Rows[0]["MB020"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH056")
                            {
                                valueCell = dataPURTD.Rows[0]["TD059"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH058")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH061")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH062")
                            {
                                valueCell = "2";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH063")
                            {
                                valueCell = inStock._VitriKho;
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH073")
                            {
                                valueCell = dataPURTD.Rows[0]["TD057"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH074")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH086")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TH087")
                            {
                                valueCell = "";
                            }
                            else    valueCell = dtHeader.Rows[i][dtHeader.Columns[j].ColumnName].ToString();
                           
                            if (j <dtHeader.Columns.Count-1) stringFun.Append(" '" + valueCell + "',");
                            else stringFun.Append("'" + valueCell + "')");
                        }
                        string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();

                        if (sqlTLVN2.sqlExecuteNonQuery(sqlInsert, false))
                        {
                       //     MessageBox.Show("Insert PURTH ok : " + IndexGenerate);
                            countSTT++;
                        }
                        else MessageBox.Show("Insert PURTH fail");
                        #endregion



                    }
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, ex.Source, ex.Message);
                return false;
            }
            return true;
        }
        public bool GenerateRowPURTG(List<gridviewInStock> gridviewInStocks, string IndexGenerate)
        {
            DataTable dtHeader = GetDataTableTop1PURTG();
         
            try
            {
                var inStock = gridviewInStocks[0];
                {
                    DataTable dataPURTD = GetDataTablePURTD(inStock.TD001_Ma, inStock.TD002_Code, inStock.TD004_MaSP);
                    DataTable dataPURTC = GetDataTablePURTC(inStock.TD001_Ma, inStock.TD002_Code);
                    DataTable dataPURMA = GetDataTablePURMA(dataPURTC.Rows[0]["TC004"].ToString());
                    DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                    StringBuilder stringBuilder = new StringBuilder();
                    StringBuilder stringFun = new StringBuilder();
                    stringBuilder.Append("insert into PURTG ( ");
                    for (int i = 0; i < dtHeader.Columns.Count; i++)
                    {
                        if (i < dtHeader.Columns.Count - 1)
                        {
                            if(dtHeader.Columns[i].ColumnName != "CFIELD01")
                            stringBuilder.Append(dtHeader.Columns[i].ColumnName + ",");
                        }
                        else stringBuilder.Append(dtHeader.Columns[i].ColumnName + ") values ( ");
                    }

                    for (int i = 0; i < dtHeader.Rows.Count; i++)
                    {
                        for (int j = 0; j < dtHeader.Columns.Count; j++)
                        {
                            string valueCell = "";
                            #region PURTG
                            if (dtHeader.Columns[j].ColumnName == "CREATOR")
                            {
                                valueCell = Class.valiballecommon.GetStorage().UserName;
                            }
                            else if (dtHeader.Columns[j].ColumnName == "COMPANY")
                            {
                                valueCell = "TLNV2";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "USR_GROUP")
                            {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                                if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                                    valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "CREATE_DATE")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "MODIFIER")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "MODI_DATE")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "FLAG")
                            {
                                valueCell = "1";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "CREATE_TIME")
                            {
                                valueCell = DateTime.Now.ToString("HH:mm:ss");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "CREATE_AP")
                            {
                                valueCell =   Class.valiballecommon.GetStorage().PCName;
                            }
                            else if (dtHeader.Columns[j].ColumnName == "CREATE_PRID")
                            {
                                valueCell = "PURI09";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "MODI_TIME")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "MODI_AP")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "MODI_PRID")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG001")
                            {
                                valueCell = "3401";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG002")
                            {
                                valueCell = IndexGenerate;
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG003")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG004")
                            {
                                valueCell = "TL";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG005")
                            {
                                valueCell = dataPURTC.Rows[0]["TC004"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG006")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG007")
                            {
                                valueCell = dataPURTC.Rows[0]["TC005"].ToString();
                            }

                            else if (dtHeader.Columns[j].ColumnName == "TG008")
                            {
                                valueCell = dataPURTC.Rows[0]["TC006"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG009")
                            {
                                valueCell = "3";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG010")
                            {
                                valueCell = "3";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG011")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG012")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG013")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG014")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG015")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG016")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG017")
                            {
                                valueCell = GetSumValuePURTH("TH019", "3401", IndexGenerate).ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG018")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG019")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG020")
                            {
                                valueCell = GetSumValuePURTH("TH024", "3401", IndexGenerate).ToString();
                            }
                           
                            else if (dtHeader.Columns[j].ColumnName == "TG021")
                            {
                                valueCell = dataPURMA.Rows[0]["MA003"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG022")
                            {
                                valueCell = dataPURMA.Rows[0]["MA005"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG023")
                            {
                                valueCell = "3";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG024")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG025")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG026")
                            {
                                valueCell = GetSumValuePURTH("TH015", "3401", IndexGenerate).ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG027")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG028")
                            {
                                valueCell = GetSumValuePURTH("TH019", "3401", IndexGenerate).ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG029")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMM");
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG030")
                            {
                                valueCell = dataPURTC.Rows[0]["TC026"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG031")
                            {
                                valueCell = GetSumValuePURTH("TH047", "3401", IndexGenerate).ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG032")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG033")
                            {
                                valueCell = dataPURTC.Rows[0]["TC027"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG034")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG035")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG036")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG037")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG038")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG039")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG040")
                            {
                                valueCell = GetSumValuePURTH("TH050", "3401", IndexGenerate).ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG041")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG042")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG043")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG044")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG045")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG046")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG047")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG048")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG049")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG050")
                            {
                                valueCell = "1";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG051")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG052")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG053")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG054")
                            {
                                valueCell = "0";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG055")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG056")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG057")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG058")
                            {
                                valueCell = dataPURTC.Rows[0]["TC047"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG059")
                            {
                                valueCell = dataPURTC.Rows[0]["TC048"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG060")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG061")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG062")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG063")
                            {
                                valueCell = "N";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG064")
                            {
                                valueCell = "1";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG065")
                            {
                                valueCell = dataPURMA.Rows[0]["MA086"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG066")
                            {
                                valueCell = dataPURMA.Rows[0]["MA087"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG067")
                            {
                                valueCell = dataPURMA.Rows[0]["MA013"].ToString();
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG068")
                            {
                                valueCell ="";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "TG069")
                            {
                                valueCell = "";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "UDF01")
                            {
                                valueCell = inStock.Invoice;
                            }
                            else if (dtHeader.Columns[j].ColumnName == "UDF02")
                            {
                                valueCell ="";
                            }
                            else if (dtHeader.Columns[j].ColumnName == "CFIELD01")
                            {
                                valueCell ="3401"+ "-"+ IndexGenerate;
                            }
                            else valueCell = dtHeader.Rows[i][dtHeader.Columns[j].ColumnName].ToString();

                            if (j < dtHeader.Columns.Count - 1)
                            {  if (dtHeader.Columns[j].ColumnName != "CFIELD01")
                                stringFun.Append(" '" + valueCell + "',");
                            }

                            else stringFun.Append("'" + valueCell + "')");
                        }
                        string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        if (sqlTLVN2.sqlExecuteNonQuery(sqlInsert, false))
                        {
                            ;
                            //MessageBox.Show("Insert PURTG ok : " + "3401-"+IndexGenerate);
                        }
                        else MessageBox.Show("Insert PURTG fail");
                        #endregion



                    }
                }
            }
            catch (Exception ex) 
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GenerateRowPURTG(List<gridviewInStock> gridviewInStocks, string IndexGenerate)", ex.Message);
                return false;
            }
            return true;

        }
        public DataTable GetDataTablePURTD(string ma, string code, string sp)
        {
            DataTable dt = new DataTable();
            string sqlQuerry = "select * from PURTD where TD001 ='" + ma + "' and TD002 ='" + code + "' and TD004 ='" + sp +"'";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
            return dt;
        }
        public DataTable GetDataTablePURTC(string ma, string code)
        {
            DataTable dt = new DataTable();
            string sqlQuerry = "select * from PURTC where TC001 ='" + ma + "' and TC002 ='" + code + "'";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
            return dt;
        }
        public DataTable GetDataTablePURMA(string TC004)
        {
            DataTable dt = new DataTable();
            string sqlQuerry = "select distinct MA003,MA005,MA086,MA087,MA013 from PURMA where MA001 ='" + TC004+ "'";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
            return dt;
        }
        public DataTable GetDataTableINVMB(string TD004)
        {
            DataTable dt = new DataTable();
            string sqlQuerry = "select MB043, MB020 from INVMB where MB001 = '" + TD004 + "'";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
            return dt;
        }
        public double GetSumValuePURTH(string THx, string ma, string code)
        {
            double sum = 0;

            string sqlQuerry = "select sum(" + THx + ") from PURTH where TH001 ='" + ma + "' and TH002 ='" + code + "'";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
          string value =  sqlTLVN2.sqlExecuteScalarString(sqlQuerry);
            try
            {
                sum = double.Parse(value.Trim());
            }
            catch (Exception)
            {

                sum = 0;
            }
            return sum;
        }


        #region Stock Out
        public List<WMS.Model.INVTATB> GetINVTATBs(string QRCode)
        {
            List<WMS.Model.INVTATB> iNVTATBs = new List<Model.INVTATB>();
            var qrArray = QRCode.Split('-');
            if (qrArray.Length == 2)
            {
                try
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(@"select TA001, TA002, TA014,TA004, TB003,TB004,TB005,TB006, TB007, TB014, TB022, TB012, TB026, TB013, TB027, TB008, TB023,TB015
from INVTA
inner join INVTB on TA001 = TB001 and TA002 = TB002
where 1=1 and TA006 = 'N'
");
                    stringBuilder.Append("and TA001 ='" + qrArray[0] + "' ");
                    stringBuilder.Append("and TA002 ='" + qrArray[1] + "' ");
                    DataTable dt = new DataTable();
                    SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                    sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                    iNVTATBs = (from DataRow dr in dt.Rows
                              select new Model.INVTATB()
                              {
                                  TA001_ma = dr["TA001"].ToString().Trim(),
                                  TA002_code = dr["TA002"].ToString().Trim(),
                                  TA014_ngayCT = DateTime.ParseExact(dr["TA014"].ToString().Trim(), "yyyyMMdd", CultureInfo.InvariantCulture),
                                  TA004_BP= dr["TA004"].ToString().Trim(),
                                  TB003_STT = dr["TB003"].ToString().Trim(),
                                  TB004_SP = dr["TB004"].ToString().Trim(),
                                  TB005_TenSp = dr["TB005"].ToString().Trim(),
                                  TB006_Quycach = dr["TB006"].ToString().Trim(),
                                  TB007_SL= dr["TB007"].ToString().Trim() != "" ? double.Parse(dr["TB007"].ToString().Trim()) : 0,
                                  TB014_Lot = dr["TB014"].ToString().Trim(),
                                   TB022_SLDonggoi = dr["TB022"].ToString().Trim() != "" ? double.Parse(dr["TB022"].ToString().Trim()) : 0,
                                   TB012_KhoChuyen = dr["TB012"].ToString().Trim(),
                                   TB026_VtKhoChuyen = dr["TB026"].ToString().Trim(),
                                   TB013_khoNhan = dr["TB013"].ToString().Trim(),
                                   TB027_VtKhoNhan = dr["TB027"].ToString().Trim(),
                                   TB008_Unit = dr["TB008"].ToString().Trim(),
                                  TB023_DonViDongGoi = dr["TB023"].ToString().Trim(),
                                  TB015_ExpiryDate = DateTime.ParseExact(dr["TB015"].ToString().Trim(), "yyyyMMdd", CultureInfo.InvariantCulture),

                              }).ToList();
                  
                    var inVTATBsSort =  iNVTATBs
                        .GroupBy(d=>d.TB004_SP)
                        .Select(grp => grp.ToList()).ToList();
                    foreach (var iNVTATB in inVTATBsSort)
                    {
                        int count = 0;

                        foreach (var item in iNVTATB)
                        {

                            item.SLConLai = Math.Round(StockRemainOfLot(item.TB004_SP, item.TB012_KhoChuyen, item.TB014_Lot), 2);
                            //if (item.SLConLai < item.TB007_SL)
                            //    item.Evaluation = "Shortage Stock ";
                            List<Model.LotINVMEMF> lotsAll = new List<LotINVMEMF>();
                            List<Model.LotINVMEMF> lotINVMEMFs = GetLotINVMEMFs(item.TB004_SP, item.TB012_KhoChuyen, out lotsAll);
                            if (lotINVMEMFs.Count == 0)
                                item.Evaluation += "FIFO OK";
                            else
                            {
                                if (item.TB014_Lot == lotINVMEMFs[count].MF002_Lot)
                                {
                                    item.Evaluation += "FIFO OK";
                                    if (lotINVMEMFs[count].SL_TrongKho - item.TB007_SL <= 0)
                                    {
                                        count++;
                                    }
                                }
                                else item.Evaluation += "FIFO NG";
                            }

                        }
                    }
                    dt = null;
                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<WMS.Model.INVTATB> GetINVTATBs(string QRCode)", ex.Message);
                }
            }
            return iNVTATBs;
        }
        public double StockRemainOfLot(string SP, string kho, string lot)
        {
            double douNhap = 0;
            double douXuat = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SELECT  sum(LF011) as nhap FROM INVLF WHERE LF008 ='1' ");
            stringBuilder.Append(" and LF004 ='" + SP + "'");
            stringBuilder.Append(" and LF005 ='" + kho+ "'");
            stringBuilder.Append(" and LF007 ='" + lot + "'");
            stringBuilder.Append(" group by LF007, LF005,LF008 ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
      var strValue =      sqlTLVN2.sqlExecuteScalarString(stringBuilder.ToString());
            try
            {
                douNhap = double.Parse(strValue);
            }
            catch (Exception)
            {

                douNhap = 0;
            }
            StringBuilder stringBuilder2 = new StringBuilder();
            stringBuilder2.Append("SELECT  sum(LF011) as xuat FROM INVLF WHERE LF008 ='-1' ");
            stringBuilder2.Append(" and LF004 ='" + SP + "'");
            stringBuilder2.Append(" and LF005 ='" + kho + "'");
            stringBuilder2.Append(" and LF007 ='" + lot + "'");
            stringBuilder2.Append(" group by LF007, LF005,LF008 ");
            SqlTLVN2 sqlTLVN22 = new SqlTLVN2();
            var strValue2 = sqlTLVN22.sqlExecuteScalarString(stringBuilder2.ToString());
            try
            {
                douXuat = double.Parse(strValue2);
            }
            catch (Exception)
            {

                douXuat = 0;
            }

            return (douNhap - douXuat);
        }
        public List<Model.LotINVMEMF> GetLotINVMEMFs (string sp, string kho, out List<Model.LotINVMEMF> lots)
        {
            List<Model.LotINVMEMF> lotINVMEMFs = new List<Model.LotINVMEMF>();
            List<Model.LotINVMEMF> lotINVMEMFsReturn = new List<Model.LotINVMEMF>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select A.MF001, A.MF002,A.MF007, A.Conlai, A.ME003, A.ME009  from  (
select SUM(MF010*MF008) as Conlai, MF007, MF002, ME003, ME009, MF001
from INVMF 
inner join INVME on ME001 = MF001 and ME002 = MF002
where 1=1 ");
                stringBuilder.Append(" and MF001 ='" + sp + "' ");
                stringBuilder.Append(" and MF007 ='" + kho + "' ");
                stringBuilder.Append(" group by  MF007,MF002,ME003, ME009,MF001 ");
                stringBuilder.Append(" ) A where A.Conlai > 0 ");
                stringBuilder.Append(" order by A.ME009, A.ME003 ASC ");

                DataTable dt = new DataTable();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                int count = 0;
                lotINVMEMFs = (from DataRow dr in dt.Rows
                               select new Model.LotINVMEMF()
                               { STT = (++count).ToString("000"),
                                   MF001_Sp = dr["MF001"].ToString().Trim(),
                                   MF002_Lot = dr["MF002"].ToString().Trim(),
                                   MF007_kho = dr["MF007"].ToString().Trim(),
                                   SL_TrongKho = dr["Conlai"].ToString().Trim() != "" ? double.Parse(dr["Conlai"].ToString().Trim()) : 0,
                                   ME003_ImportDate = DateTime.ParseExact(dr["ME003"].ToString().Trim(), "yyyyMMdd", CultureInfo.InvariantCulture),
                                   ME009_ExpiryDate = DateTime.ParseExact(dr["ME009"].ToString().Trim(), "yyyyMMdd", CultureInfo.InvariantCulture),
                               }).ToList();
                
                foreach (var info in lotINVMEMFs)
                {if (info.ME009_ExpiryDate > DateTime.Now)
                    {
                        List<INVLF_Locate> iNVLF_Locates = new List<INVLF_Locate>();

                        iNVLF_Locates = GetLocationofLot(info.MF001_Sp, info.MF007_kho, info.MF002_Lot);
                        double maxQuantity = iNVLF_Locates.Select(d => d.Quantity).Max();
                        var INVLF = iNVLF_Locates.Where(d => d.Quantity == maxQuantity).ToList();
                     
                            info.MF002_Location = INVLF[0].LF006_Vitri;
                     
                        lotINVMEMFsReturn.Add(info);
                    }
                }
               
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<Model.LotINVMEMF> GetLotINVMEMFs (string sp, string kho)", ex.Message);
            }
            lots = lotINVMEMFs;
            return lotINVMEMFsReturn;
        }
        public List<INVLF_Locate> GetLocationofLot (string sp, string kho, string lot)
        {
            List<INVLF_Locate> iNVLF_Locates = new List<INVLF_Locate>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select LF004, LF005,LF007, LF006, sum(LF011*LF008) as Qty from INVLF where 1 = 1 ");
                stringBuilder.Append(" and LF004 = '" + sp + "' ");
                stringBuilder.Append(" and LF005 = '" + kho + "' ");
                stringBuilder.Append(" and LF007 = '" + lot + "' ");
                stringBuilder.Append(" group by LF004, LF005, LF006, LF007 ");
                DataTable dt = new DataTable();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                iNVLF_Locates = (from DataRow dr in dt.Rows
                                 select new INVLF_Locate()
                                 {
                                     LF004_Sp = dr["LF004"].ToString().Trim(),
                                     LF005_Kho = dr["LF005"].ToString().Trim(),
                                     LF006_Vitri = dr["LF006"].ToString().Trim(),
                                     LF007_Lot = dr["LF007"].ToString().Trim(),
                                     Quantity = double.Parse(dr["Qty"].ToString())

                                 }).ToList();
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetLocationofLot (string sp, string kho, string lot)", ex.Message);
            }
            return iNVLF_Locates;

        }
        public bool UpdateStockOutERPForm(string FormCode, string STT ,List<Model.LotINVMEMF> lotINVMEMFs)
        {

            if (lotINVMEMFs.Count == 1)
            {
                ERPFormUpdateLot(FormCode, STT, lotINVMEMFs[0]);
            }
            else if (lotINVMEMFs.Count > 1)
            {
                var QRspilit = FormCode.Split('-');
                int countSTT = SelectMaxSTT(QRspilit[0], QRspilit[1])+1;
                
                DataTable dataINVTB = GetDataTableINVTB(QRspilit[0], QRspilit[1], STT);
           var delete =     DeleteINVTBbyRow(QRspilit[0], QRspilit[1], STT);
                foreach (var item in lotINVMEMFs)
                { string strCount = countSTT.ToString("0000");
             var insert =       InsertInToINVTB(strCount, item, dataINVTB);
                    countSTT++;
                }
   var update =             UpdateINVTA(QRspilit[0], QRspilit[1]);
            }
            return false;

        }
       public bool ERPFormUpdateLot(string QRCode, string STT, Model.LotINVMEMF iNVMEMF)
        {
            try
            { // Update INVTB
                var QRspilit = QRCode.Split('-');
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" update INVTB ");
                stringBuilder.Append(" set TB014 = '" +iNVMEMF.MF002_Lot + "' , ");
                stringBuilder.Append(" FLAG = FLAG +1 ,");
                stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                stringBuilder.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                stringBuilder.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                stringBuilder.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                stringBuilder.Append("  TB007 = '" + iNVMEMF.SL + "' , ");
                if (iNVMEMF.MF002_Location == "##########")
                    iNVMEMF.MF002_Location = "";
                stringBuilder.Append("  TB026 = '" + iNVMEMF.MF002_Location + "', ");
                stringBuilder.Append("  TB015 = '" + iNVMEMF.ME009_ExpiryDate.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(" where  TB001 = '" + QRspilit[0]+ "'");
                stringBuilder.Append(" and  TB002 = '" + QRspilit[1] + "'");
                stringBuilder.Append(" and  TB003 = '" + STT + "'");

                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);

                DataTable dtINVTATB = GetDataTableINVTATB(QRspilit[0], QRspilit[1], STT);
                if(dtINVTATB != null && dtINVTATB.Rows.Count > 0)
                {

                    double SLChanged = (iNVMEMF.SL - double.Parse(dtINVTATB.Rows[0]["TB007"].ToString()) ) + double.Parse(dtINVTATB.Rows[0]["TA011"].ToString());
                    stringBuilder = new StringBuilder();
                    stringBuilder.Append(" update INVTA ");
                    stringBuilder.Append(" set TA011 = '" + SLChanged + "' , ");
                    stringBuilder.Append(" FLAG = FLAG +1 ,");
                    stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                    stringBuilder.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                    stringBuilder.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                    stringBuilder.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ");
                    stringBuilder.Append(" where  TA001 = '" + QRspilit[0] + "'");
                    stringBuilder.Append(" and  TA002 = '" + QRspilit[1] + "'");
                    sqlTLVN2 = new SqlTLVN2();
                    sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);

                }

                return true;
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ERPFormUpdateLot(string QRCode, string STT, Model.LotINVMEMF iNVMEMF)", ex.Message);
                return false;
            }
            
        }
        public DataTable GetDataTableINVTATB (string code, string No, string STT)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  *
from INVTA
left join INVTB on TA001 = TB001 and TA002 = TB002
where 1 =1 ");
                stringBuilder.Append(" and TB001 = '" + code + "'");
                stringBuilder.Append(" and  TB002 = '" + No + "'");
                stringBuilder.Append(" and  TB003 = '" + STT + "'");

                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataTableINVTATB (string code, string No, string STT)", ex.Message);
                return null;
            }
            return dt;
        }
        public DataTable GetDataTableINVTB(string code, string No, string STT)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  * from  INVTB 
where 1 =1 ");
                stringBuilder.Append(" and TB001 = '" + code + "'");
                stringBuilder.Append(" and  TB002 = '" + No + "'");
                stringBuilder.Append(" and  TB003 = '" + STT + "'");

                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataTableINVTATB (string code, string No, string STT)", ex.Message);
                return null;
            }
            return dt;
        }
        public int SelectMaxSTT(string code, string No)
        {
            int maxSTT = 1;

            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  convert ( int,MAX(TB003)) as MaxSTT from  INVTB 
where 1 =1");
                stringBuilder.Append(" and TB001 = '" + code + "'");
                stringBuilder.Append(" and  TB002 = '" + No + "'");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                string MaxSTT = sqlTLVN2.sqlExecuteScalarString(stringBuilder.ToString());
                maxSTT = int.Parse(MaxSTT);
            }
            catch (Exception)
            {

                throw;
            }
            return maxSTT;
        }

        public bool DeleteINVTBbyRow (string code, string No, string STT)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("  delete from INVTB where 1=1 ");
                stringBuilder.Append(" and TB001 = '" + code + "'");
                stringBuilder.Append(" and  TB002 = '" + No + "'");
                stringBuilder.Append(" and  TB003 = '" + STT + "'");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
             return   sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(),false);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "DeleteINVTBbyRow (string code, string No, string STT)", ex.Message);
                return false;
            }
      
            
        }
        public bool InsertInToINVTB( string STT, Model.LotINVMEMF lot, DataTable dtINVTB)
        {
            try
            {
                //    DataTable dtINVTB = GetDataTableINVTB(code, No, STT);
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                if (dtINVTB.Rows.Count > 0)
                {

                    StringBuilder stringBuilder = new StringBuilder();
                    StringBuilder stringFun = new StringBuilder();
                    stringBuilder.Append("insert into INVTB ( ");
                    for (int i = 0; i < dtINVTB.Columns.Count; i++)
                    {
                        if (i < dtINVTB.Columns.Count - 1)
                        {
                            if (dtINVTB.Columns[i].ColumnName != "CFIELD01")
                                stringBuilder.Append(dtINVTB.Columns[i].ColumnName + ",");
                        }
                        else stringBuilder.Append(dtINVTB.Columns[i].ColumnName + ") values ( ");
                    }
                   
                        for (int j = 0; j < dtINVTB.Columns.Count; j++)
                        {
                            string valueCell = "";
                        if (dtINVTB.Columns[j].ColumnName == "COMPANY")
                        {
                            valueCell = "TLVN2";
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "CREATOR")
                        {
                            valueCell = Class.valiballecommon.GetStorage().UserName;
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "USR_GROUP")
                        {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                            if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                                valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "CREATE_DATE")
                        {
                            valueCell = DateTime.Now.ToString("yyyyMMdd");
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "CREATE_TIME")
                        {
                            valueCell = DateTime.Now.ToString("HH:mm:ss");
                        }

                        else if (dtINVTB.Columns[j].ColumnName == "CREATE_AP")
                        {
                            valueCell = Class.valiballecommon.GetStorage().PCName;
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "CREATE_PRID")
                        {
                            valueCell = "INVI05";
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "FLAG")
                        {
                            valueCell = "1";
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "MODI_DATE")
                        {
                            valueCell = "NULL";
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "MODI_TIME")
                        {
                            valueCell = "NULL";
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "MODIFIER")
                        {
                            valueCell = "NULL";
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "MODI_AP")
                        {
                            valueCell = "NULL";
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "MODI_PRID")
                        {
                            valueCell = "NULL";
                        }
                        //TB001, TB002 
                        else if (dtINVTB.Columns[j].ColumnName == "TB001")
                        {
                            valueCell = dtINVTB.Rows[0]["TB001"].ToString();
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "TB002")
                        {
                            valueCell = dtINVTB.Rows[0]["TB002"].ToString();
                        }
                        else  if (dtINVTB.Columns[j].ColumnName == "TB003")
                            {
                                valueCell = STT;
                            }
                        else if (dtINVTB.Columns[j].ColumnName == "TB004")
                        {
                            valueCell = dtINVTB.Rows[0]["TB004"].ToString();
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "TB005")
                        {
                            valueCell = dtINVTB.Rows[0]["TB005"].ToString();
                        }
                        else if (dtINVTB.Columns[j].ColumnName == "TB007")
                            {
                                valueCell = lot.SL.ToString();
                            }
                            else if (dtINVTB.Columns[j].ColumnName == "TB014")
                            {
                                valueCell = lot.MF002_Lot.ToString();
                            }
                            else if (dtINVTB.Columns[j].ColumnName == "TB015")
                            {
                                valueCell = lot.ME009_ExpiryDate.ToString("yyyyMMdd");
                            }
                        else if (dtINVTB.Columns[j].ColumnName == "TB018")
                        {
                            valueCell = "N" ;
                        }
                        else valueCell = dtINVTB.Rows[0][dtINVTB.Columns[j].ColumnName].ToString();

                            if (j < dtINVTB.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                            else stringFun.Append("'" + valueCell + "')");
                        }
                    
                    string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                    SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                    return sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);
                }
                else return false;
                
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertInToINVTB( string STT, Model.LotINVMEMF lot, DataTable dtINVTB)", ex.Message);
                return false;
            }
         
        }
        public bool UpdateINVTA(string code, string No)
        {
            try
            {

           
            double SumSL = GetSumValueINVTB("TB007", code, No);
                double SumSoTien = GetSumValueINVTB("TB011", code, No);
                StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" update INVTA ");
            stringBuilder.Append(" set TA011 = '" + SumSL.ToString()+ "', ");
                stringBuilder.Append(" FLAG = FLAG +1 ,");
                stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                stringBuilder.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                stringBuilder.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                stringBuilder.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");

                stringBuilder.Append(" TA012 = '" + SumSoTien.ToString() + "' ");
            
                //    stringBuilder.Append("  Update_Date = 'GETDATE()' ");
                stringBuilder.Append(" where  TA001 = '" + code + "'");
            stringBuilder.Append(" and  TA002 = '" + No + "'");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
         return   sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateINVTA(string code, string No)", ex.Message);
                return false;
            }
            
        }
        public double GetSumValueINVTB(string TBx, string ma, string code)
        {
            double sum = 0;

            string sqlQuerry = "select sum(" + TBx + ") from INVTB where TB001 ='" + ma + "' and TB002 ='" + code + "'";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            string value = sqlTLVN2.sqlExecuteScalarString(sqlQuerry);
            try
            {
                sum = double.Parse(value.Trim());
            }
            catch (Exception)
            {

                sum = 0;
            }
            return sum;
        }
        public bool UpdateINVTAConfirm(List<INVTATB> nVTATB)
        {
            try
            {

                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                StringBuilder stringBuilder = new StringBuilder();

                foreach (var item in nVTATB)
                {
                   sqlTLVN2 = new SqlTLVN2();
                    stringBuilder = new StringBuilder();
                    stringBuilder.Append(" update INVTB ");
                    stringBuilder.Append(" set FLAG = FLAG +1 ,");
                    stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                    stringBuilder.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                    stringBuilder.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                    stringBuilder.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                    stringBuilder.Append(" MODI_PRID = '" + "INVMI08" + "' ,");
                    stringBuilder.Append(" TB007 = '" + item.TB007_SL.ToString() + "' ,");
                    stringBuilder.Append(" TB011 = TB010* "+ item.TB007_SL + ", ");
                    stringBuilder.Append(" TB018 = '" + "Y" + "'");
                    stringBuilder.Append(" where  TB001 = '" + item.TA001_ma + "'");
                    stringBuilder.Append(" and  TB002 = '" + item.TA002_code + "'");
                    stringBuilder.Append(" and  TB003 = '" + item.TB003_STT + "'");

                    sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                }



             
                double SumSL = GetSumValueINVTB("TB007", nVTATB[0].TA001_ma, nVTATB[0].TA002_code);
                double SumSoTien = GetSumValueINVTB("TB011", nVTATB[0].TA001_ma, nVTATB[0].TA002_code);
                stringBuilder = new StringBuilder();
                stringBuilder.Append(" update INVTA ");
                stringBuilder.Append(" set TA006 = '" + "Y" + "', ");
                stringBuilder.Append(" FLAG = FLAG +1 ,");
                stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                stringBuilder.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                stringBuilder.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                stringBuilder.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                stringBuilder.Append(" MODI_PRID = '" + "INVMI08" + "' ,");
                stringBuilder.Append(" TA011 = '" + SumSL.ToString() + "' ,");
                stringBuilder.Append(" TA012 = '" + SumSoTien.ToString() + "' ,");
                stringBuilder.Append(" TA015 = '" + Class.valiballecommon.GetStorage().UserName + "'");

                stringBuilder.Append(" where  TA001 = '" + nVTATB[0].TA001_ma + "'");
                stringBuilder.Append(" and  TA002 = '" + nVTATB[0].TA002_code + "'");
                sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateINVTA(string code, string No)", ex.Message);
                return false;
            }
            return true;
        }
     
        public bool dtgvOutToINVMF(List<INVTATB> iNVTATBs)
        {

           
            try
            {
                UpdateINVTAConfirm(iNVTATBs);
            foreach (var TATB in iNVTATBs)
            {
                DataTable dtINVMF = new DataTable();
                DataTable dtINVLA = new DataTable();
                DataTable dtINVLF = new DataTable();
                dtINVMF = GetdataINVMF(TATB.TB014_Lot, TATB.TB004_SP);
                dtINVLA = GetDataINVLA(TATB.TB004_SP);
                dtINVLF = GetDataINVLF(TATB.TB004_SP);
//Code Test MOCTC : lanh lieu cho lenh san xuat
                    if (TATB.TA001_ma.Substring(1, 2) == "54")
                    {
                        if (InsertINVMF(TATB, dtINVMF, -1) != true)
                            MessageBox.Show("Insert INVMF OutStock = -1 is not success");
                        if (InsertINVLA(TATB, dtINVLA, -1) != true)
                            MessageBox.Show("Insert INVLA OutStock = -1 is not success");
                        if (InsertINVLF(TATB, dtINVLF, -1) != true)
                            MessageBox.Show("Insert INVLF OutStock = -1 is not success");
                        UpdateorInsertINVMC(TATB, -1);
                        UpdateorInsertINVMM(TATB, -1);
                    }
                    else
                    {

                        if (TATB.TA001_ma.Substring(0, 2) == "11")
                        {
                            if (InsertINVMF(TATB, dtINVMF, -1) != true)
                                MessageBox.Show("Insert INVMF OutStock = -1 is not success");
                        }
                        else
                        {
                            if (InsertINVMF(TATB, dtINVMF, 1) != true)
                                MessageBox.Show("Insert INVMF OutStock (OutStock = 1) is not success");
                            if (InsertINVMF(TATB, dtINVMF, -1) != true)

                                MessageBox.Show("Insert INVMF OutStock = -1 is not success");
                        }
                        if (TATB.TA001_ma.Substring(0, 2) == "11")
                        {

                            if (InsertINVLA(TATB, dtINVLA, -1) != true)
                                MessageBox.Show("Insert INVLA OutStock = -1 is not success");
                        }
                        else
                        {
                            if (InsertINVLA(TATB, dtINVLA, 1) != true)
                                MessageBox.Show("Insert INVLA OutStock (OutStock = 1) is not success");
                            if (InsertINVLA(TATB, dtINVLA, -1) != true)
                                MessageBox.Show("Insert INVLA OutStock = -1 is not success");
                        }
                        if (TATB.TA001_ma.Substring(0, 2) == "11")
                        {

                            if (InsertINVLF(TATB, dtINVLF, -1) != true)
                                MessageBox.Show("Insert INVLF OutStock = -1 is not success");
                            UpdateorInsertINVMC(TATB, -1);
                            UpdateorInsertINVMM(TATB, -1);
                        }
                        else
                        {
                            if (InsertINVLF(TATB, dtINVLF, 1) != true)
                                MessageBox.Show("Insert INVLF OutStock (OutStock = 1) is not success");
                            if (InsertINVLF(TATB, dtINVLF, -1) != true)
                                MessageBox.Show("Insert INVLF OutStock = -1 is not success");

                            UpdateorInsertINVMC(TATB, -1);
                            UpdateorInsertINVMC(TATB, 1);

                            UpdateorInsertINVMM(TATB, -1);
                            UpdateorInsertINVMM(TATB, 1);
                        }
                    }
            }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "dtgvOutToINVMF(List<INVTATB> iNVTATBs)", ex.Message);
            }
            return false;

        }
        public bool dtgvStockOutDelete(List<INVTATB> iNVTATBsNoChose)
        {
            try
            {
                foreach (var item in iNVTATBsNoChose)
                {
                    if (DeleteINVTBbyRow(item.TA001_ma, item.TA002_code, item.TB003_STT) == false)
                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "Delete row INVTB fail", item.TA001_ma + "-" + item.TA002_code + "-" + item.TB003_STT);
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Delete row INVTB fail", ex.Message);
                return false;
            }
           
            return true;
        }
        public bool InsertINVMF (INVTATB iNVTATB, DataTable dtINVMF,int intInOut)
        {
            try
            {
                DataTable dataINVTB = GetDataTableINVTB(iNVTATB.TA001_ma, iNVTATB.TA002_code, iNVTATB.TB003_STT);
                DataTable dataCMSMQ = GetdataCMSMQ(iNVTATB.TA001_ma);
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringFun = new StringBuilder();
                stringBuilder.Append("insert into INVMF ( ");
                for (int i = 0; i < dtINVMF.Columns.Count; i++)
                {
                    if (i < dtINVMF.Columns.Count - 1)
                    {

                        stringBuilder.Append(dtINVMF.Columns[i].ColumnName + ",");
                    }
                    else stringBuilder.Append(dtINVMF.Columns[i].ColumnName + ") values ( ");
                }
              
                    for (int j = 0; j < dtINVMF.Columns.Count; j++)
                    {
                        string valueCell = "";

                        if (dtINVMF.Columns[j].ColumnName == "COMPANY")
                        {
                              valueCell = "TLVN2";
                        }
                        else if (dtINVMF.Columns[j].ColumnName == "CREATOR")
                        {
                              valueCell = Class.valiballecommon.GetStorage().UserName;
                        }
                    else if (dtINVMF.Columns[j].ColumnName == "USR_GROUP")
                    {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                        if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                            valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "CREATE_DATE")
                        {
                            valueCell = DateTime.Now.ToString("yyyyMMdd");
                        }
                        else if (dtINVMF.Columns[j].ColumnName == "CREATE_TIME")
                        {
                            valueCell = DateTime.Now.ToString("HH:mm:ss");
                        }
                        
                        else if (dtINVMF.Columns[j].ColumnName == "CREATE_AP")
                        {
                            valueCell =   Class.valiballecommon.GetStorage().PCName ;
                        }
                        else if (dtINVMF.Columns[j].ColumnName == "CREATE_PRID")
                        {
                            valueCell = "INVMI08";
                        }
                    else if (dtINVMF.Columns[j].ColumnName == "FLAG")
                    {
                        valueCell = "1";
                    }

                    else if (dtINVMF.Columns[j].ColumnName == "MODI_DATE")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MODI_TIME")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MODIFIER")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MODI_AP")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MODI_PRID")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF003")
                        {
                            valueCell = iNVTATB.TA014_ngayCT.ToString("yyyyMMdd");
                        }
                        else if (dtINVMF.Columns[j].ColumnName == "MF004")
                        {
                            valueCell = iNVTATB.TA001_ma;
                        }
                        else if (dtINVMF.Columns[j].ColumnName == "MF005")
                        {
                            valueCell = iNVTATB.TA002_code;
                        }
                        else if (dtINVMF.Columns[j].ColumnName == "MF006")
                        {
                            valueCell = iNVTATB.TB003_STT;
                        }
                        else if (dtINVMF.Columns[j].ColumnName == "MF007")
                        {if (intInOut == -1)
                                valueCell = iNVTATB.TB012_KhoChuyen;
                            else if (intInOut == 1)
                                valueCell = iNVTATB.TB013_khoNhan;
                        }
                        else if (dtINVMF.Columns[j].ColumnName == "MF008")
                        {
                            valueCell = intInOut.ToString();
                        }
                        else if (dtINVMF.Columns[j].ColumnName == "MF009")
                        {
                            valueCell = dataCMSMQ.Rows[0]["MQ008"].ToString();
                        }
                        else if (dtINVMF.Columns[j].ColumnName == "MF010")
                        {
                            valueCell =iNVTATB.TB007_SL.ToString();
                        }
                    else if (dtINVMF.Columns[j].ColumnName == "MF013")
                    {
                        valueCell = dataINVTB.Rows[0]["TB017"].ToString();//TB017
                    }
                    else valueCell = dtINVMF.Rows[0][dtINVMF.Columns[j].ColumnName].ToString();

                        if (j < dtINVMF.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                        else stringFun.Append("'" + valueCell + "')");
                    
                }
                   string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                    SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                    return sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);
                
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertINVMF (INVTATB iNVTATB, DataTable dtINVMF,int intInOut)", ex.Message);
                return false;
            }

            
        }
        public bool InsertINVLA(INVTATB iNVTATB, DataTable dtINVLA, int intInOut)
        {
            try
            {
                DataTable dataINVTB = GetDataTableINVTB(iNVTATB.TA001_ma, iNVTATB.TA002_code, iNVTATB.TB003_STT);
                DataTable dataCMSMQ = GetdataCMSMQ(iNVTATB.TA001_ma);
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringFun = new StringBuilder();
                stringBuilder.Append("insert into INVLA ( ");
                for (int i = 0; i < dtINVLA.Columns.Count; i++)
                {
                    if (i < dtINVLA.Columns.Count - 1)
                    {

                        stringBuilder.Append(dtINVLA.Columns[i].ColumnName + ",");
                    }
                    else stringBuilder.Append(dtINVLA.Columns[i].ColumnName + ") values ( ");
                }
              
                    for (int j = 0; j < dtINVLA.Columns.Count; j++)
                    {
                        string valueCell = "";

                        if (dtINVLA.Columns[j].ColumnName == "COMPANY")
                        {
                            valueCell = "TLVN2";
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "CREATOR")
                        {
                            valueCell = Class.valiballecommon.GetStorage().UserName;
                        }
                    else if (dtINVLA.Columns[j].ColumnName == "USR_GROUP")
                    {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                        if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                            valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "CREATE_DATE")
                        {
                            valueCell = DateTime.Now.ToString("yyyyMMdd");
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "CREATE_TIME")
                        {
                            valueCell = DateTime.Now.ToString("HH:mm:ss");
                        }

                        else if (dtINVLA.Columns[j].ColumnName == "CREATE_AP")
                        {
                            valueCell =   Class.valiballecommon.GetStorage().PCName;
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "CREATE_PRID")
                        {
                            valueCell = "INVMI08";
                        }
                    else if (dtINVLA.Columns[j].ColumnName == "FLAG")
                    {
                        valueCell = "1";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "MODI_DATE")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "MODI_TIME")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "MODIFIER")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "MODI_AP")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "MODI_PRID")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA001")
                        {
                            valueCell = iNVTATB.TB004_SP;
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "LA004")
                        {
                            valueCell = iNVTATB.TA014_ngayCT.ToString("yyyyMMdd");
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "LA005")
                        {
                            valueCell = intInOut.ToString();
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "LA006")
                        {
                            valueCell = iNVTATB.TA001_ma;
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "LA007")
                        {
                            valueCell = iNVTATB.TA002_code;
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "LA008")
                        {
                            valueCell = iNVTATB.TB003_STT;
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "LA009")
                        {
                            if (intInOut == -1)
                                valueCell = iNVTATB.TB012_KhoChuyen;
                            else if (intInOut == 1)
                                valueCell = iNVTATB.TB013_khoNhan;
                        }
                    else if (dtINVLA.Columns[j].ColumnName == "LA010")
                    {
                        valueCell = dataINVTB.Rows[0]["TB017"].ToString();//TB017
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA011")
                        {
                            valueCell = iNVTATB.TB007_SL.ToString();
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "LA014")
                        {
                            valueCell = dataCMSMQ.Rows[0]["MQ008"].ToString();
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "LA015")
                        {
                            valueCell = dataCMSMQ.Rows[0]["MQ011"].ToString();
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "LA016")
                        {
                            valueCell = iNVTATB.TB014_Lot;
                        }
                        else if (dtINVLA.Columns[j].ColumnName == "LA022")
                        {
                            if (intInOut == -1)
                                valueCell = iNVTATB.TB026_VtKhoChuyen;
                            else if (intInOut == 1)
                                valueCell = iNVTATB.TB027_VtKhoNhan;
                        }
                        else valueCell = dtINVLA.Rows[0][dtINVLA.Columns[j].ColumnName].ToString();

                        if (j < dtINVLA.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                        else stringFun.Append("'" + valueCell + "')");
                    
                }
                string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                return sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);

            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertINVLA(INVTATB iNVTATB, DataTable dtINVLA, int intInOut)", ex.Message);
                return false;
            }
        }

        public bool InsertINVLF(INVTATB iNVTATB, DataTable dtINVLF, int intInOut)
        {
            try
            {
                DataTable dataINVTB = GetDataTableINVTB(iNVTATB.TA001_ma, iNVTATB.TA002_code, iNVTATB.TB003_STT);
                DataTable dataCMSMQ = GetdataCMSMQ(iNVTATB.TA001_ma);
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringFun = new StringBuilder();
                stringBuilder.Append("insert into INVLF ( ");
                for (int i = 0; i < dtINVLF.Columns.Count; i++)
                {
                    if (i < dtINVLF.Columns.Count - 1)
                    {

                        stringBuilder.Append(dtINVLF.Columns[i].ColumnName + ",");
                    }
                    else stringBuilder.Append(dtINVLF.Columns[i].ColumnName + ") values ( ");
                }
             
                    for (int j = 0; j < dtINVLF.Columns.Count; j++)
                    {
                        string valueCell = "";

                        if (dtINVLF.Columns[j].ColumnName == "COMPANY")
                        {
                            valueCell = "TLVN2";
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "CREATOR")
                        {
                            valueCell = Class.valiballecommon.GetStorage().UserName;
                        }
                    else if (dtINVLF.Columns[j].ColumnName == "USR_GROUP")
                    {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                        if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                            valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "CREATE_DATE")
                        {
                            valueCell = DateTime.Now.ToString("yyyyMMdd");
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "CREATE_TIME")
                        {
                            valueCell = DateTime.Now.ToString("HH:mm:ss");
                        } 

                        else if (dtINVLF.Columns[j].ColumnName == "CREATE_AP")
                        {
                            valueCell =   Class.valiballecommon.GetStorage().PCName;
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "CREATE_PRID")
                        {
                            valueCell = "INVMI08";
                        }
                    else if (dtINVLF.Columns[j].ColumnName == "FLAG")
                    {
                        valueCell = "1";
                    }

                    else if (dtINVLF.Columns[j].ColumnName == "MODI_DATE")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "MODI_TIME")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "MODIFIER")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "MODI_AP")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "MODI_PRID")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF001")
                        {
                            valueCell = iNVTATB.TA001_ma;
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "LF002")
                        {
                            valueCell = iNVTATB.TA002_code;
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "LF003")
                        {
                            valueCell = iNVTATB.TB003_STT;
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "LF004")
                        {
                            valueCell = iNVTATB.TB004_SP;
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "LF005")
                        {
                            if (intInOut == -1)
                                valueCell = iNVTATB.TB012_KhoChuyen;
                            else if (intInOut == 1)
                                valueCell = iNVTATB.TB013_khoNhan;
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "LF006")
                        {
                        if (intInOut == -1)
                        {
                            if( iNVTATB.TB026_VtKhoChuyen=="")
                            {
                                valueCell = "##########";
                            }
                            else
                            {
                                valueCell = iNVTATB.TB026_VtKhoChuyen;
                            }
                        }
                               
                            else if (intInOut == 1)
                        {
                            if (iNVTATB.TB027_VtKhoNhan  == "")
                            {
                                valueCell = "##########";
                            }
                            else
                            {
                                valueCell = iNVTATB.TB027_VtKhoNhan;
                            }
                        }
                              

                        }
                        else if (dtINVLF.Columns[j].ColumnName == "LF007")
                        {
                            valueCell = iNVTATB.TB014_Lot;
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "LF008")
                        {
                            valueCell = intInOut.ToString();
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "LF009")
                        {
                           
                                valueCell = iNVTATB.TA014_ngayCT.ToString("yyyyMMdd");
                          
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "LF010")
                        {
                            valueCell = dataCMSMQ.Rows[0]["MQ008"].ToString();
                        }
                        else if (dtINVLF.Columns[j].ColumnName == "LF011")
                        {
                            valueCell = iNVTATB.TB007_SL.ToString();
                        }
                    else if (dtINVLF.Columns[j].ColumnName == "LF013")
                    {
                        valueCell = dataINVTB.Rows[0]["TB017"].ToString();//TB017
                    }
                    else valueCell = dtINVLF.Rows[0][dtINVLF.Columns[j].ColumnName].ToString();

                        if (j < dtINVLF.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                        else stringFun.Append("'" + valueCell + "')");
                    }
                
                string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                return sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);

            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertINVLA(INVTATB iNVTATB, DataTable dtINVLA, int intInOut)", ex.Message);
                return false;
            }
        }
        public DataTable GetdataINVMF (string lot, string sp)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select top(1) * from INVMF where 1=1 ");
                stringBuilder.Append(" and MF001 ='" + sp + "' ");
                stringBuilder.Append(" and MF002 ='" + lot + "' ");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetdataINVMF (string lot, string sp)", ex.Message);
                
            }
            return dt;
        }
        public DataTable GetdataCMSMQ(string ma)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select top(1) * from CMSMQ where 1=1 ");
                stringBuilder.Append(" and MQ001 ='" + ma + "' ");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        public DataTable GetDataINVLA(string product)
        {
            DataTable data = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select top(1) * from INVLA where 1=1 ");
                stringBuilder.Append(" and LA001 ='" + product + "'");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref data);
                return data;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataINVLA(string product)", ex.Message);
                return data;
            }
        }

        public DataTable GetDataINVLF(string product)
        {
            DataTable data = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select top(1) * from INVLF where 1=1 ");
                stringBuilder.Append(" and LF004 ='" + product + "'");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref data);
                return data;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataINVLF(string product)", ex.Message);
                return data;
            }
        }




        public bool UpdateorInsertINVMC(INVTATB nVTATB, int InOutIndex)
        {
            try
            {
                DataTable dataINVMC = GetDataINVMC(nVTATB.TB004_SP, nVTATB.TB012_KhoChuyen);
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                if (InOutIndex == -1)
                {
                 //   DataTable dataINVMC = GetDataINVMC(nVTATB.TB004_SP, nVTATB.TB012_KhoChuyen);
                    if (dataINVMC.Rows.Count > 0)
                    {
                        //Update row 
                        StringBuilder strKhoChuyen = new StringBuilder();
                        strKhoChuyen.Append(" update INVMC ");
                        strKhoChuyen.Append(" set MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                        strKhoChuyen.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                        strKhoChuyen.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                        strKhoChuyen.Append(" MODI_PRID = '" + "INVMI08" + "' ,");
                        strKhoChuyen.Append(" FLAG = FLAG+1 ,");
                        strKhoChuyen.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                        strKhoChuyen.Append(" MC007 = MC007 - " + nVTATB.TB007_SL + " , ");
                        strKhoChuyen.Append(" MC013 = '" + DateTime.Now.ToString("yyyyMMdd") + "' ");
                        strKhoChuyen.Append(" where 1=1 ");
                        strKhoChuyen.Append(" and MC001 ='" + nVTATB.TB004_SP + "'");
                        strKhoChuyen.Append(" and MC002 ='" + nVTATB.TB012_KhoChuyen + "'");
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(strKhoChuyen.ToString(), false);
                    }
                    else
                    {
                        // Insert new row
                        dataINVMC = GetDataINVMCTop1();
                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringFun = new StringBuilder();
                        stringBuilder.Append("insert into INVMC ( ");
                        for (int i = 0; i < dataINVMC.Columns.Count; i++)
                        {
                            if (i < dataINVMC.Columns.Count - 1)
                            {

                                stringBuilder.Append(dataINVMC.Columns[i].ColumnName + ",");
                            }
                            else stringBuilder.Append(dataINVMC.Columns[i].ColumnName + ") values ( ");
                        }

                        for (int j = 0; j < dataINVMC.Columns.Count; j++)
                        {
                            string valueCell = "";

                            if (dataINVMC.Columns[j].ColumnName == "COMPANY")
                            {
                                valueCell = "TLVN2";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATOR")
                            {
                                valueCell = Class.valiballecommon.GetStorage().UserName;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "USR_GROUP")
                            {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                                if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                                    valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "FLAG")
                            {
                                valueCell = "1";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_DATE")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_TIME")
                            {
                                valueCell = DateTime.Now.ToString("HH:mm:ss");
                            }

                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_AP")
                            {
                                valueCell = Class.valiballecommon.GetStorage().PCName;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_PRID")
                            {
                                valueCell = "INVMI08";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_DATE")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_TIME")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODIFIER")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_AP")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_PRID")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC001")
                            {
                                valueCell = nVTATB.TB004_SP;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC002")
                            {
                                valueCell = nVTATB.TB012_KhoChuyen;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC003")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC004")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC005")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC006")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC007")
                            {
                                valueCell = (-nVTATB.TB007_SL).ToString();
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC008")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC009")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC010")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC011")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC012")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC013")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC014")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC015")
                            {
                                valueCell = nVTATB.TB026_VtKhoChuyen;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC016")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC017")
                            {
                                valueCell = "0";
                            }

                            else valueCell = dataINVMC.Rows[0][dataINVMC.Columns[j].ColumnName].ToString();

                            if (j < dataINVMC.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                            else stringFun.Append("'" + valueCell + "')");
                        }

                        string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);

                    }
                }
                if (InOutIndex == 1)
                {

                    DataTable dataINVMCKhoNhan = GetDataINVMC(nVTATB.TB004_SP, nVTATB.TB013_khoNhan);
                    if (dataINVMCKhoNhan.Rows.Count > 0)
                    {
                        //Update row 
                        StringBuilder strKhoChuyen = new StringBuilder();
                        strKhoChuyen.Append(" update INVMC ");
                        strKhoChuyen.Append(" set MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                        strKhoChuyen.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                        strKhoChuyen.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                        strKhoChuyen.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                        strKhoChuyen.Append(" MODI_PRID = '" + "INVMI08" + "' ,");
                        strKhoChuyen.Append(" FLAG = FLAG+1 ,");
                        strKhoChuyen.Append(" MC007 = MC007 + " + nVTATB.TB007_SL + " , ");
                        strKhoChuyen.Append(" MC013 = '" + DateTime.Now.ToString("yyyyMMdd") + "' ");
                        strKhoChuyen.Append(" where 1=1 ");
                        strKhoChuyen.Append(" and MC001 ='" + nVTATB.TB004_SP + "'");
                        strKhoChuyen.Append(" and MC002 ='" + nVTATB.TB013_khoNhan + "'");
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(strKhoChuyen.ToString(), false);
                    }
                    else
                    {
                        // Insert new row

                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringFun = new StringBuilder();
                        stringBuilder.Append("insert into INVMC ( ");
                        for (int i = 0; i < dataINVMC.Columns.Count; i++)
                        {
                            if (i < dataINVMC.Columns.Count - 1)
                            {

                                stringBuilder.Append(dataINVMC.Columns[i].ColumnName + ",");
                            }
                            else stringBuilder.Append(dataINVMC.Columns[i].ColumnName + ") values ( ");
                        }

                        for (int j = 0; j < dataINVMC.Columns.Count; j++)
                        {
                            string valueCell = "";

                            if (dataINVMC.Columns[j].ColumnName == "COMPANY")
                            {
                                valueCell = "TLVN2";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATOR")
                            {
                                valueCell = Class.valiballecommon.GetStorage().UserName;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "USR_GROUP")
                            {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                                if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                                    valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "FLAG")
                            {
                                valueCell = "1";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_DATE")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_TIME")
                            {
                                valueCell = DateTime.Now.ToString("HH:mm:ss");
                            }

                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_AP")
                            {
                                valueCell = Class.valiballecommon.GetStorage().PCName;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_PRID")
                            {
                                valueCell = "INVMI08";
                            }

                            else if (dataINVMC.Columns[j].ColumnName == "MODI_DATE")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_TIME")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODIFIER")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_AP")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_PRID")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC001")
                            {
                                valueCell = nVTATB.TB004_SP;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC002")
                            {
                                valueCell = nVTATB.TB013_khoNhan;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC003")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC004")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC005")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC006")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC007")
                            {
                                valueCell = nVTATB.TB007_SL.ToString();
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC008")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC009")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC010")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC011")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC012")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC013")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC014")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC015")
                            {
                                valueCell = nVTATB.TB027_VtKhoNhan;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC016")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC017")
                            {
                                valueCell = "0";
                            }

                            else valueCell = dataINVMC.Rows[0][dataINVMC.Columns[j].ColumnName].ToString();

                            if (j < dataINVMC.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                            else stringFun.Append("'" + valueCell + "')");
                        }

                        string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);
                    }
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateorInsertINVMC (INVTATB nVTATB)", ex.Message);
                return false;
            }
            return true;
        }

        public bool UpdateorInsertINVMM(INVTATB nVTATB, int InOutIndex)
        {
            try
            {
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                DataTable dataINVMM = GetDataINVMM(nVTATB.TB004_SP, nVTATB.TB012_KhoChuyen, nVTATB.TB026_VtKhoChuyen,nVTATB.TB014_Lot);
                if (InOutIndex == -1)
                {
                    if (dataINVMM.Rows.Count > 0)
                    {
                        //Update row 
                        StringBuilder strKhoChuyen = new StringBuilder();
                        strKhoChuyen.Append(" update INVMM ");
                        strKhoChuyen.Append(" set MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                        strKhoChuyen.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                        strKhoChuyen.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                        strKhoChuyen.Append(" MODI_PRID = '" + "INVMI08" + "' ,");
                        strKhoChuyen.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                        strKhoChuyen.Append(" FLAG = FLAG+1 ,");
                        strKhoChuyen.Append(" MM005 = MM005 - " + nVTATB.TB007_SL + " , ");
                        strKhoChuyen.Append(" MM009 = '" + DateTime.Now.ToString("yyyyMMdd") + "' ");
                        strKhoChuyen.Append(" where 1=1 ");
                        strKhoChuyen.Append(" and MM001 = '" + nVTATB.TB004_SP + "'");
                        strKhoChuyen.Append(" and MM002 ='" + nVTATB.TB012_KhoChuyen + "'");
                        if(nVTATB.TB026_VtKhoChuyen =="")
                            strKhoChuyen.Append(" and MM003 ='" + "##########" + "'"); 
                        else
                            strKhoChuyen.Append(" and MM003 ='" + nVTATB.TB026_VtKhoChuyen + "'");
                        strKhoChuyen.Append(" and MM004 ='" + nVTATB.TB014_Lot + "'");
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(strKhoChuyen.ToString(), false);
                    }
                    else
                    {
                        // Insert new row
                        dataINVMM = GetDataINVMMTop1();
                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringFun = new StringBuilder();
                        stringBuilder.Append("insert into INVMM ( ");
                        for (int i = 0; i < dataINVMM.Columns.Count; i++)
                        {
                            if (i < dataINVMM.Columns.Count - 1)
                            {

                                stringBuilder.Append(dataINVMM.Columns[i].ColumnName + ",");
                            }
                            else stringBuilder.Append(dataINVMM.Columns[i].ColumnName + ") values ( ");
                        }

                        for (int j = 0; j < dataINVMM.Columns.Count; j++)
                        {
                            string valueCell = "";

                            if (dataINVMM.Columns[j].ColumnName == "COMPANY")
                            {
                                valueCell = "TLVN2";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "FLAG")
                            {
                                valueCell = "1";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATOR")
                            {
                                valueCell = Class.valiballecommon.GetStorage().UserName;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "USR_GROUP")
                            {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                                if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                                    valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_DATE")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_TIME")
                            {
                                valueCell = DateTime.Now.ToString("HH:mm:ss");
                            }


                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_AP")
                            {
                                valueCell = Class.valiballecommon.GetStorage().PCName;
                            }

                            else if (dataINVMM.Columns[j].ColumnName == "MODI_DATE")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_TIME")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODIFIER")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_AP")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_PRID")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_PRID")
                            {
                                valueCell = "INVMI08";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM001")
                            {
                                valueCell = nVTATB.TB004_SP;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM002")
                            {
                                valueCell = nVTATB.TB012_KhoChuyen;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM003")
                            {if(nVTATB.TB026_VtKhoChuyen =="")
                                {
                                    valueCell = "##########";
                                }
                               
                            else
                                {
                                    valueCell = nVTATB.TB026_VtKhoChuyen;
                                }
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM004")
                            {
                                valueCell = nVTATB.TB014_Lot;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM005")
                            {
                                valueCell = (-nVTATB.TB007_SL).ToString();
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM006")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM007")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM008")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM009")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM010")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM011")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM012")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM013")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM014")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM015")
                            {
                                valueCell = "";
                            }


                            else valueCell = dataINVMM.Rows[0][dataINVMM.Columns[j].ColumnName].ToString();

                            if (j < dataINVMM.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                            else stringFun.Append("'" + valueCell + "')");
                        }

                        string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);

                    }
                }
                if(InOutIndex ==1)
                { 
                DataTable dataINVMMKhoNhan = GetDataINVMM(nVTATB.TB004_SP, nVTATB.TB013_khoNhan, nVTATB.TB027_VtKhoNhan ,nVTATB.TB014_Lot);
                    if (dataINVMMKhoNhan.Rows.Count > 0)
                    {
                        //Update row 
                        //Update row 
                        StringBuilder strKhoChuyen = new StringBuilder();
                        strKhoChuyen.Append(" update INVMM ");
                        strKhoChuyen.Append(" set MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                        strKhoChuyen.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                        strKhoChuyen.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                        strKhoChuyen.Append(" MODI_PRID = '" + "INVMI08" + "' ,");
                        strKhoChuyen.Append(" FLAG = FLAG+1 ,");
                        strKhoChuyen.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                        strKhoChuyen.Append(" MM005 = MM005 + " + nVTATB.TB007_SL + " , ");
                        strKhoChuyen.Append(" MM009 = '" + DateTime.Now.ToString("yyyyMMdd") + "' ");
                        strKhoChuyen.Append(" where 1=1 ");
                        strKhoChuyen.Append(" and MM001 = '" + nVTATB.TB004_SP + "'");
                        strKhoChuyen.Append(" and MM002 ='" + nVTATB.TB013_khoNhan + "'");
                        if(nVTATB.TB027_VtKhoNhan =="")
                            strKhoChuyen.Append(" and MM003 ='" + "##########" + "'");
                        else
                            strKhoChuyen.Append(" and MM003 ='" + nVTATB.TB027_VtKhoNhan + "'");
                        
                        strKhoChuyen.Append(" and MM004 ='" + nVTATB.TB014_Lot + "'");
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(strKhoChuyen.ToString(), false);
                    }
                    else
                    {
                        // Insert new row

                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringFun = new StringBuilder();
                        stringBuilder.Append("insert into INVMM ( ");
                        for (int i = 0; i < dataINVMM.Columns.Count; i++)
                        {
                            if (i < dataINVMM.Columns.Count - 1)
                            {

                                stringBuilder.Append(dataINVMM.Columns[i].ColumnName + ",");
                            }
                            else stringBuilder.Append(dataINVMM.Columns[i].ColumnName + ") values ( ");
                        }

                        for (int j = 0; j < dataINVMM.Columns.Count; j++)
                        {
                            string valueCell = "";

                            if (dataINVMM.Columns[j].ColumnName == "COMPANY")
                            {
                                valueCell = "TLVN2";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "FLAG")
                            {
                                valueCell = "1";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATOR")
                            {
                                valueCell = Class.valiballecommon.GetStorage().UserName;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "USR_GROUP")
                            {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                                if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                                    valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_DATE")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_TIME")
                            {
                                valueCell = DateTime.Now.ToString("HH:mm:ss");
                            }

                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_AP")
                            {
                                valueCell = Class.valiballecommon.GetStorage().PCName;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_PRID")
                            {
                                valueCell = "INVMI08";
                            }

                            else if (dataINVMM.Columns[j].ColumnName == "MODI_DATE")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_TIME")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODIFIER")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_AP")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_PRID")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM001")
                            {
                                valueCell = nVTATB.TB004_SP;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM002")
                            {
                                valueCell = nVTATB.TB013_khoNhan;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM003")
                            {
                                if(nVTATB.TB027_VtKhoNhan =="")
                                {
                                    valueCell = "##########";
                                }
                               
                                else
                                {
                                    valueCell = nVTATB.TB027_VtKhoNhan;
                                }
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM004")
                            {
                                valueCell = nVTATB.TB014_Lot;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM005")
                            {
                                valueCell = nVTATB.TB007_SL.ToString();
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM006")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM007")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM008")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM009")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM010")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM011")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM012")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM013")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM014")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM015")
                            {
                                valueCell = "";
                            }


                            else valueCell = dataINVMM.Rows[0][dataINVMM.Columns[j].ColumnName].ToString();

                            if (j < dataINVMM.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                            else stringFun.Append("'" + valueCell + "')");
                        }

                        string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);
                    }
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateorInsertINVMM (INVTATB nVTATB)", ex.Message);
            }
            return true;
        }
        public DataTable GetDataINVMC(string MC001_sp, string MC002_kho )
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select * from INVMC where 1=1");
                stringBuilder.Append(" and MC001 ='" + MC001_sp + "'");
                stringBuilder.Append(" and MC002 ='" + MC002_kho + "'");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
             
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataINVMC(string MC001_sp, string MC002_kho )", ex.Message);
            }
            return dt;
        }
        public DataTable GetDataINVMCTop1()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select top(1) * from INVMC where 1=1");
              
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataINVMCTop1", ex.Message);
            }
            return dt;
        }
        public DataTable GetDataINVMM(string MM001_sp, string MM002_kho,string MM003_pos, string MM004_lot)
        {
            DataTable dt = new DataTable();
            try
            {
                if (MM003_pos == "")
                    MM003_pos = "##########";
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select * from INVMM where 1=1");
                stringBuilder.Append(" and MM001 ='" + MM001_sp + "'");
                stringBuilder.Append(" and MM002 ='" + MM002_kho + "'");
                stringBuilder.Append(" and MM003 ='" + MM003_pos + "'");
                stringBuilder.Append(" and MM004='" + MM004_lot + "'");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataINVMM(string MM001_sp, string MM002_kho,string MM003_pos, string MM004_lot)", ex.Message);
            }
            return dt;
        }
        public DataTable GetDataINVMMTop1()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select * from INVMM where 1=1");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataINVMMTop1", ex.Message);
            }
            return dt;
        }

        public DataTable GetNameOfProductCode (string maSp)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select top(1) TD005 from PURTD where 1=1 ");
                stringBuilder.Append(" and TD004 like '%" + maSp + "%'");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetNameOfProductCode (string maSp)", ex.Message);
            }
           
            
            return dt;
        }
        public DataTable GetDataTableADMMF(string account)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select *  from ADMMF where 1=1 ");
                stringBuilder.Append(" and MF001 = '" + account + "'");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetNameOfProductCode (string maSp)", ex.Message);
            }


            return dt;
        }
        public Dictionary<string, int> NumberDigitsofCodeINVTA()
        {
            Dictionary<string, int> keyValues = new Dictionary<string, int>();
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select DISTINCT TA001,LEN(TA001)+ LEN(TA002)+1 AS COUNT from INVTA 
GROUP BY TA001, TA002 ");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string key = dt.Rows[i]["TA001"].ToString();
                    int value = int.Parse(dt.Rows[i]["COUNT"].ToString());
                    keyValues.Add(key, value);
                }

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Dictionary<string, int> NumberDigitsofCodeINVTA()", ex.Message);
            }
            return keyValues;
        }
      

        #endregion


        public List<dataWarehouse> GetDataWarehousesfromINVMM (string warehouse,DateTime datetime )
        {
            List<dataWarehouse> datas = new List<dataWarehouse>();
            List<dataWarehouse> datasSortExpiryDate = new List<dataWarehouse>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select *, ME009 from INVMM mm
left join INVME  on MM001 = ME001 and MM004 = ME002
where 1 = 1 ");
                stringBuilder.Append(" and MM002 ='" + warehouse + "' ");
             //   stringBuilder.Append(" and ME009  >= '" + datetime.ToString("yyyyMMdd") + "' ");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                DataTable dt = new DataTable();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataWarehouse data = new dataWarehouse();
                    data.checkbox = false;
                    data.warehouse_MM002 = dt.Rows[i]["MM002"].ToString();
                    data.location_MM003 = dt.Rows[i]["MM003"].ToString();
                    data.maSP_MM001 = dt.Rows[i]["MM001"].ToString();
                    data.Lot_MM004 = dt.Rows[i]["MM004"].ToString();
                    data.Soluong_MM005 = double.Parse(dt.Rows[i]["MM005"].ToString().Trim());
                    data.ExpiryDate = (dt.Rows[i]["ME009"].ToString() != "") ? DateTime.ParseExact(dt.Rows[i]["ME009"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture) : DateTime.MaxValue;
                    if (data.ExpiryDate == DateTime.MinValue || data.ExpiryDate >= datetime)
                    {
                        if(data.Soluong_MM005 > 0)
                        datas.Add(data);
                    }

                }
                //datas = (from DataRow dr in dt.Rows
                //         select new dataWarehouse()
                //         {  checkbox = false,
                //             warehouse_MM002 = dr["MM002"].ToString(),
                //             location_MM003 = dr["MM003"].ToString(),
                //             maSP_MM001 = dr["MM001"].ToString(),
                //             Lot_MM004 = dr["MM004"].ToString(),
                //             Soluong_MM005 = double.Parse(dr["MM005"].ToString().Trim()),
                             
                //             ExpiryDate = (dr["ME009"].ToString() != "") ? DateTime.ParseExact(dr["ME009"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture) : DateTime.MinValue,

                //         }).ToList();
                datasSortExpiryDate = datas.OrderBy(d => d.ExpiryDate).ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return datasSortExpiryDate;
        }
        public List<dataWarehouse> GetDataWarehousesfromINVMMFiltterLot(string warehouse, DateTime datetime,string lot,string material)
        {
            List<dataWarehouse> datas = new List<dataWarehouse>();
            List<dataWarehouse> datasSortExpiryDate = new List<dataWarehouse>();
            try
            {
                
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select *, ME009 from INVMM mm
left join INVME  on MM001 = ME001 and MM004 = ME002
where 1 = 1 ");
                stringBuilder.Append(" and MM002 ='" + warehouse + "' ");
                if(lot != "")
                  stringBuilder.Append(" and MM004  like '%" + lot + "%' ");
                if(material !="")
                  stringBuilder.Append(" and MM001  like '%" + material + "%' ");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                DataTable dt = new DataTable();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                //datas = (from DataRow dr in dt.Rows
                //         select new dataWarehouse()
                //         {
                //             checkbox = false,
                //             warehouse_MM002 = dr["MM002"].ToString(),
                //             location_MM003 = dr["MM003"].ToString(),
                //             maSP_MM001 = dr["MM001"].ToString(),
                //             Lot_MM004 = dr["MM004"].ToString(),
                //             Soluong_MM005 = double.Parse(dr["MM005"].ToString().Trim()),

                //             ExpiryDate = (dr["ME009"].ToString() != "") ? DateTime.ParseExact(dr["ME009"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture) : DateTime.MinValue,

                //         }).ToList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dataWarehouse data = new dataWarehouse();
                    data.checkbox = false;
                    data.warehouse_MM002 = dt.Rows[i]["MM002"].ToString();
                    data.location_MM003 = dt.Rows[i]["MM003"].ToString();
                    data.maSP_MM001 = dt.Rows[i]["MM001"].ToString();
                    data.Lot_MM004 = dt.Rows[i]["MM004"].ToString();
                    data.Soluong_MM005 = double.Parse(dt.Rows[i]["MM005"].ToString().Trim());
                    data.ExpiryDate = (dt.Rows[i]["ME009"].ToString() != "") ? DateTime.ParseExact(dt.Rows[i]["ME009"].ToString(), "yyyyMMdd", CultureInfo.InvariantCulture) : DateTime.MaxValue;
                    if (data.ExpiryDate == DateTime.MinValue || data.ExpiryDate >= datetime)
                    {
                        if (data.Soluong_MM005 > 0)
                            datas.Add(data);
                    }

                }
                datasSortExpiryDate = datas.OrderBy(d => d.ExpiryDate).ToList();

            }
            catch (Exception)
            {

                throw;
            }
            return datasSortExpiryDate;
        }
        public bool DoingUpdateDBFormaterialArrangement(string dept ,List<dataWarehouse> datas, DateTime CreateDate)
        {
            try
            {

                DataTable dtINVTA = GetDataTableTop1INVTA();
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);

                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                int STT = 1;
                string keyIndex = "0";
                keyIndex = GetMaxIndexTA002(CreateDate);
                foreach (var data in datas)
                {
                  
                    DataTable dtINVTB = GetDataTableTop1INVTB(data.maSP_MM001);
                    DataTable dtINVLA = GetTop1DataForInsertINVLA();
                    DataTable dtINVLF = GetDataTableTop1INVLF();
                    DataTable dtINVMF = GetDataTableTop1INVMF();
                    InsertINVTB(keyIndex, STT, -1, CreateDate, data, dtINVTB, dataADMMF);
                    InsertINVLA("1103", keyIndex, STT.ToString("0000"), CreateDate, data, dtINVLA, -1);
                    InsertINVLF("1103", keyIndex, STT.ToString("0000"), CreateDate, data, dtINVLF, -1);
                    InsertINVMF("1103", keyIndex, STT.ToString("0000"), CreateDate, data, dtINVMF, -1);
                    UpdateorInsertINVMC(data, -1);
                    UpdateorInsertINVMM(data, -1);
                    STT = STT + 1;


                    InsertINVTB(keyIndex, STT, 1, CreateDate, data, dtINVTB, dataADMMF);
                    InsertINVLA("1103", keyIndex, STT.ToString("0000"), CreateDate, data, dtINVLA, 1);
                    InsertINVLF("1103", keyIndex, STT.ToString("0000"), CreateDate, data, dtINVLF, 1);
                    InsertINVMF("1103", keyIndex, STT.ToString("0000"), CreateDate, data, dtINVMF, 1);
                    UpdateorInsertINVMC(data, 1);
                    UpdateorInsertINVMM(data, 1);

                    STT = STT +1;
                }
               InsertINVTA(dept,keyIndex, CreateDate,dtINVTA,  dataADMMF);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "DoingUpdateDBFormaterialArrangement(List<dataWarehouse> datas, DateTime CreateDate)", ex.Message);
            }


            return true;
        }
        public DataTable GetDataTableTop1INVTB(string maSP)
        {
            string sqlQuery = "select top(1) * from INVTB where  TB004 = '"+maSP + "'";
            DataTable dt = new DataTable();
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuery, ref dt);
            return dt;
        }
        public DataTable GetDataTableTop1INVTA()
        {
            string sqlQuery = "select top(1) * from INVTA ";
            DataTable dt = new DataTable();
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuery, ref dt);
            return dt;
        }
        public DataTable GetDataTableTop1INVLF()
        {
            string sqlQuery = "select top(1) * from INVLF ";
            DataTable dt = new DataTable();
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuery, ref dt);
            return dt;
        }
        public DataTable GetDataTableTop1INVMF()
        {
            string sqlQuery = "select top(1) * from INVMF ";
            DataTable dt = new DataTable();
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuery, ref dt);
            return dt;
        }
        public DataTable GetDataTableINVME(string Masp, string lot)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select * from INVME where 1=1 ");
            stringBuilder.Append(" and ME001 = '" + Masp + "' ");
            stringBuilder.Append(" and ME002 = '" + lot + "' ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public string GetMaxIndexTA002(DateTime CreateDate)
        {
            string _TA002 = "";
            string dateFormat = CreateDate.ToString("yyMM");
            string countFormatReset = "0001";

            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            var strData = sqlTLVN2.sqlExecuteScalarString("SELECT MAX(TA002)+1 from INVTA where TA001 ='1103' and TA002 like '" + dateFormat + "%'");
            if (strData == "" || strData == String.Empty || strData == null)
                _TA002 = dateFormat + countFormatReset;
            else _TA002 = strData;

            return _TA002;
        }
        public bool InsertINVTB(string keyIndex,int STT, int inoutIndex,DateTime CreateDate,dataWarehouse data, DataTable dtINVTB, DataTable dataADMMF)
        {
            try
            {

                DataTable dtINVME = GetDataTableINVME(data.maSP_MM001, data.Lot_MM004);
                StringBuilder stringBuilder = new StringBuilder();

                StringBuilder stringFun = new StringBuilder();
                stringBuilder.Append("insert into INVTB ( ");
                for (int i = 0; i < dtINVTB.Columns.Count; i++)
                {
                    if (i < dtINVTB.Columns.Count - 1)
                        stringBuilder.Append(dtINVTB.Columns[i].ColumnName + ",");
                    else stringBuilder.Append(dtINVTB.Columns[i].ColumnName + ") values ( ");

                }
                for (int j = 0; j < dtINVTB.Columns.Count; j++)
                {
                    string valueCell = "";
                    if (dtINVTB.Columns[j].ColumnName == "COMPANY")
                    {
                        valueCell = "TLVN2";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "CREATOR")
                    {
                        valueCell = Class.valiballecommon.GetStorage().UserName;
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "USR_GROUP")
                    {
                        if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                            valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "CREATE_DATE")
                    {
                        valueCell = DateTime.Now.ToString("yyyyMMdd");
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "CREATE_TIME")
                    {
                        valueCell = DateTime.Now.ToString("HH:mm:ss");
                    }

                    else if (dtINVTB.Columns[j].ColumnName == "CREATE_AP")
                    {
                        valueCell = Class.valiballecommon.GetStorage().PCName;
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "CREATE_PRID")
                    {
                        valueCell = "INVMI05";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "FLAG")
                    {
                        valueCell = "1";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "MODI_DATE")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "MODI_TIME")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "MODIFIER")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "MODI_AP")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "MODI_PRID")
                    {
                        valueCell = "NULL";
                    }
                    //TB001, TB002 
                    else if (dtINVTB.Columns[j].ColumnName == "TB001")
                    {
                        valueCell = "1103";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB002")
                    {
                        valueCell = keyIndex.ToString();
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB003")
                    {
                        valueCell = STT.ToString("0000");
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB004")
                    {
                        valueCell = dtINVTB.Rows[0]["TB004"].ToString();
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB005")
                    {
                        valueCell = dtINVTB.Rows[0]["TB005"].ToString();
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB006")
                    {
                        valueCell = dtINVTB.Rows[0]["TB006"].ToString();
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB007")
                    {
                        valueCell = (data.Soluong_Transfer * inoutIndex).ToString();
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB008")
                    {
                        valueCell = dtINVTB.Rows[0]["TB008"].ToString();//Donvi
                    }
                    //else if (dtINVTB.Columns[j].ColumnName == "TB009")
                    //{
                    //    valueCell = "0";//SL ton kho
                    //}
                    else if (dtINVTB.Columns[j].ColumnName == "TB010")
                    {
                        valueCell = "0";//SL gia von don vi
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB011")
                    {
                        valueCell = "0";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB012")
                    {
                        valueCell = data.warehouse_MM002;
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB013")
                    {
                        valueCell = "";

                    }

                    else if (dtINVTB.Columns[j].ColumnName == "TB014")
                    {
                        valueCell = data.Lot_MM004;
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB015")
                    {if (dtINVME.Rows.Count > 0)
                        {
                            if (dtINVME.Rows[0]["ME009"] != null)
                                valueCell = dtINVME.Rows[0]["ME009"].ToString(); //ngay het han
                            else valueCell = "";
                        }
                    else valueCell = "";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB016")
                    {
                        if (dtINVME.Rows.Count > 0)
                            valueCell = dtINVME.Rows[0]["ME010"].ToString();
                        else valueCell = "";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB018")
                    {
                        valueCell = "Y";
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB019")
                    {
                        valueCell = CreateDate.ToString("yyyyMMdd");
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB026")
                    {
                        if (inoutIndex == -1)
                            valueCell = data.location_MM003;
                        else if (inoutIndex == 1)
                            valueCell = data.location_Transfer;
                    }
                    else if (dtINVTB.Columns[j].ColumnName == "TB200")
                    {
                        valueCell = "";
                    }
                    else valueCell = dtINVTB.Rows[0][dtINVTB.Columns[j].ColumnName].ToString();

                    if (j < dtINVTB.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                    else stringFun.Append("'" + valueCell + "')");
                }

                    string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                    SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                  return  sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);


                
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, ex.Source, ex.Message);
            }
            return false;
        }

        public bool InsertINVTA(string dept,string keyindex,DateTime CreateDate, DataTable dtINVTA, DataTable dataADMMF)
        {
            try
            {
                DataTable dataCMSMQ = GetdataCMSMQ("1103");
                StringBuilder stringBuilder = new StringBuilder();

                StringBuilder stringFun = new StringBuilder();
                stringBuilder.Append("insert into INVTA ( ");
                for (int i = 0; i < dtINVTA.Columns.Count; i++)
                {
          
                    if (i < dtINVTA.Columns.Count - 2)
                    {
                       
                        stringBuilder.Append(dtINVTA.Columns[i].ColumnName + ",");
                    }
                    else if (i == dtINVTA.Columns.Count - 2)
                    stringBuilder.Append(dtINVTA.Columns[i].ColumnName + ") values ( ");

                }
                for (int j = 0; j < dtINVTA.Columns.Count; j++)
                {
                    string valueCell = "";
                    if (dtINVTA.Columns[j].ColumnName == "COMPANY")
                    {
                        valueCell = "TLVN2";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "CREATOR")
                    {
                        valueCell = Class.valiballecommon.GetStorage().UserName;
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "USR_GROUP")
                    {
                        if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                            valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "CREATE_DATE")
                    {
                        valueCell = DateTime.Now.ToString("yyyyMMdd");
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "CREATE_TIME")
                    {
                        valueCell = DateTime.Now.ToString("HH:mm:ss");
                    }

                    else if (dtINVTA.Columns[j].ColumnName == "CREATE_AP")
                    {
                        valueCell = Class.valiballecommon.GetStorage().PCName;
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "CREATE_PRID")
                    {
                        valueCell = "INVMI05";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "FLAG")
                    {
                        valueCell = "1";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "MODI_DATE")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "MODI_TIME")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "MODIFIER")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "MODI_AP")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "MODI_PRID")
                    {
                        valueCell = "NULL";
                    }
                    //TB001, TB002 
                    else if (dtINVTA.Columns[j].ColumnName == "TA001")
                    {
                        valueCell = "1103";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA002")
                    {
                        valueCell = keyindex.ToString();
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA003")
                    {
                        valueCell = CreateDate.ToString("yyyyMMdd");
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA004")
                    {
                        valueCell = dept; //Ma bo phan, can hoi chi Dieu
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA005")
                    {
                        valueCell = ""; //Ghi chu
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA006")
                    {
                        valueCell = "Y";//Ma xac nhan
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA007")
                    {
                        valueCell = "0";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA008")
                    {
                        valueCell = "TL"; //ma xuong
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA009")
                    {
                        valueCell = dataCMSMQ.Rows[0]["MQ003"].ToString();// ma tinh chat CT hoi chi Dieu
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA010")
                    {
                        valueCell = "0";// ma tinh chat CT
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA011")
                    {
                        valueCell = GetSumValueINVTB("TB007", "1103", keyindex).ToString(); // tong so luong
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA012")
                    {
                        valueCell = GetSumValueINVTB("TB011", "1103", keyindex).ToString(); ;// tong so tien
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA013")
                    {
                        valueCell = "N";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA014")
                    {
                        valueCell = CreateDate.ToString("yyyyMMdd");
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA015")
                    {
                        valueCell = Class.valiballecommon.GetStorage().UserCode;
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA016")
                    {
                        valueCell = "0";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA017")
                    {
                        valueCell = "N";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA018")
                    {
                        valueCell = "0";
                    }
                    else if (dtINVTA.Columns[j].ColumnName == "TA019")
                    {
                        valueCell = "0";
                    }
                    else valueCell = dtINVTA.Rows[0][dtINVTA.Columns[j].ColumnName].ToString();

                    if (j < dtINVTA.Columns.Count - 2) stringFun.Append(" '" + valueCell + "',");
                    else if(j == dtINVTA.Columns.Count - 2) stringFun.Append("'" + valueCell + "')");
                }

                    string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                    SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                    return sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);
                
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, ex.Source, ex.Message);
            }
            return false;
        }
        public bool InsertINVLA(string code, string No, string STT, DateTime CreateDate,dataWarehouse data,DataTable dtINVLA, int intInOut)
        {
            try
            {
                DataTable dataINVTB = GetDataTableINVTB(code, No, STT);
                DataTable dataCMSMQ = GetdataCMSMQ(code);
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringFun = new StringBuilder();
                stringBuilder.Append("insert into INVLA ( ");
                for (int i = 0; i < dtINVLA.Columns.Count; i++)
                {
                    if (i < dtINVLA.Columns.Count - 1)
                    {

                        stringBuilder.Append(dtINVLA.Columns[i].ColumnName + ",");
                    }
                    else stringBuilder.Append(dtINVLA.Columns[i].ColumnName + ") values ( ");
                }

                for (int j = 0; j < dtINVLA.Columns.Count; j++)
                {
                    string valueCell = "";

                    if (dtINVLA.Columns[j].ColumnName == "COMPANY")
                    {
                        valueCell = "TLVN2";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "CREATOR")
                    {
                        valueCell = Class.valiballecommon.GetStorage().UserName;
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "USR_GROUP")
                    {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                        if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                            valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "CREATE_DATE")
                    {
                        valueCell = DateTime.Now.ToString("yyyyMMdd");
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "CREATE_TIME")
                    {
                        valueCell = DateTime.Now.ToString("HH:mm:ss");
                    }

                    else if (dtINVLA.Columns[j].ColumnName == "CREATE_AP")
                    {
                        valueCell = Class.valiballecommon.GetStorage().PCName;
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "CREATE_PRID")
                    {
                        valueCell = "INVMI05";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "FLAG")
                    {
                        valueCell = "1";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "MODI_DATE")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "MODI_TIME")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "MODIFIER")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "MODI_AP")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "MODI_PRID")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA001")
                    {
                        valueCell = data.maSP_MM001;
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA004")
                    {
                        valueCell = CreateDate.ToString("yyyyMMdd");
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA005")
                    {
                        valueCell = "1";
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA006")
                    {
                        valueCell = code;
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA007")
                    {
                        valueCell = No;
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA008")
                    {
                        valueCell = STT;
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA009")
                    {
                            valueCell = data.warehouse_MM002;
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA010")
                    {
                        valueCell = dataINVTB.Rows[0]["TB017"].ToString();//TB017
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA011")
                    {
                       
                        valueCell = (data.Soluong_Transfer*intInOut).ToString();
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA012")
                    {

                        valueCell = "0"; //gt DV CT (hoi chi Dieu)
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA013")
                    {

                        valueCell = "0"; //ST (hoi chi Dieu)
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA014")
                    {
                        valueCell = dataCMSMQ.Rows[0]["MQ008"].ToString();
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA015")
                    {
                        valueCell = dataCMSMQ.Rows[0]["MQ011"].ToString();
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA016")
                    {
                        valueCell = data.Lot_MM004;
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA017")
                    {
                        valueCell ="0" ;//So Tien NVL - Hoi chi Dieu
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA018")
                    {
                        valueCell = "0";//So Tien Nhan cong - Hoi chi Dieu
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA021")
                    {
                        valueCell = dataINVTB.Rows[0]["TB022"].ToString();
                    }
                    else if (dtINVLA.Columns[j].ColumnName == "LA022")
                    {
                        if (intInOut == -1)
                            valueCell = data.location_MM003 ;
                        else if (intInOut == 1)
                            valueCell = data.location_Transfer;
                    }
                    else valueCell = dtINVLA.Rows[0][dtINVLA.Columns[j].ColumnName].ToString();

                    if (j < dtINVLA.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                    else stringFun.Append("'" + valueCell + "')");

                }
                string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                return sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);

            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertINVLA(INVTATB iNVTATB, DataTable dtINVLA, int intInOut)", ex.Message);
                return false;
            }
        }
        public bool InsertINVLF(string code, string No, string STT,DateTime CreateDate,dataWarehouse data ,DataTable dtINVLF, int intInOut)
        {
            try
            {
                DataTable dataINVTB = GetDataTableINVTB(code, No, STT);
                DataTable dataCMSMQ = GetdataCMSMQ(code);
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringFun = new StringBuilder();
                stringBuilder.Append("insert into INVLF ( ");
                for (int i = 0; i < dtINVLF.Columns.Count; i++)
                {
                    if (i < dtINVLF.Columns.Count - 1)
                    {

                        stringBuilder.Append(dtINVLF.Columns[i].ColumnName + ",");
                    }
                    else stringBuilder.Append(dtINVLF.Columns[i].ColumnName + ") values ( ");
                }

                for (int j = 0; j < dtINVLF.Columns.Count; j++)
                {
                    string valueCell = "";

                    if (dtINVLF.Columns[j].ColumnName == "COMPANY")
                    {
                        valueCell = "TLVN2";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "CREATOR")
                    {
                        valueCell = Class.valiballecommon.GetStorage().UserName;
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "USR_GROUP")
                    {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                        if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                            valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "CREATE_DATE")
                    {
                        valueCell = DateTime.Now.ToString("yyyyMMdd");
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "CREATE_TIME")
                    {
                        valueCell = DateTime.Now.ToString("HH:mm:ss");
                    }

                    else if (dtINVLF.Columns[j].ColumnName == "CREATE_AP")
                    {
                        valueCell = Class.valiballecommon.GetStorage().PCName;
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "CREATE_PRID")
                    {
                        valueCell = "INVMI05";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "FLAG")
                    {
                        valueCell = "1";
                    }

                    else if (dtINVLF.Columns[j].ColumnName == "MODI_DATE")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "MODI_TIME")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "MODIFIER")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "MODI_AP")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "MODI_PRID")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF001")
                    {
                        valueCell = code;
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF002")
                    {
                        valueCell = No;
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF003")
                    {
                        valueCell = STT;
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF004")
                    {
                        valueCell = data.maSP_MM001;
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF005")
                    {
                        
                            valueCell = data.warehouse_MM002;
                     
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF006")
                    {
                        if (intInOut == -1)
                        {
                            if (data.location_MM003 == "")
                            {
                                valueCell = "##########";
                            }
                            else
                            {
                                valueCell = data.location_MM003;
                            }
                        }

                        else if (intInOut == 1)
                        {
                            if (data.location_Transfer == "")
                            {
                                valueCell = "##########";
                            }
                            else
                            {
                                valueCell = data.location_Transfer;
                            }
                        }
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF007")
                    {
                        valueCell = data.Lot_MM004;
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF008")
                    {
                        valueCell = "1";
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF009")
                    {

                        valueCell = CreateDate.ToString("yyyyMMdd");

                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF010")
                    {
                        valueCell = dataCMSMQ.Rows[0]["MQ008"].ToString();
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF011")
                    {
                        valueCell =(data.Soluong_Transfer*intInOut).ToString();
                    }
                    else if (dtINVLF.Columns[j].ColumnName == "LF013")
                    {
                        valueCell = dataINVTB.Rows[0]["TB017"].ToString();//TB017
                    }
                    else valueCell = dtINVLF.Rows[0][dtINVLF.Columns[j].ColumnName].ToString();

                    if (j < dtINVLF.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                    else stringFun.Append("'" + valueCell + "')");
                }

                string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                return sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, ex.Source, ex.Message);
                return false;
            }
        }
        public bool InsertINVMF(string code, string No, string STT,DateTime Createdate,dataWarehouse data, DataTable dtINVMF, int intInOut)
        {
            try
            {
                DataTable dataINVTB = GetDataTableINVTB(code, No,STT);
                DataTable dataCMSMQ = GetdataCMSMQ(code);
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringFun = new StringBuilder();
                stringBuilder.Append("insert into INVMF ( ");
                for (int i = 0; i < dtINVMF.Columns.Count; i++)
                {
                    if (i < dtINVMF.Columns.Count - 1)
                    {

                        stringBuilder.Append(dtINVMF.Columns[i].ColumnName + ",");
                    }
                    else stringBuilder.Append(dtINVMF.Columns[i].ColumnName + ") values ( ");
                }

                for (int j = 0; j < dtINVMF.Columns.Count; j++)
                {
                    string valueCell = "";

                    if (dtINVMF.Columns[j].ColumnName == "COMPANY")
                    {
                        valueCell = "TLVN2";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "CREATOR")
                    {
                        valueCell = Class.valiballecommon.GetStorage().UserName;
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "USR_GROUP")
                    {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                        if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                            valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "CREATE_DATE")
                    {
                        valueCell = DateTime.Now.ToString("yyyyMMdd");
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "CREATE_TIME")
                    {
                        valueCell = DateTime.Now.ToString("HH:mm:ss");
                    }

                    else if (dtINVMF.Columns[j].ColumnName == "CREATE_AP")
                    {
                        valueCell = Class.valiballecommon.GetStorage().PCName;
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "CREATE_PRID")
                    {
                        valueCell = "INVMI05";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "FLAG")
                    {
                        valueCell = "1";
                    }

                    else if (dtINVMF.Columns[j].ColumnName == "MODI_DATE")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MODI_TIME")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MODIFIER")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MODI_AP")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MODI_PRID")
                    {
                        valueCell = "NULL";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF001")
                    {
                        valueCell = data.maSP_MM001;
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF002")
                    {
                        valueCell = data.Lot_MM004;
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF003")
                    {
                        valueCell = Createdate.ToString("yyyyMMdd");
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF004")
                    {
                        valueCell = code;
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF005")
                    {
                        valueCell = No;
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF006")
                    {
                        valueCell = STT;
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF007")
                    {
                        
                            valueCell = data.warehouse_MM002;
                       
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF008")
                    {
                        valueCell = "1";
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF009")
                    {
                        valueCell = dataCMSMQ.Rows[0]["MQ008"].ToString();
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF010")
                    {
                        valueCell = (data.Soluong_Transfer*intInOut).ToString();
                    }
                    else if (dtINVMF.Columns[j].ColumnName == "MF013")
                    {
                        valueCell = dataINVTB.Rows[0]["TB017"].ToString();//TB017
                    }
                    else valueCell = dtINVMF.Rows[0][dtINVMF.Columns[j].ColumnName].ToString();

                    if (j < dtINVMF.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                    else stringFun.Append("'" + valueCell + "')");

                }
                string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                return sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, ex.Source, ex.Message);
                return false;
            }
        }
        public bool UpdateorInsertINVMC(dataWarehouse data, int InOutIndex)
        {
            try
            {
                DataTable dataINVMC = GetDataINVMC(data.maSP_MM001, data.warehouse_MM002);
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                if (InOutIndex == -1)
                {
                    //   DataTable dataINVMC = GetDataINVMC(nVTATB.TB004_SP, nVTATB.TB012_KhoChuyen);
                    if (dataINVMC.Rows.Count > 0)
                    {
                        //Update row 
                        StringBuilder strKhoChuyen = new StringBuilder();
                        strKhoChuyen.Append(" update INVMC ");
                        strKhoChuyen.Append(" set MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                        strKhoChuyen.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                        strKhoChuyen.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                        strKhoChuyen.Append(" MODI_PRID = '" + "INVMI05" + "' ,");
                        strKhoChuyen.Append(" FLAG = FLAG+1 ,");
                        strKhoChuyen.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                        strKhoChuyen.Append(" MC007 = MC007 - " + data.Soluong_Transfer + " , ");
                        strKhoChuyen.Append(" MC013 = '" + DateTime.Now.ToString("yyyyMMdd") + "' ");
                        strKhoChuyen.Append(" where 1=1 ");
                        strKhoChuyen.Append(" and MC001 ='" + data.maSP_MM001 + "'");
                        strKhoChuyen.Append(" and MC002 ='" + data.warehouse_MM002 + "'");
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(strKhoChuyen.ToString(), false);
                    }
                    else
                    {
                        // Insert new row
                        dataINVMC = GetDataINVMCTop1();
                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringFun = new StringBuilder();
                        stringBuilder.Append("insert into INVMC ( ");
                        for (int i = 0; i < dataINVMC.Columns.Count; i++)
                        {
                            if (i < dataINVMC.Columns.Count - 1)
                            {

                                stringBuilder.Append(dataINVMC.Columns[i].ColumnName + ",");
                            }
                            else stringBuilder.Append(dataINVMC.Columns[i].ColumnName + ") values ( ");
                        }

                        for (int j = 0; j < dataINVMC.Columns.Count; j++)
                        {
                            string valueCell = "";

                            if (dataINVMC.Columns[j].ColumnName == "COMPANY")
                            {
                                valueCell = "TLVN2";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATOR")
                            {
                                valueCell = Class.valiballecommon.GetStorage().UserName;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "USR_GROUP")
                            {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                                if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                                    valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "FLAG")
                            {
                                valueCell = "1";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_DATE")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_TIME")
                            {
                                valueCell = DateTime.Now.ToString("HH:mm:ss");
                            }

                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_AP")
                            {
                                valueCell = Class.valiballecommon.GetStorage().PCName;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_PRID")
                            {
                                valueCell = "INVMI08";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_DATE")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_TIME")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODIFIER")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_AP")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_PRID")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC001")
                            {
                                valueCell = data.maSP_MM001;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC002")
                            {
                                valueCell = data.warehouse_MM002;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC003")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC004")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC005")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC006")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC007")
                            {
                                valueCell = (-data.Soluong_Transfer).ToString();
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC008")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC009")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC010")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC011")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC012")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC013")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC014")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC015")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC016")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC017")
                            {
                                valueCell = "0";
                            }

                            else valueCell = dataINVMC.Rows[0][dataINVMC.Columns[j].ColumnName].ToString();

                            if (j < dataINVMC.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                            else stringFun.Append("'" + valueCell + "')");
                        }

                        string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);

                    }
                }
                if (InOutIndex == 1)
                {

                    DataTable dataINVMCKhoNhan = GetDataINVMC(data.maSP_MM001, data.warehouse_MM002);
                    if (dataINVMCKhoNhan.Rows.Count > 0)
                    {
                        //Update row 
                        StringBuilder strKhoChuyen = new StringBuilder();
                        strKhoChuyen.Append(" update INVMC ");
                        strKhoChuyen.Append(" set MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                        strKhoChuyen.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                        strKhoChuyen.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                        strKhoChuyen.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                        strKhoChuyen.Append(" MODI_PRID = '" + "INVMI05" + "' ,");
                        strKhoChuyen.Append(" FLAG = FLAG+1 ,");
                        strKhoChuyen.Append(" MC007 = MC007 + " + data.Soluong_Transfer + " , ");
                        strKhoChuyen.Append(" MC013 = '" + DateTime.Now.ToString("yyyyMMdd") + "' ");
                        strKhoChuyen.Append(" where 1=1 ");
                        strKhoChuyen.Append(" and MC001 ='" + data.maSP_MM001 + "'");
                        strKhoChuyen.Append(" and MC002 ='" + data.warehouse_MM002 + "'");
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(strKhoChuyen.ToString(), false);
                    }
                    else
                    {
                        // Insert new row

                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringFun = new StringBuilder();
                        stringBuilder.Append("insert into INVMC ( ");
                        for (int i = 0; i < dataINVMC.Columns.Count; i++)
                        {
                            if (i < dataINVMC.Columns.Count - 1)
                            {

                                stringBuilder.Append(dataINVMC.Columns[i].ColumnName + ",");
                            }
                            else stringBuilder.Append(dataINVMC.Columns[i].ColumnName + ") values ( ");
                        }

                        for (int j = 0; j < dataINVMC.Columns.Count; j++)
                        {
                            string valueCell = "";

                            if (dataINVMC.Columns[j].ColumnName == "COMPANY")
                            {
                                valueCell = "TLVN2";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATOR")
                            {
                                valueCell = Class.valiballecommon.GetStorage().UserName;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "USR_GROUP")
                            {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                                if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                                    valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "FLAG")
                            {
                                valueCell = "1";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_DATE")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_TIME")
                            {
                                valueCell = DateTime.Now.ToString("HH:mm:ss");
                            }

                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_AP")
                            {
                                valueCell = Class.valiballecommon.GetStorage().PCName;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "CREATE_PRID")
                            {
                                valueCell = "INVMI08";
                            }

                            else if (dataINVMC.Columns[j].ColumnName == "MODI_DATE")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_TIME")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODIFIER")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_AP")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MODI_PRID")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC001")
                            {
                                valueCell = data.maSP_MM001;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC002")
                            {
                                valueCell = data.warehouse_MM002;
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC003")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC004")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC005")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC006")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC007")
                            {
                                valueCell = data.Soluong_Transfer.ToString();
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC008")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC009")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC010")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC011")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC012")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC013")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC014")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC015")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC016")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMC.Columns[j].ColumnName == "MC017")
                            {
                                valueCell = "0";
                            }

                            else valueCell = dataINVMC.Rows[0][dataINVMC.Columns[j].ColumnName].ToString();

                            if (j < dataINVMC.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                            else stringFun.Append("'" + valueCell + "')");
                        }

                        string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                       sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);
                    }
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, ex.Source, ex.Message);
                return false;
            }
            return true;
        }
        public bool UpdateorInsertINVMM(dataWarehouse data, int InOutIndex)
        {
            try
            {
                DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                DataTable dataINVMM = GetDataINVMM(data.maSP_MM001, data.warehouse_MM002, data.location_MM003, data.Lot_MM004);
                if (InOutIndex == -1)
                {
                    if (dataINVMM.Rows.Count > 0)
                    {
                        //Update row 
                        StringBuilder strKhoChuyen = new StringBuilder();
                        strKhoChuyen.Append(" update INVMM ");
                        strKhoChuyen.Append(" set MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                        strKhoChuyen.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                        strKhoChuyen.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                        strKhoChuyen.Append(" MODI_PRID = '" + "INVMI05" + "' ,");
                        strKhoChuyen.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                        strKhoChuyen.Append(" FLAG = FLAG+1 ,");
                        strKhoChuyen.Append(" MM005 = MM005 - " + data.Soluong_Transfer + " , ");
                        strKhoChuyen.Append(" MM009 = '" + DateTime.Now.ToString("yyyyMMdd") + "' ");
                        strKhoChuyen.Append(" where 1=1 ");
                        strKhoChuyen.Append(" and MM001 = '" + data.maSP_MM001 + "'");
                        strKhoChuyen.Append(" and MM002 ='" + data.warehouse_MM002 + "'");
                        if (data.location_MM003 == "")
                            strKhoChuyen.Append(" and MM003 ='" + "##########" + "'");
                        else
                            strKhoChuyen.Append(" and MM003 ='" + data.location_MM003 + "'");
                        strKhoChuyen.Append(" and MM004 ='" +data.Lot_MM004 + "'");
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(strKhoChuyen.ToString(), false);
                    }
                    else
                    {
                        // Insert new row
                        dataINVMM = GetDataINVMMTop1();
                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringFun = new StringBuilder();
                        stringBuilder.Append("insert into INVMM ( ");
                        for (int i = 0; i < dataINVMM.Columns.Count; i++)
                        {
                            if (i < dataINVMM.Columns.Count - 1)
                            {

                                stringBuilder.Append(dataINVMM.Columns[i].ColumnName + ",");
                            }
                            else stringBuilder.Append(dataINVMM.Columns[i].ColumnName + ") values ( ");
                        }

                        for (int j = 0; j < dataINVMM.Columns.Count; j++)
                        {
                            string valueCell = "";

                            if (dataINVMM.Columns[j].ColumnName == "COMPANY")
                            {
                                valueCell = "TLVN2";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "FLAG")
                            {
                                valueCell = "1";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATOR")
                            {
                                valueCell = Class.valiballecommon.GetStorage().UserName;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "USR_GROUP")
                            {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                                if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                                    valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_DATE")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_TIME")
                            {
                                valueCell = DateTime.Now.ToString("HH:mm:ss");
                            }


                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_AP")
                            {
                                valueCell = Class.valiballecommon.GetStorage().PCName;
                            }

                            else if (dataINVMM.Columns[j].ColumnName == "MODI_DATE")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_TIME")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODIFIER")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_AP")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_PRID")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_PRID")
                            {
                                valueCell = "INVMI08";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM001")
                            {
                                valueCell = data.maSP_MM001;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM002")
                            {
                                valueCell = data.warehouse_MM002;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM003")
                            {
                                if (data.location_MM003 == "")
                                {
                                    valueCell = "##########";
                                }

                                else
                                {
                                    valueCell = data.location_MM003;
                                }
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM004")
                            {
                                valueCell = data.Lot_MM004;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM005")
                            {
                                valueCell = (data.Soluong_Transfer*InOutIndex).ToString();
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM006")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM007")
                            {
                                valueCell = "";
                            }
                            //else if (dataINVMM.Columns[j].ColumnName == "MM008")
                            //{
                            //    valueCell = DateTime.Now.ToString("yyyyMMdd");
                            //}
                            else if (dataINVMM.Columns[j].ColumnName == "MM009")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM010")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM011")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM012")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM013")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM014")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM015")
                            {
                                valueCell = "";
                            }


                            else valueCell = dataINVMM.Rows[0][dataINVMM.Columns[j].ColumnName].ToString();

                            if (j < dataINVMM.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                            else stringFun.Append("'" + valueCell + "')");
                        }

                        string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);

                    }
                }
                if (InOutIndex == 1)
                {
                    DataTable dataINVMMKhoNhan = GetDataINVMM(data.maSP_MM001, data.warehouse_MM002, data.location_Transfer, data.Lot_MM004);
                    if (dataINVMMKhoNhan.Rows.Count > 0)
                    {
                        //Update row 
                        //Update row 
                        StringBuilder strKhoChuyen = new StringBuilder();
                        strKhoChuyen.Append(" update INVMM ");
                        strKhoChuyen.Append(" set MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                        strKhoChuyen.Append("  MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                        strKhoChuyen.Append(" MODI_AP = '" + Class.valiballecommon.GetStorage().PCName + "' ,");
                        strKhoChuyen.Append(" MODI_PRID = '" + "INVMI05" + "' ,");
                        strKhoChuyen.Append(" FLAG = FLAG+1 ,");
                        strKhoChuyen.Append(" MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "', ");
                        strKhoChuyen.Append(" MM005 = MM005 + " + data.Soluong_Transfer + " , ");
                        strKhoChuyen.Append(" MM008 = '" + DateTime.Now.ToString("yyyyMMdd") + "' ");
                        strKhoChuyen.Append(" where 1=1 ");
                        strKhoChuyen.Append(" and MM001 = '" + data.maSP_MM001 + "'");
                        strKhoChuyen.Append(" and MM002 ='" + data.warehouse_MM002 + "'");
                        if (data.location_Transfer == "")
                            strKhoChuyen.Append(" and MM003 ='" + "##########" + "'");
                        else
                            strKhoChuyen.Append(" and MM003 ='" + data.location_Transfer + "'");

                        strKhoChuyen.Append(" and MM004 ='" + data.Lot_MM004 + "'");
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(strKhoChuyen.ToString(), false);
                    }
                    else
                    {
                        // Insert new row

                        StringBuilder stringBuilder = new StringBuilder();
                        StringBuilder stringFun = new StringBuilder();
                        stringBuilder.Append("insert into INVMM ( ");
                        for (int i = 0; i < dataINVMM.Columns.Count; i++)
                        {
                            if (i < dataINVMM.Columns.Count - 1)
                            {

                                stringBuilder.Append(dataINVMM.Columns[i].ColumnName + ",");
                            }
                            else stringBuilder.Append(dataINVMM.Columns[i].ColumnName + ") values ( ");
                        }

                        for (int j = 0; j < dataINVMM.Columns.Count; j++)
                        {
                            string valueCell = "";

                            if (dataINVMM.Columns[j].ColumnName == "COMPANY")
                            {
                                valueCell = "TLVN2";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "FLAG")
                            {
                                valueCell = "1";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATOR")
                            {
                                valueCell = Class.valiballecommon.GetStorage().UserName;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "USR_GROUP")
                            {// DataTable dataADMMF = GetDataTableADMMF(Class.valiballecommon.GetStorage().UserName);
                                if (dataADMMF != null && dataADMMF.Rows.Count == 1)
                                    valueCell = dataADMMF.Rows[0]["MF004"].ToString();
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_DATE")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_TIME")
                            {
                                valueCell = DateTime.Now.ToString("HH:mm:ss");
                            }

                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_AP")
                            {
                                valueCell = Class.valiballecommon.GetStorage().PCName;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "CREATE_PRID")
                            {
                                valueCell = "INVMI08";
                            }

                            else if (dataINVMM.Columns[j].ColumnName == "MODI_DATE")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_TIME")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODIFIER")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_AP")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MODI_PRID")
                            {
                                valueCell = "NULL";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM001")
                            {
                                valueCell = data.maSP_MM001;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM002")
                            {
                                valueCell = data.warehouse_MM002;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM003")
                            {
                                if (data.location_Transfer == "")
                                {
                                    valueCell = "##########";
                                }

                                else
                                {
                                    valueCell = data.location_Transfer;
                                }
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM004")
                            {
                                valueCell = data.Lot_MM004;
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM005")
                            {
                                valueCell = (data.Soluong_Transfer*InOutIndex).ToString();
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM006")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM007")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM008")
                            {
                                valueCell = DateTime.Now.ToString("yyyyMMdd");
                            }
                            //else if (dataINVMM.Columns[j].ColumnName == "MM009")
                            //{
                            //    valueCell = "";
                            //}
                            else if (dataINVMM.Columns[j].ColumnName == "MM010")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM011")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM012")
                            {
                                valueCell = "";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM013")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM014")
                            {
                                valueCell = "0";
                            }
                            else if (dataINVMM.Columns[j].ColumnName == "MM015")
                            {
                                valueCell = "";
                            }


                            else valueCell = dataINVMM.Rows[0][dataINVMM.Columns[j].ColumnName].ToString();

                            if (j < dataINVMM.Columns.Count - 1) stringFun.Append(" '" + valueCell + "',");
                            else stringFun.Append("'" + valueCell + "')");
                        }

                        string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                        sqlTLVN2.sqlExecuteNonQuery(sqlInsert.ToString(), false);
                    }
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, ex.Source, ex.Message);
                return false;

            }
            return true;
        }
        public Dictionary<string,string> GetKeyValuesDepartments()
        {
            Dictionary<string, string> keyValues = new Dictionary<string, string>();
            try
            {
                string sqlQuerry = " select ME001, ME002 from CMSME ";
                DataTable dt = new DataTable();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    keyValues.Add(dt.Rows[i]["ME001"].ToString(), dt.Rows[i]["ME002"].ToString());
                }


            }
            catch (Exception)
            {

                throw;
            }
            return keyValues;
        }
    }

}
