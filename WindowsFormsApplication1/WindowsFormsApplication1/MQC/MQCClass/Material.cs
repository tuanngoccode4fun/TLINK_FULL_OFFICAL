
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.MQC.MQCClass
{
  public  class Material
    {
        public bool KiemtraNguyenVatLieu(string code, string No,double SLUpload, out bool IsDuSoLuong, out bool isDunguyenvanLieu, out List<MaterialAdapt> materials) //code :P511 , No : 1900010
        {
            bool _NVL = false;
          
            List<NVLTheoLSX> _listNVL = ListNVL(code, No);
            List<MaterialAdapt> materialAdapts = new List<MaterialAdapt>();
            List<MaterialAdapt> materialAdaptsQty = new List<MaterialAdapt>();
            List<LSX_SFTTA> _listSFTTA = ListSFTTA(code, No);
            if (_listNVL.Count ==0)
            {
                IsDuSoLuong = false;
                isDunguyenvanLieu = false;
                materials = null;
              
                return false;
            }
           

            bool _SL = false;

            if(_listSFTTA.Count==1)
            {
                if (_listSFTTA[0].SLKeHoach_TA010 >= _listSFTTA[0].SLOutput_TA011 + _listSFTTA[0].SLBaoPhe_TA012)
                {
                    _SL = false;
                }
                else
                {
                    _SL = true;
                }
                foreach (var item in _listNVL)
                {
                    MaterialAdapt adapt = new MaterialAdapt();
                    MaterialAdapt adaptQty = new MaterialAdapt();

                    adapt.Material = item.NVL_TB003;
                    adaptQty.Material = item.NVL_TB003;
                    if (item.NVLCan_TB004 != 0)
                    {
                        adapt.PlanQty = (int)(_listSFTTA[0].SLKeHoach_TA010 * (item.NVLLanh_TB005 / item.NVLCan_TB004));
                        adapt.MaterialShortage= (int)(_listSFTTA[0].SLKeHoach_TA010 - adapt.PlanQty);
                        adapt.Percent = (double)(adapt.PlanQty / _listSFTTA[0].SLKeHoach_TA010);
                        
                    }
                    else
                    {
                        adapt.PlanQty = _listSFTTA[0].SLKeHoach_TA010;
                        adapt.MaterialShortage = 0;
                        adapt.Percent = 1;

                    
                    }
                    adapt.CurrentQty = (double)((_listSFTTA[0].SLOutput_TA011 + _listSFTTA[0].SLBaoPhe_TA012)/ _listSFTTA[0].SLKeHoach_TA010 * (item.NVLLanh_TB005 / item.NVLCan_TB004));
                    materialAdapts.Add(adapt);
                    materialAdaptsQty.Add(adaptQty);
            }
              
               double SLCoTheDapUngDuoc = materialAdapts.Select(d => d.PlanQty).ToArray().Min();
                if(_listSFTTA[0].SLOutput_TA011+ _listSFTTA[0].SLBaoPhe_TA012 + SLUpload < SLCoTheDapUngDuoc)
                {
                    _NVL = true;

                }
                else _NVL = false;
            }
           

            IsDuSoLuong = _SL;
            isDunguyenvanLieu = _NVL;
            materials = materialAdaptsQty;
       

            return (!IsDuSoLuong & isDunguyenvanLieu);
        }
        public bool IsMaterialOK(string code, string No, out bool isDunguyenvanLieu, out List<MaterialItems> materials) //code :P511 , No : 1900010
        {
            bool _NVL = false;

            List<NVLTheoLSX> _listNVL = ListNVL(code, No);

            List<LSX_SFTTA> _listSFTTA = ListSFTTA(code, No);
            List<MaterialItems> ListMaterials = new List<MaterialItems>(); 
            if (_listNVL.Count == 0)
            {
                isDunguyenvanLieu = false;
                materials = null;

                return false;
            }



            if (_listSFTTA.Count == 1)
            {

                foreach (var item in _listNVL)
                {
                    MaterialItems materialItems = new MaterialItems();
                    materialItems.Material = item.NVL_TB003;
                    materialItems.PlanQty = item.NVLCan_TB004;
                    materialItems.NeedQty = (double)((_listSFTTA[0].SLOutput_TA011 + _listSFTTA[0].SLBaoPhe_TA012) / _listSFTTA[0].SLKeHoach_TA010 * item.NVLCan_TB004);
                    materialItems.Current = item.NVLLanh_TB005;
                    materialItems.Percent =(item.NVLCan_TB004 !=0)? materialItems.Current / materialItems.NeedQty :1;
                    if (materialItems.Percent < 1)
                        materialItems.Status = "NO";
                    else materialItems.Status = "YES";

                    ListMaterials.Add(materialItems);
                }

            }
            if (ListMaterials.Select(d => d.Percent).Min() < 1)
                isDunguyenvanLieu = false;
            else isDunguyenvanLieu = true;

            materials = ListMaterials;
            return isDunguyenvanLieu;


        }
        public List<NVLTheoLSX> ListNVL (string code, string No)
        {

            List<NVLTheoLSX> _listNVL = new List<NVLTheoLSX>();
            sqlERPCON query= new sqlERPCON();
            StringBuilder strSQL = new StringBuilder();
            DataTable dt = new DataTable();
            strSQL.Append("select TB001,TB002, TB003,TB004,TB005,TB006 from MOCTB where TB006 ='****' and TB018 ='Y' and ");
            strSQL.Append(" TB001 = '" + code + "' and ");
            strSQL.Append(" TB002 = '" + No + "'");
            query.sqlDataAdapterFillDatatable(strSQL.ToString(), ref dt);
            //Load data into list
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                NVLTheoLSX nVL = new NVLTheoLSX();
               
                nVL.code = dt.Rows[i]["TB001"].ToString();
                nVL.No = dt.Rows[i]["TB002"].ToString();
                nVL.NVL_TB003 = dt.Rows[i]["TB003"].ToString();
                nVL.NVLCan_TB004 = dt.Rows[i]["TB004"].ToString() != "" ? double.Parse(dt.Rows[i]["TB004"].ToString()):0;
                nVL.NVLLanh_TB005 = dt.Rows[i]["TB005"].ToString() != "" ? double.Parse(dt.Rows[i]["TB005"].ToString()) : 0;
                nVL.NVLPercentLanh = (nVL.NVLCan_TB004 != 0) ? (nVL.NVLLanh_TB005 / nVL.NVLCan_TB004) :((nVL.NVLCan_TB004 == nVL.NVLLanh_TB005)?1:0);
                nVL.CD_TB006 = dt.Rows[i]["TB006"].ToString();
                _listNVL.Add(nVL);

            }
         
               
            return _listNVL;
        }
        public List<LSX_SFTTA> ListSFTTA (string code, string No)
        {
            List<LSX_SFTTA> lSX_SFTTAs = new List<LSX_SFTTA>();
            sqlERPCON query = new sqlERPCON();
            StringBuilder strSQL = new StringBuilder();
            DataTable dt = new DataTable();
            strSQL.Append("select TA001,TA002,TA003,TA004,TA008,TA009,TA010,TA011,TA012 from SFCTA where TA003 = '0010' and  ");
            strSQL.Append(" TA001 = '" + code + "' and ");
            strSQL.Append(" TA002 = '" + No + "'");
            query.sqlDataAdapterFillDatatable(strSQL.ToString(), ref dt);
            //Load data into list
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                LSX_SFTTA sFTTA = new LSX_SFTTA();
                sFTTA.code = dt.Rows[i]["TA001"].ToString();
                sFTTA.No = dt.Rows[i]["TA002"].ToString();
                sFTTA.MaSX_TA003 = dt.Rows[i]["TA003"].ToString();
                sFTTA.MaSX_TA004 = dt.Rows[i]["TA004"].ToString();
                sFTTA.NgayBatdau_TA008 = dt.Rows[i]["TA008"].ToString();
                sFTTA.NgayKetThuc_TA009 = dt.Rows[i]["TA009"].ToString();
                sFTTA.SLKeHoach_TA010 = dt.Rows[i]["TA010"].ToString() != "" ? double.Parse(dt.Rows[i]["TA010"].ToString()) : 0;
                sFTTA.SLOutput_TA011 = dt.Rows[i]["TA011"].ToString() != "" ? double.Parse(dt.Rows[i]["TA011"].ToString()) : 0;
                sFTTA.SLBaoPhe_TA012 = dt.Rows[i]["TA012"].ToString() != "" ? double.Parse(dt.Rows[i]["TA012"].ToString()) : 0;
                lSX_SFTTAs.Add(sFTTA);

            }
            return lSX_SFTTAs;
        }
    }
    public class NVLTheoLSX
    {
        public string code { get; set; }
        public string No { get; set; }
        public string NVL_TB003 { get; set; }
        public double NVLCan_TB004 { get; set; }
        public double NVLLanh_TB005 { get; set; }
        public double NVLPercentLanh { get; set; }
        public string CD_TB006 { get; set; }

    }
    public class LSX_SFTTA
    {
        public string code { get; set; }
        public string No { get; set; }
        public string MaSX_TA003 { get; set; }
        public string MaSX_TA004 { get; set; }
        public string NgayBatdau_TA008 { get; set; }
        public string NgayKetThuc_TA009 { get; set; }
        public double SLKeHoach_TA010 { get; set; }
        public double SLOutput_TA011 { get; set; }
        public double SLBaoPhe_TA012 { get; set; }

    }
    public class MaterialAdapt
    {
        public string Material { get; set; }
        public double PlanQty { get; set; }
        public double CurrentQty { get; set; }
        public double MaterialShortage { get; set; }
        public double Percent { get; set; }

    }
    public class MaterialItems
    {
        public string Material { get; set; }
        public double PlanQty { get; set; }
        public double NeedQty { get; set; }
        public double Current { get; set; }
        public double Percent { get; set; }
        public string Status { get; set; }

    }
}
