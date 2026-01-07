using DAL;
using DAL_.helper;
using Model_;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_
{
    public class LopHocDAL:IClassLH
    {
        private readonly IDatabaseHelper helper;
        public LopHocDAL(IDatabaseHelper _helper)
        {
            this.helper = _helper;
        }
        
        public List<LopHocPhan>  getALLClass()
        {  
            List<LopHocPhan> lopHocs = new List<LopHocPhan>();
            DataTable dt = new DataTable();
            dt = helper.ExcuteProcedureToDataTable("sp_GetAllLopHocPhan");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    LopHocPhan lopHoc = new LopHocPhan(
                        row["maLopHP"].ToString(),
                        row["TenLop"].ToString(),
                        row["MaMonHoc"].ToString(),
                        row["maGiangVien"].ToString(),
                        Convert.ToDateTime( row["ThoiGianMo"]),
                        Convert.ToDateTime( row["thoigianDong"]),
                        Convert.ToInt32( row["soLuongSinhVien"]),
                        row["thuTuUuTien"].ToString()
                        );
                    lopHocs.Add(lopHoc);
                }
            }
            return lopHocs;

        }
    }
}
