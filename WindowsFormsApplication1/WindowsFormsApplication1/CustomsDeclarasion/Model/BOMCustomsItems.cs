using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.CustomsDeclarasion.Model
{
   public class SummaryDelivery
    {
        public string Product { get; set; }
        public decimal TotalQuantity { get; set; }
        public string Unit { get; set; }
        public decimal PriceUnit { get; set; }
        public decimal price { get; set; }
        public string Currency { get; set; }

    }
    public class BOMCustomsDeclar
    {
        public string Product { get; set; }
        public decimal SLSanpham { get; set; }
        public decimal GiaTriSp { get; set; }
        public string DonviSp { get; set; }
        public string MaNVL { get; set; }
        public  string NVL { get; set; }
        public string MaHS { get; set; }
        public string TKHQ { get; set; }
        public string NuocXuatXu { get; set; }
        public string DVTinh { get; set; }
        public double DinhMuc { get; set; }
        public double DonGia { get; set; }
        public string HiepDinh { get; set; }
     
  
        


    }

}
