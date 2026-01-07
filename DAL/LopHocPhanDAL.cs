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
    public class LopHocPhanDAL:ILopHocPhanDAL
    {
        private IDatabaseHelper helper;
        public LopHocPhanDAL(IDatabaseHelper helper)
        {
            this.helper = helper;
        }
        public (string k, bool h) createLopHocPhan (LopHocPhan lopHocPhan)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemLopHocPhan",
                "@MaLopHP", lopHocPhan.IDLopHP,
                "@TenLop", lopHocPhan.TenLop,
                "@MaMonHoc", lopHocPhan.IDMonHoc,
                "@MaGiangVien", lopHocPhan.IDGiangVien,
                "@ThoiGianMo", lopHocPhan.ThoiGianMo,
                "@ThoiGianDong", lopHocPhan.ThoiGianDong,
                "@SoLuongSinhVien", lopHocPhan.SoLuongSinhVien,
                "@ThuTuUuTien", lopHocPhan.ThuTuUuTien,
                "@Result",0
            );
            if (Exe == "1")
            {
                k = "Mã lớp học phần đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Môn học đã tồn tại";
                h = false; 
            }
            else if (Exe == "3")
            {
                k = "Giảng viên không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k,h);
        }

        public (string k, bool h) updateLopHocPhan(LopHocPhan lopHocPhan)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemLopHocPhan",
                "@MaLopHP", lopHocPhan.IDLopHP,
                "@TenLop", lopHocPhan.TenLop,
                "@MaMonHoc", lopHocPhan.IDMonHoc,
                "@MaGiangVien", lopHocPhan.IDGiangVien,
                "@ThoiGianMo", lopHocPhan.ThoiGianMo,
                "@ThoiGianDong", lopHocPhan.ThoiGianDong,
                "@SoLuongSinhVien", lopHocPhan.SoLuongSinhVien,
                "@ThuTuUuTien", lopHocPhan.ThuTuUuTien

            );
            if (Exe == "1")
            {
                k = "Mã lớp học phần đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Môn học đã tồn tại";
                h = false;
            }
            else if (Exe == "3")
            {
                k = "Giảng viên không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) deleteLopHocPhan(string iDLopHP)
        {
            string k = "";
            bool h = false;

            var Exe = helper.ExcuteNonQueryProcedure(
                "sp_XoaLopHocPhan",
                "@MaLopHP", iDLopHP,
                "@Result", 0
            );

            if (Exe == "1")
            {
                k = "Mã lớp học phần không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa lớp học phần thành công";
                h = true;
            }

            return (k, h);
        }
        public List<LopHocPhan> Search(LopHocPhan lopHocPhan)
        {
            List<LopHocPhan> list = new List<LopHocPhan>();
            string kq = "";
            int t = 0;

            var dt = helper.ExcuteProcedureToDataTable(
                out kq,
                "sp_SearchLopHocPhan",
                "@MaLopHP", lopHocPhan.IDLopHP,
                "@TenLop", lopHocPhan.TenLop,
                "@MaMonHoc", lopHocPhan.IDMonHoc,
                "@MaGiangVien", lopHocPhan.IDGiangVien,
                "@ThoiGianMo", lopHocPhan.ThoiGianMo,
                "@ThoiGianDong", lopHocPhan.ThoiGianDong,
                "@SoLuongSinhVien", lopHocPhan.SoLuongSinhVien,
                "@ThuTuUuTien", lopHocPhan.ThuTuUuTien
            );

            foreach (System.Data.DataRow row in dt.Rows)
            {
                LopHocPhan lhp = new LopHocPhan(
                    row["maLopHP"].ToString(),
                    row["tenLop"].ToString(),
                    row["MaMonHoc"].ToString(),
                    row["maGiangVien"].ToString(),
                    Convert.ToDateTime(row["ThoigianMo"]),
                    Convert.ToDateTime(row["ThoigianDong"]),
                    Convert.ToInt32(row["SoLuongSinhVien"]),
                    row["ThuTuUuTien"].ToString()
                    
                );

                list.Add(lhp);
            }

            t = dt.Rows.Count;
            return list;
        }
        public List<LopHocPhan> getAllLopHocPhan()
        {
            List<LopHocPhan> list = new List<LopHocPhan>();

            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllLopHocPhan");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                LopHocPhan lhp = new LopHocPhan(
                    row["maLopHP"].ToString(),
                    row["tenLop"].ToString(),
                    row["MaMonHoc"].ToString(),
                    row["maGiangVien"].ToString(),
                    Convert.ToDateTime(row["ThoigianMo"]),
                    Convert.ToDateTime(row["ThoigianDong"]),
                    Convert.ToInt32(row["SoLuongSinhVien"]),
                    row["ThuTuUuTien"].ToString()

                );
                list.Add(lhp);
            }

            return list;
        }

    }
}
