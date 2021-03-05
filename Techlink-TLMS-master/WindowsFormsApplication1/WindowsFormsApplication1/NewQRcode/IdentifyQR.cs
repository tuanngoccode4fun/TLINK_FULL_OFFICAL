using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using WindowsFormsApplication1.ClassMysql;
using WindowsFormsApplication1.ClassObject;
using WindowsFormsApplication1.NewQRcode.UI_mesage;
using WindowsFormsApplication1.WMS.View;

namespace WindowsFormsApplication1.NewQRcode
{
    
    class IdentifyQR
    {
      static int countItem =10; //typeof(Class_ExportFG_WareHouse).GetProperties().Count();// HAVE CHANGE IF REAL DATA
        static public  bool IsCorrectFormat(string txtInput)
        {
            string[] ListCurrentItem = System.Text.RegularExpressions.Regex.Replace(txtInput, " ", "").Split(';');
            if (txtInput.Trim().StartsWith("s")!=true)
            {
              ClassMessageBoxUI.Show ("QR code not start with \"s\" ", false);
                return false;
            }
            if (txtInput.Trim().EndsWith("e") != true)
            {
                ClassMessageBoxUI.Show("QR code not end with \"e\" ",false);
                return false;
            }
            if (ListCurrentItem[ListCurrentItem.Count() - 1].Trim() != "*e")
            {
                ClassMessageBoxUI.Show("You can't use this QR code. Please contact your admin!", false);
                return false;
            }
            if (ListCurrentItem.Count() < countItem)
            {
                ClassMessageBoxUI.Show(string.Format("QR input not enough item spec > {0}, current {1}",countItem, ListCurrentItem.Count()),false);
                return false;    
            }
            return true;
        }
        static public bool IsDuplicate(List<Import_FinishGood_WareHouse> listInput, Import_FinishGood_WareHouse itemInput)
        {
                   return ( listInput.Any(x => x.LotNo == itemInput.LotNo)
                         && listInput.Any(x => x.Product == itemInput.Product)
                         && listInput.Any(x => x.ProductOrder == itemInput.ProductOrder)
                         && listInput.Any(x => x.Quantity == itemInput.Quantity)
                         //&& listInput.Any(x => x.STT == itemInput.STT)
                         && listInput.Any(x => x.SubQR == itemInput.SubQR)
                         && listInput.Any(x => x.TL101 == itemInput.TL101)
                         && listInput.Any(x => x.TL102 == itemInput.TL102)
                         && listInput.Any(x => x.TL103 == itemInput.TL103)
                         && listInput.Any(x => x.TL104 == itemInput.TL104)
                         && listInput.Any(x => x.TL111 == itemInput.TL111)
                         && listInput.Any(x => x.TL112 == itemInput.TL112)
                         && listInput.Any(x => x.TL113 == itemInput.TL113)
                         && listInput.Any(x => x.TL114 == itemInput.TL114)
                         && listInput.Any(x => x.TransactionID == itemInput.TransactionID)
                         && listInput.Any(x => x.UserID == itemInput.UserID)
                         && listInput.Any(x => x.Warehouse == itemInput.Warehouse)// have to check

                   );}
        static public bool IsWrongWareHouse(List<Import_FinishGood_WareHouse> listInput, Import_FinishGood_WareHouse itemInput)
        {
            if (listInput.Count == 0)
            {
                return false;
            }
            return (listInput.Any(x => x.Warehouse != itemInput.Warehouse));
        }


    }
}
