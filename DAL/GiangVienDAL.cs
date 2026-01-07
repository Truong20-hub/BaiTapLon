using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL_.helper;
using Model_;
namespace DAL_
{
    public class GiangVienDAL: IGiangVienDAL
    {
        private IDatabaseHelper helper;
        public GiangVienDAL(IDatabaseHelper helper)
        {
            this.helper = helper;
        }
        public (string k, bool h) createGiangVien (GiangVien giangVien)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemGiangVien",
                "@MaGiangVien", giangVien.IDGV,
                "@MaNguoiDung", giangVien.IDNguoiDung,
                "@TenGiangVien", giangVien.TenGiangVien,
                "@GioiTinh", giangVien.GioiTinh,
                "@NgaySinh", giangVien.NgaySinh,
                "@TrinhDo", giangVien.TrinhDo,
                "@Khoa", giangVien.Khoa,
                "@Mon", giangVien.Mon,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã giảng viên đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Người dùng không tồn tại";
                h= false;
            }
            else if (Exe == "3")
            {
                k = "Người dùng đã được gán cho giảng viên khác";
                h = false;
            }
            else if (Exe == "4")
            {
                k = "Khoa không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return(k, h);
        }
        public (string k, bool h) updateGiangVien(GiangVien giangVien)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemGiangVien",
                "@MaGiangVien", giangVien.IDGV,
                "@MaNguoiDung", giangVien.IDNguoiDung,
                "@TenGiangVien", giangVien.TenGiangVien,
                "@GioiTinh", giangVien.GioiTinh,
                "@NgaySinh", giangVien.NgaySinh,
                "@TrinhDo", giangVien.TrinhDo,
                "@Khoa", giangVien.Khoa,
                "@Mon", giangVien.Mon,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã giảng viên đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Người dùng không tồn tại";
                h = false;
            }
            else if (Exe == "3")
            {
                k = "Người dùng đã được gán cho giảng viên khác";
                h = false;
            }
            else if (Exe == "4")
            {
                k = "Khoa không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) deleteGiangVien(string iDGV)
        {
            string k = "";
            bool h = false;

            var Exe = helper.ExcuteNonQueryProcedure(
                "sp_XoaGiangVien",
                "@MaGiangVien", iDGV,
                "@Result", 0
            );

            if (Exe == "1")
            {
                k = "Mã giảng viên không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa giảng viên thành công";
                h = true;
            }

            return (k, h);
        }
        public List<GiangVien> Search(GiangVien giangVien)
        {
            List<GiangVien> list = new List<GiangVien>();
            string kq = "";
            int t = 0;

            var dt = helper.ExcuteProcedureToDataTable(
                out kq,
                "sp_SearchGiangVien",
                "@MaGiangVien", giangVien.IDGV,
                "@MaNguoiDung", giangVien.IDNguoiDung,
                "@TenGiangVien", giangVien.TenGiangVien,
                "@GioiTinh", giangVien.GioiTinh,
                "@NgaySinh", giangVien.NgaySinh,
                "@TrinhDo", giangVien.TrinhDo,
                "@Khoa", giangVien.Khoa,
                "@Mon", giangVien.Mon
            );

            foreach (System.Data.DataRow row in dt.Rows)
            {
                GiangVien gv = new GiangVien(
                    row["maGiangVien"].ToString(),
                    row["MaNguoiDung"].ToString(),
                    row["TenGiangVien"].ToString(),
                    row["GioiTinh"].ToString(),
                    Convert.ToDateTime(row["NgaySinh"]),
                    row["TrinhDo"].ToString(),
                    row["Khoa"].ToString(),
                    row["Mon"].ToString(),
                    new List<LopHoc>()
                );

                list.Add(gv);
            }

            t = dt.Rows.Count;
            return list;
        }
        public List<GiangVien> getAllGiangVien()
        {
            List<GiangVien> list = new List<GiangVien>();

            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllGiangVien");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                GiangVien gv = new GiangVien(
                    row["maGiangVien"].ToString(),
                    row["MaNguoiDung"].ToString(),
                    row["TenGiangVien"].ToString(),
                    row["GioiTinh"].ToString(),
                    Convert.ToDateTime(row["NgaySinh"]),
                    row["TrinhDo"].ToString(),
                    row["Khoa"].ToString(),
                    row["Mon"].ToString(),
                    new List<LopHoc>()
                );

                list.Add(gv);
            }

            return list;
        }

    }
}
