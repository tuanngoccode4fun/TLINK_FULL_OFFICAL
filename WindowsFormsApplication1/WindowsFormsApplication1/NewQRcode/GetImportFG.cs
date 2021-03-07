using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.ClassMysql;
using WindowsFormsApplication1.ClassObject;

namespace WindowsFormsApplication1.NewQRcode
{
    class GetImportFG
    {
        //tuanngoc step 1 for get data from QR code and then input to contruct database
        public static Import_FinishGood_WareHouse ConvertQR2DataTable(string txtInput,string warehouseName, DataGridView dtinput)
        {
            Import_FinishGood_WareHouse Temp = new Import_FinishGood_WareHouse();
            string[] arraydata = Regex.Replace( txtInput," ","").TrimStart('s').TrimEnd('e').Split(';');
            if (IdentifyQR.IsCorrectFormat(txtInput.Trim()) == true)
                {
                  Temp.TransactionID = Regex.Replace(txtInput, " ", "");// get full data
                  Temp.UserID = Class.valiballecommon.GetStorage().UserName;// get user name
                  Temp.STT = (dtinput.Rows.Count+1).ToString("D4");
                  Temp.ProductOrder = ReturnProductOrder(arraydata[1]);//"B511-20100019";//"B511-20100154";
                  Temp.Product = arraydata[2];
                  Temp.Quantity =Convert.ToUInt32( arraydata[4]);
                  Temp.LotNo = arraydata[7].Replace(Temp.Product,"");// 
                  Temp.Warehouse = warehouseName;
                  Temp.dateImport = DateTime.Now;
                  return Temp;
                }
            return null ;
        }
        /// <summary>
        ///  this function for add new "-" production order
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
    static string ReturnProductOrder(string text)
        {
            try
            {
                if (text.ToCharArray().Count() > 4)
                {
                    return (text.Substring(0, 4) + "-" + text.Substring(4));
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err,"ReturnProductOrder: " , ex.Message);
            }
            return null;
        }
    }
}
