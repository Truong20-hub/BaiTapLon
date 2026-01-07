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
    public class DangLyHocPhanDAL : IDangKyHocPhanDAL
    {
        private IDatabaseHelper helper;
        public DangLyHocPhanDAL(IDatabaseHelper _helper)
        {
            this.helper = _helper;
        }
        public (string k, bool h) createDKHP(DangKyHocPhan dangKyHocPhan)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemDangKyHocPhan",
                "@MaSV", dangKyHocPhan.IDSinhVien,
                "@MaLopHP", dangKyHocPhan.IDLopHP,
                "@NgayDK", dangKyHocPhan.NgayDK,
                "@TrangThaiDK", dangKyHocPhan.TrangThaiDK,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Sinh viên không tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Lớp học phần không tồn tại";
                h = false;
            }
            else if (Exe == "3")
            {
                k = "Đã đăng ký học phần này rồi";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) updateDKHP(DangKyHocPhan dangKyHocPhan)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_CapNhatDangKyHocPhan",
                "@MaSV", dangKyHocPhan.IDSinhVien,
                "@MaLopHP", dangKyHocPhan.IDLopHP,
                "@NgayDK", dangKyHocPhan.NgayDK,
                "@TrangThaiDK", dangKyHocPhan.TrangThaiDK,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Đăng ký học phần không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public List<DangKyHocPhan> getAllDKHP()
        {
            List<DangKyHocPhan> list = new List<DangKyHocPhan>();
            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllDangKyHocPhan");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                DangKyHocPhan dangKyHocPhan = new DangKyHocPhan(
                    row["MaSV"].ToString(),
                    row["MaLopHP"].ToString(),
                    Convert.ToDateTime(row["NgayDK"]),
                    row["TrangThaiDK"].ToString()
                );
                list.Add(dangKyHocPhan);
            }
            return list;
        }
        public (string k, bool h) deleteDKHP(string iDSinhVien, string iDLopHP)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_XoaDangKyHocPhan",
                "@MaSV", iDSinhVien,
                "@MaLopHP", iDLopHP,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Đăng ký học phần không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<DangKyHocPhan> searchDKHP(DangKyHocPhan dangKyHocPhan)
        {
            List<DangKyHocPhan> list = new List<DangKyHocPhan>();
            string kq = "";
            int t= 0;
            var dt = helper.ExcuteProcedureToDataTable(out kq, "sp_SearchDangKyHocPhan",
                "@MaSV", dangKyHocPhan.IDSinhVien,
                "@MaLopHP", dangKyHocPhan.IDLopHP
            );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                DangKyHocPhan dkhp = new DangKyHocPhan(
                    row["maSV"].ToString(),
                    row["maLopHP"].ToString(),
                    Convert.ToDateTime(row["ngayDK"]),
                    row["TrangThaiDK"].ToString()
                );
                list.Add(dkhp);
            }
            return list;
        }
    }
}
