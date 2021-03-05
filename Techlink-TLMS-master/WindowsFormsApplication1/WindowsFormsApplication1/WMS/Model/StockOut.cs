using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.WMS.Model
{
  public  class StockOut
    {

    }
    public class INVTATB
    {
        public bool checkBox { get; set; }
        public string TA001_ma { get; set; }
        public string TA002_code { get; set; }
        public string TB003_STT { get; set; }
        public string Evaluation { get; set; }       
        public string TB004_SP { get; set; }
        public string TB014_Lot { get; set; }
        public double TB007_SL { get; set; }
        public double SLConLai { get; set; }
        public string TB012_KhoChuyen { get; set; }
        public string TB026_VtKhoChuyen { get; set; }
        public string TB013_khoNhan { get; set; }
        public string TB027_VtKhoNhan { get; set; }
        public string TB005_TenSp { get; set; }
        public string TB006_Quycach { get; set; }
        public string TA004_BP { get; set; }


        public double TB022_SLDonggoi { get; set; }

        public string TB008_Unit { get; set; }
        public string TB023_DonViDongGoi { get; set; }
        public DateTime TB015_ExpiryDate { get; set; }
        public DateTime TA014_ngayCT { get; set; }

    }
    public class LotINVMEMF
    {   public bool checkbox { get; set; }
        public string STT { get; set; }
        public string MF001_Sp { get; set; }
        public string MF002_Lot { get; set; }
        public string MF002_Location { get; set; }
        public string MF007_kho { get; set; }
        public double SL_TrongKho { get; set; }
        public double SL { get; set; }
        public DateTime ME003_ImportDate { get; set; }
        public DateTime ME009_ExpiryDate { get; set; }
        
    }
    public class INVLF_Locate
    {
        public bool Checkbox { get; set; }
        public string LF004_Sp { get; set; }
        public string LF005_Kho { get; set; }

        public string LF007_Lot { get; set; }

        public string LF006_Vitri { get; set; }
        public double Quantity { get; set; }
    }
}
