using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace WindowsFormsApplication1.WMS
{
  public  class DBStockInOut
    {
        public bool Insert2StockIn(gridviewInStock inStock)
        { string IDQRCODE = inStock.TD001_Ma + "-" + inStock.TD002_Code + ";" + inStock.TD004_MaSP + ";" + inStock.TD005_TenSP + ";" + inStock.SLThucte.ToString() + ";" + DateTime.Now.ToString("dd/MM/yyyy") + ";" + inStock._ExpiryDay.ToString("dd/MM/yyyy") + ";" + inStock.Lot ;
            string QRLocation = inStock._Kho + ";" + inStock._VitriKho;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" insert into t_QRStockin (IDQRCODE,PurchasingCode, MaterialCode , Commodity, Specification,Quantity, ImportDate,ExpiryDate,Lot_PO,Invoice,Remark, IDQRLocation, Warehouse,Warehouse_NAME,LOCATION, RACK ,Update_Date ) values ( ");
            stringBuilder.Append("'" + IDQRCODE + "',");
            stringBuilder.Append("'" + inStock.TD001_Ma+"-"+inStock.TD002_Code + "',");
            stringBuilder.Append("'" + inStock.TD004_MaSP + "',");
            stringBuilder.Append("'" + inStock.TD005_TenSP + "',");
            stringBuilder.Append("'" + "" + "',");
            stringBuilder.Append("'" + inStock.SLThucte.ToString() + "',");
            stringBuilder.Append("'" + DateTime.Now.ToString("yyyy-MM-dd")+ "',");
            stringBuilder.Append("'" +inStock._ExpiryDay.ToString("yyyy-MM-dd") + "',");
            stringBuilder.Append("'" + inStock.Lot + "',");
            stringBuilder.Append("'" + inStock.Invoice + "',");
            stringBuilder.Append("'" + ""+ "',");
            stringBuilder.Append("'" + QRLocation + "',");
            stringBuilder.Append("'" + inStock._Kho + "',");
            stringBuilder.Append("'" + "" + "',");
            stringBuilder.Append("'" + inStock._VitriKho + "',");
            stringBuilder.Append("'" + "" + "' ,");
            stringBuilder.Append("" + "GETDATE()" + " )");

            string sql = stringBuilder.ToString();
            try
            {

            sqlCON sqlCON = new sqlCON();
         return   sqlCON.sqlExecuteNonQuery(sql, false);
            }
            catch (Exception ex)
            {
               SystemLog.Output(SystemLog.MSG_TYPE.Err, "Insert2StockIn(gridviewInStock inStock)", ex.Message);
                return false;
            }
           
        }
    }
}
