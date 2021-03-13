using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
 public   class INVMBUpdate
    {
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
				else if(iNVItems.TypeInportExport == "-1")
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
	}
}
