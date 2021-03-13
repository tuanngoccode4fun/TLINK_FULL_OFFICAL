using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.CustomsDeclarasion.Controller
{
   public class GetBOMDeclar
    {
        public List<Model.BOMCustomsDeclar> GetBOMCustomsDeclars(Model.SummaryDelivery summaryDelivery)
        {
            List<Model.BOMCustomsDeclar> bOMCustomsDeclars = new List<Model.BOMCustomsDeclar>();


            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@" select a.MA_SP,a.MA_NPL, a.Ten_NPL, b.MA_HS, a.MA_DVT, a.DM_SD from CX_DDINHMUC a
 left join CX_SNPL b on a.MA_NPL = b.MA_NPL
 where 1 = 1");
            stringBuilder.Append("  and MA_SP LIKE '%" + summaryDelivery.Product.Substring(0, summaryDelivery.Product.Length-3) + "%' ");
            SQLCustoms sQLCustoms = new SQLCustoms();
            DataTable dt = new DataTable();
            sQLCustoms.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Model.BOMCustomsDeclar bOM = new Model.BOMCustomsDeclar();
                bOM.Product = summaryDelivery.Product;
                bOM.GiaTriSp = summaryDelivery.price;
              //  bOM.DonviSp =
                bOM.SLSanpham = summaryDelivery.TotalQuantity;
               
                bOM.MaNVL = dt.Rows[i]["MA_NPL"].ToString().Trim();
                bOM.NVL = dt.Rows[i]["Ten_NPL"].ToString().Trim();
                bOM.MaHS = dt.Rows[i]["MA_HS"].ToString().Trim();
                bOM.DVTinh = dt.Rows[i]["MA_DVT"].ToString().Trim();
                bOM.DinhMuc = double.Parse(dt.Rows[i]["DM_SD"].ToString().Trim());
             //   bOM.DonGia =double.Parse( summaryDelivery.UnitPrice.ToString());
                bOMCustomsDeclars.Add(bOM);
            }

            return bOMCustomsDeclars;
        }
    }
}
