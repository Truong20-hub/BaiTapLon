using DAL;
using DAL_.helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL_
{
    public class PhongHocDAL : IPhongHocDAL
    {
        private IDatabaseHelper helper;
        public PhongHocDAL(IDatabaseHelper _helper)
        {
            this.helper = _helper;
        }
        public (string k, bool h) createPH(PhongHoc phongHoc)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemPhongHoc",
                "@MaPhongHoc", phongHoc.IDPhongHoc,
                "@TenPhong", phongHoc.TenPhongHoc,
                "@SucChua", phongHoc.SucChua,
                "@TrangThai", phongHoc.TrangThai,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã phòng đã tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) updatePH(PhongHoc phongHoc)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_SuaPhongHoc",
                "@MaPhongHoc", phongHoc.IDPhongHoc,
                "@TenPhong", phongHoc.TenPhongHoc,
                "@SucChua", phongHoc.SucChua,
                "@TrangThai", phongHoc.TrangThai,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã phòng không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) deletePH(string iDPhong)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_XoaPhongHoc",
                "@MaPhongHoc", iDPhong,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã phòng không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<PhongHoc> getAllPH()
        {
            List<PhongHoc> list = new List<PhongHoc>();
            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllPhongHoc");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                PhongHoc phongHoc = new PhongHoc(
                row["maPhongHoc"].ToString(),
                row["TenPhong"].ToString(),
                Convert.ToInt32(row["sucChua"]),
                row["trangThai"].ToString()
                ); 
                list.Add(phongHoc);
            }
            return list;
        }
        public List<PhongHoc> searchPH(PhongHoc phongHoc)
        {
            List<PhongHoc> list = new List<PhongHoc>();
            string kq="";
            int t = 0;
            var dt = helper.ExcuteProcedureToDataTable(out kq,"sp_SearchPhongHoc",
                "@MaPhongHoc", phongHoc.IDPhongHoc,
                "@TenPhong", phongHoc.TenPhongHoc
            );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                PhongHoc ph = new PhongHoc(
                row["maPhongHoc"].ToString(),
                row["TenPhong"].ToString(),
                Convert.ToInt32(row["sucChua"]),
                row["trangThai"].ToString()
                );
                list.Add(ph);
            }
            return list;
        }
    }
}
