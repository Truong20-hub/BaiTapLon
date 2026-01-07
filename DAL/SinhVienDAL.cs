using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL_.helper;
using Model_;
using System.Data;


namespace DAL_
{
    public class SinhVienDAL: ISinhVienDAL
    {
        private IDatabaseHelper helper;
        public SinhVienDAL(IDatabaseHelper helper)
        {
            this.helper = helper;
        }
        public (string k, bool h) createSinhVien(SinhVien sinhVien)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemSinhVien",
                "@MaSV", sinhVien.IDSinhVien,
                "@MaNguoiDung", sinhVien.MaNguoiDung,
                "@HoTen", sinhVien.HoTen,
                "@GioiTinh", sinhVien.GioiTinh,
                "@NgaySinh", sinhVien.NgaySinh,
                "@NganhHoc", sinhVien.NganhHoc,
                "@KhoaHoc", sinhVien.KhoaHoc,
                "@MaLopHC", sinhVien.MaLopHC,
                "@TrangThai", sinhVien.TrangThai,
                "@Resuilt", 0
            );
            if (Exe == "1")
            {
                k = "Mã sinh viên đã tồn tại";
                h = false;
            }
            if (Exe == "2")
            {
                k = "Người dùng không tồn tại";
                h = false;
            }
            else if (Exe == "3")
            {
                k = "Người dùng đã được gán cho sinh viên khác";
                h = false;
            }
            else if (Exe == "4")
            {
                k = "Ngành không tồn tại";
                h = false;
            }
            else if (Exe == "5")
            {
                k = "Lớp hành chính không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k, h);
        }

        public (string k, bool h) updateSinhVien(SinhVien sinhVien)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_SuaSinhVien",
                "@MaSV", sinhVien.IDSinhVien,
                "@MaNguoiDung", sinhVien.MaNguoiDung,
                "@HoTen", sinhVien.HoTen,
                "@GioiTinh", sinhVien.GioiTinh,
                "@NgaySinh", sinhVien.NgaySinh,
                "@NganhHoc", sinhVien.NganhHoc,
                "@KhoaHoc", sinhVien.KhoaHoc,
                "@MaLopHC", sinhVien.MaLopHC,
                "@TrangThai", sinhVien.TrangThai,
                "@Resuilt", 0
            );
            if (Exe == "1")
            {
                k = "Mã sinh viên đã tồn tại";
                h = false;
            }
            if (Exe == "2")
            {
                k = "Người dùng không tồn tại";
                h = false;
            }
            else if (Exe == "3")
            {
                k = "Người dùng đã được gán cho sinh viên khác";
                h = false;
            }
            else if (Exe == "4")
            {
                k = "Ngành không tồn tại";
                h = false;
            }
            else if (Exe == "5")
            {
                k = "Lớp hành chính không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) deleteSinhVien(string iDSinhVien)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_XoaSinhVien",
                "@MaSV", iDSinhVien,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã sinh viên không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<SinhVien> Search(SinhVien sinhVien)
        {
            List<SinhVien> list = new List<SinhVien>();
            string kq = "";
            int t = 0;
            var dt = helper.ExcuteProcedureToDataTable(out kq, "sp_SearchSinhVien",
                "@MaSV", sinhVien.IDSinhVien,
                "@MaNguoiDung", sinhVien.MaNguoiDung,
                "@Hoten", sinhVien.HoTen,
                "@GioiTinh", sinhVien.GioiTinh,
                "@NgaySinh", sinhVien.NgaySinh,
                "@NganhHoc", sinhVien.NganhHoc,
                "@KhoaHoc", sinhVien.KhoaHoc,
                "@MaLopHC", sinhVien.MaLopHC,
                "@TrangThai", sinhVien.TrangThai
            );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                SinhVien sv = new SinhVien(
                row["MaSV"].ToString(),
                row["MaNguoiDung"].ToString(),
                row["Hoten"].ToString(),
                row["GioiTinh"].ToString(),
                Convert.ToDateTime(row["NgaySinh"]),
                row["NganhHoc"].ToString(),
                row["KhoaHoc"].ToString(),
                row["MaLopHC"].ToString(),
                row["TrangThai"].ToString()
                );
                list.Add(sv);
            }
            t = dt.Rows.Count;
            return list;
        }
        public List<SinhVien> getAllSV()
        {
            List<SinhVien> list = new List<SinhVien>();
            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllSinhVien");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                SinhVien sv = new SinhVien(
                row["MaSV"].ToString(),
                row["MaNguoiDung"].ToString(),
                row["Hoten"].ToString(),
                row["GioiTinh"].ToString(),
                Convert.ToDateTime(row["NgaySinh"]),
                row["NganhHoc"].ToString(),
                row["KhoaHoc"].ToString(),
                row["MaLopHC"].ToString(),
                row["TrangThai"].ToString()
                );

                list.Add(sv);
            }
            return list;
        }
    }
}

    

