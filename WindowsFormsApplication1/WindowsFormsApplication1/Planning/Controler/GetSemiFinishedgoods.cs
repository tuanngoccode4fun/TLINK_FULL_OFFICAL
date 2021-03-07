using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Planning.Controler
{
    class GetSemiFinishedgoods
    {
        public List<SemiFinishedGoods> ListGetSemiFinishedGoods(string dept, string product, double TotalOrder)
        {
            List<SemiFinishedGoods> Listsemifinishedgoods = new List<SemiFinishedGoods>();
            try
            {
                DataTable dtSemi = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select MD001,MD003,MD006,MD012 from BOMMD where  1=1 and MD003 like '%B-%' ");//lenh tim kiem chua chat che lam
                sql.Append(" and MD001 = '" + product + "'");
                sqlERPCON sqlCON = new sqlERPCON();
                sqlCON.sqlDataAdapterFillDatatable(sql.ToString(), ref dtSemi);
                for (int i = 0; i < dtSemi.Rows.Count; i++)
                {
                    SemiFinishedGoods semiFinished = new SemiFinishedGoods();
                   // semiFinished.Item = dtSemi.Rows[i]["MD003"].ToString();

                    semiFinished = GetStockGoodsONSFT(dept,dtSemi.Rows[i]["MD003"].ToString());
                    semiFinished.QtyNeed = TotalOrder * (double.Parse(dtSemi.Rows[i]["MD006"].ToString()));
                    
                    Listsemifinishedgoods.Add(semiFinished);
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ListGetSemiFinishedGoods(string product) : " + product, ex.Message);
            }
            return Listsemifinishedgoods;

        }

        public List<SemiFinishedGoods> ListGetSemiFinishedGoods(string dept, string product)
        {
            List<SemiFinishedGoods> Listsemifinishedgoods = new List<SemiFinishedGoods>();
            try
            {
                DataTable dtSemi = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select MD001,MD003,MD006,MD012 from BOMMD where  1=1 and MD003 like '%B-%' ");//lenh tim kiem chua chat che lam
                sql.Append(" and MD001 = '" + product + "'");
                sqlERPCON sqlCON = new sqlERPCON();
                sqlCON.sqlDataAdapterFillDatatable(sql.ToString(), ref dtSemi);
                for (int i = 0; i < dtSemi.Rows.Count; i++)
                {
                    SemiFinishedGoods semiFinished = new SemiFinishedGoods();
                    // semiFinished.Item = dtSemi.Rows[i]["MD003"].ToString();

                    semiFinished = GetStockGoodsONSFT(dept, dtSemi.Rows[i]["MD003"].ToString());
             

                    Listsemifinishedgoods.Add(semiFinished);
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ListGetSemiFinishedGoods(string product) : " + product, ex.Message);
            }
            return Listsemifinishedgoods;

        }

        public SemiFinishedGoods GetStockGoodsONSFT(string dept,string product)
        {
            SemiFinishedGoods semiFinished = new SemiFinishedGoods();
            try
            {

                GetStockinINVMC getStockinINVMC = new GetStockinINVMC();
                var StockInWarehouse = getStockinINVMC.GetItemsInINVMCs(dept, product);
                if (StockInWarehouse != null)
                {
                    semiFinished.QtyInWarehouse = StockInWarehouse.Select(d => d.Quantity).Sum();
                    semiFinished.QtyWarehouse = StockInWarehouse.Select(d => d.Quantity).Sum();
                }
                semiFinished.Item = product;
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  isnull(sum(LOTSIZE),'0')  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0010' and a.STATUS = '0' and b.STATUS !='99' and b.STATUS !='100' 
 ");
                stringBuilder.Append(" and a.ITEMID =  '" + product + "'");
                sqlSFT sqlERPCON = new sqlSFT();
                var Temp = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (Temp != null && Temp != "")
                {
                    semiFinished.QtyInMQC = double.Parse(Temp);
                }
                stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  isnull(sum(LOTSIZE),'0')  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0010' and a.STATUS = '50' and b.STATUS !='99' and b.STATUS !='100' 
 ");
                stringBuilder.Append(" and a.ITEMID =  '" + product + "'");
                //  sqlERPCON sqlERPCON = new sqlERPCON();
                Temp = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (Temp != null && Temp != "")
                {
                    semiFinished.QtyOutMQC = double.Parse(Temp.ToString());
                }

                stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  isnull(sum(LOTSIZE),'0')  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0020' and a.STATUS = '0' and b.STATUS !='99' and b.STATUS !='100' 
 ");
                stringBuilder.Append(" and a.ITEMID =  '" + product + "'");
                //  sqlERPCON sqlERPCON = new sqlERPCON();
                Temp = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (Temp != null && Temp != "")
                {
                    semiFinished.QtyInPQC = double.Parse(Temp.ToString());
                }

                stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  isnull(sum(LOTSIZE),'0')  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0020' and a.STATUS = '50' and b.STATUS !='99' and b.STATUS !='100' 
 ");
                stringBuilder.Append(" and a.ITEMID =  '" + product + "'");
                //  sqlERPCON sqlERPCON = new sqlERPCON();
                Temp = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (Temp != null && Temp != "")
                {
                    semiFinished.QtyOutPQC = double.Parse(Temp.ToString());
                }

                stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  isnull(sum(LOTSIZE),'0')  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0020' and a.STATUS = '130' and b.STATUS !='99' and b.STATUS !='100' 
 ");
                stringBuilder.Append(" and a.ITEMID =  '" + product + "'");
                //  sqlERPCON sqlERPCON = new sqlERPCON();
                Temp = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (Temp != null && Temp != "")
                {
                    semiFinished.QtyPendingWarehouse = double.Parse(Temp.ToString());
                }
                semiFinished.QTyAtMQC = semiFinished.QtyOutMQC;
                semiFinished.QTyAtPQC = semiFinished.QtyInPQC + semiFinished.QtyOutPQC;
                semiFinished.QtyWip = semiFinished.QTyAtMQC + semiFinished.QTyAtPQC + semiFinished.QtyPendingWarehouse;
                GetAccessory getAccessory = new GetAccessory();
                semiFinished.accessories = getAccessory.GetAccessories(dept,product);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetStockGoodsONSFT(string product) : "+ product, ex.Message);
            }
            return semiFinished;
        }
    }
}
