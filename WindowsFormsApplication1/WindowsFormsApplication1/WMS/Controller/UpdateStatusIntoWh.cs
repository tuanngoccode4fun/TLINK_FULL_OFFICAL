using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1.WMS.Controller
{
    public class UpdateStatusIntoWh
    {
        public bool UpdateSFTStatusIntoWH(DataTable dtERPPQC)
        {
            try
            {


                if (dtERPPQC.Rows.Count == 0)
                    return false;
                ConvertDataTable convertDataTable = new ConvertDataTable();
                int[] OutSequence = new int[dtERPPQC.Rows.Count];
                DataTable dtWSRUN = convertDataTable.GetDataTableSFT_WS_RUNPendingWH(dtERPPQC);
                if (dtWSRUN.Rows.Count == 0)
                {
                    MessageBox.Show("data convert WS_RUN_PENDING WareHouse is fail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                Database.SFT.SFT_WS_RUN sFT_WS_RUN = new Database.SFT.SFT_WS_RUN();
                var InsertWsRun = sFT_WS_RUN.InsertData(dtWSRUN, out OutSequence);

                Database.SFT.SFT_LOT sFT_LOT = new Database.SFT.SFT_LOT();
                var InsertorUpdateLot = sFT_LOT.InsertOrUpdateIntoWH(dtERPPQC);
                Database.SFT.SFT_OP_REALRUN sFT_OP_REALRUN = new Database.SFT.SFT_OP_REALRUN();

                var insertorUpdateREALRUN = sFT_OP_REALRUN.UpdateOrInsert(dtERPPQC, OutSequence);
                if (InsertWsRun && InsertorUpdateLot && insertorUpdateREALRUN)
                    return true;
                else
                {
                    MessageBox.Show("Insert data for pending warehouse fail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }

            catch (Exception EX)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateSFTStatusIntoWH(DataTable dtERPPQC)", EX.Message);
            }
            return false;
        }


    }
}
