using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
   public class GetListWarehouse
    {
        public List<WarehouseItems> GetWarehouseItems()
        {
            List<WarehouseItems> warehouseItems = new List<WarehouseItems>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select MC001, MC002, NL002, NL003,NL004 from CMSMC
inner join CMSNL on NL001 = MC001
order by MC001 ");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                DataTable dt = new DataTable();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    warehouseItems.Add(new WarehouseItems
                    {
                        MC001_Wh = dt.Rows[i]["MC001"].ToString(),
                        MC002_WhName = dt.Rows[i]["MC002"].ToString(),
                        NL002_Location = dt.Rows[i]["NL002"].ToString(),
                        NL003_LocationName = dt.Rows[i]["NL003"].ToString(),
                        NL004_LocationNote = dt.Rows[i]["NL004"].ToString(),
                    });
                }

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<WarehouseItems> GetWarehouseItems()", ex.Message);
            }
            return warehouseItems;
        }
        public List<WarehouseItems> GetWarehouseOnly()
        {
            List<WarehouseItems> warehouseItems = new List<WarehouseItems>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select distinct MC001, MC002 from CMSMC
order by MC001 ");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                DataTable dt = new DataTable();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    warehouseItems.Add(new WarehouseItems
                    {
                        MC001_Wh = dt.Rows[i]["MC001"].ToString(),
                        MC002_WhName = dt.Rows[i]["MC002"].ToString(),
                       
                    });
                }

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<WarehouseItems> GetWarehouseItems()", ex.Message);
            }
            return warehouseItems;
        }
    }
}
