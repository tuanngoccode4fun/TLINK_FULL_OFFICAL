using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApplication1.WMS.Model;
namespace WindowsFormsApplication1.WMS.Controller
{
  public  class GetPendingWarehouseStock
    {

        public List<PendingWarehouseItems> GetFinishedGoodsItems(string product)
        {
            List<PendingWarehouseItems> pendingWarehouseItems = new List<PendingWarehouseItems>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select  a.ID, a.ITEMID,LOTSIZE, a.UNIT,a.PKQTYPER, a.ERP_WSID,a.ERP_OPID   from LOT a 
 left join MODETAIL b on CMOID = ID
 where  1 = 1
 and ERP_OPSEQ = '0020'
 and a.STATUS = '130'
 and b.STATUS != '99' and b.STATUS != '100' ");
                stringBuilder.Append(" and a.ITEMID LIKE '%" + product + "%' ");
                DataTable dt = new DataTable();
                sqlSFT sqlTLVN2 = new sqlSFT();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    pendingWarehouseItems.Add(new PendingWarehouseItems
                    {
                        ProductCode = dt.Rows[i]["ID"].ToString(),
                        product = dt.Rows[i]["ITEMID"].ToString(),
                        TotalQty = dt.Rows[i]["LOTSIZE"].ToString() != "" ? double.Parse(dt.Rows[i]["LOTSIZE"].ToString()) : 0,
                        DefectQty = 0,
                        Unit = dt.Rows[i]["UNIT"].ToString(),
                        DateExport = DateTime.Now,
                        PKQTYPER = double.Parse(dt.Rows[i]["PKQTYPER"].ToString()),
                        OUTDEPID = dt.Rows[i]["ERP_WSID"].ToString(),
                        OUTTYPE = dt.Rows[i]["ERP_OPID"].ToString()

                    }) ;
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetFinishedGoodsItems(string product)", ex.Message);
            }
            return pendingWarehouseItems;
        }
    }
}
