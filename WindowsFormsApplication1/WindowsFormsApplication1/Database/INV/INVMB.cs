using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.INV
{
  public  class INVMB
    {
        public static int ExpireDaybyProduct( string product)

        {
            string querry = "select MB023 from INVMB where MB001 = '" + product + "' ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            var strresult = sqlTLVN2.sqlExecuteScalarString(querry);
            if (strresult == String.Empty && strresult == "")
                return 0;
            else
                return int.Parse(strresult);
        }
		public static string IsWeightValue(string product)

		{
			string querry = "select MB004 from INVMB where MB001 = '" + product + "' ";
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			var strresult = sqlTLVN2.sqlExecuteScalarString(querry);
			if (strresult == String.Empty && strresult == "")
				return " ";
			else
				return strresult;
		}
		public static int ExpireDayInspectbyProduct(string product)

		{
			string querry = "select MB024 from INVMB where MB001 = '" + product + "' ";
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			var strresult = sqlTLVN2.sqlExecuteScalarString(querry);
			if (strresult == String.Empty && strresult == "")
				return 0;
			else
				return int.Parse(strresult);
		}
		public static DataTable GetDatabyProduct(string product)
		{
			DataTable dt = new DataTable();
			string querry = "select  * from INVMB where MB001='"+ product + "' ";
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
			return dt;
		}
		public bool UpdateINVMBbyProduct(Model.INVItems iNVItems)
        {
			
				try
				{
				double ConvertToKg = Database.INV.INVMD.ConvertToWeightKg(iNVItems.Product, iNVItems.Quantity);
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append(" update INVMB ");
					stringBuilder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
					stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
					stringBuilder.Append("  FLAG = FLAG+1 ,  ");
					stringBuilder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
					stringBuilder.Append("  MODI_AP = '" + "SFT" + "' ,");
					stringBuilder.Append("  MODI_PRID = '" + "MOCI05" + "' ,");
				if (iNVItems.TypeInportExport == "1")
				{
					stringBuilder.Append("  MB064 = MB064 + " + iNVItems.Quantity + " ,");
					stringBuilder.Append("  MB089= MB089 + " + ConvertToKg + " ");
				}
				else if (iNVItems.TypeInportExport == "-1")
				{
					stringBuilder.Append("  MB064 = MB064 - " + iNVItems.Quantity + " ,");
					stringBuilder.Append("  MB089= MB089 - " + ConvertToKg + " ");
				}
				
					stringBuilder.Append(" where MB001 ='" + iNVItems.Product + "' ");
			
					SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
					var result = sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);
					if (result == false)
					{
						SystemLog.Output(SystemLog.MSG_TYPE.War, "UpdateSFCTAForFinishedGoods(FinishedGoodsItems fgItems)", "");
						return false;
					}
					else return true;

				}
				catch (Exception ex)
				{

					SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateSFCTAForFinishedGoods(FinishedGoodsItems fgItems, string TA003)", ex.Message);
				}
				return false;
			

			
        }

		public static bool IsExistProduct(string product)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from INVMB ");
				stringBuilder.Append(" where 1=1 ");
				stringBuilder.Append(" and MB001 = '" + product + "' ");
				SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
				DataTable dt = new DataTable();
				sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
				if (dt.Rows.Count > 0)
				{
					return true;
				}
				else return false;

			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "CheckExistINVMM(Model.INVItems iNVItems)", ex.Message);
				return false;
			}
		}
		public static bool IsStockAvaiable(string product, double Quantity)
		{
			try
			{


				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from INVMB ");
				stringBuilder.Append(" where 1=1 ");
				stringBuilder.Append(" and MB001 = '" + product + "' ");
				
				stringBuilder.Append(" and MB064 >= " + Quantity);


				SqlTLVN2 sqlTLVN2 = new SqlTLVN2();

				DataTable dt = new DataTable();
				sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
				if (dt.Rows.Count > 0)
				{
					return true;
				}
				else return false;
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "IsStockAvaiable(string product, string warehouse, string location, string lot, double Quantity )", ex.Message);
			}
			return false;

		}
		public static DataTable GetProductInfor()
		{
			DataTable dt = new DataTable();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select MB001,MB002,MB003 from INVMB  ");
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			 sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			return dt;
		}
		public static DataTable GetProductInforbyModel(string model)
		{
			DataTable dt = new DataTable();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select MB001,MB002,MB003 from INVMB where 1=1  ");
			stringBuilder.Append(" and MB002 like '%" + model + "%' ");
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			return dt;
		}
	}
}
