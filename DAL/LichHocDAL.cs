using DAL;
using DAL_.helper;
using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_
{
    public class LichHocDAL: ILichHocDAL
    {
        private IDatabaseHelper helper;
        public LichHocDAL(IDatabaseHelper _helper)
        {
            this.helper = _helper;
        }
        public (string k, bool h) createLichHoc(LichHoc lichHoc)
        {
            string k = "";
            bool h =false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemLichHoc",
                "@MaLichHoc", lichHoc.IDLichHoc,
                "@MaLopPhan", lichHoc.IDLopPhan,
                "@NgayHoc", lichHoc.NgayHoc,
                "@SoTiet", lichHoc.SoTiet,
                "@PhongHoc", lichHoc.PhongHoc,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã lịch học đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Mã lớp học phần không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) updateLichHoc(LichHoc lichHoc)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_SuaLichHoc",
                "@MaLichHoc", lichHoc.IDLichHoc,
                "@MaLopPhan", lichHoc.IDLopPhan,
                "@NgayHoc", lichHoc.NgayHoc,
                "@SoTiet", lichHoc.SoTiet,
                "@PhongHoc", lichHoc.PhongHoc,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã lịch học không tồn tại";
                h = false;  
            }
            else if (Exe == "2")
            {
                k = "Mã lớp học phần không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) deleteLichHoc(string iDLichHoc)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_XoaLichHoc",
                "@MaLichHoc", iDLichHoc,
                "@Result", 0    
            );
            if (Exe == "1")
            {
                k = "Mã lịch học không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<LichHoc> getAllLichHoc()
        {
            List<LichHoc> list = new List<LichHoc>();
            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllLichHoc");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                string iDLopPhan = row["maLopPhan"].ToString();
                DateTime ngayHoc = Convert.ToDateTime(row["NgayHoc"]);
                int soTiet = Convert.ToInt32(row["soTiet"]);
                string phongHoc = row["phongHoc"].ToString();
                string iDLichHoc = row["maLichHoc"].ToString();
                LichHoc lichHoc = new LichHoc(iDLopPhan,ngayHoc, soTiet, phongHoc,iDLichHoc);

                list.Add(lichHoc);

            }
            return list;
        }
        public List<LichHoc> searchLichHoc(LichHoc lichHoc)
        {
            List<LichHoc> list = new List<LichHoc>();
            string kq = "";
            int t = 0;
            var dt = helper.ExcuteProcedureToDataTable(out kq,"sp_SearchLichHoc",
                "@MaLichHoc", lichHoc.IDLichHoc,
                "@MaLopPhan", lichHoc.IDLopPhan,
                "@NgayHoc", lichHoc.NgayHoc
            );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                string iDLopPhan = row["maLopPhan"].ToString();
                DateTime ngayHoc = Convert.ToDateTime(row["NgayHoc"]);
                int soTiet = Convert.ToInt32(row["soTiet"]);
                string phongHoc = row["phongHoc"].ToString();
                string iDLichHoc = row["maLichHoc"].ToString();
                LichHoc lh = new LichHoc(iDLopPhan, ngayHoc, soTiet, phongHoc, iDLichHoc);
                list.Add(lh);
            }
            return list;
        }
    }
}
