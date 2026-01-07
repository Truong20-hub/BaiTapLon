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
    public class DiemDanhDAL: IDiemDanhDAL
    {
        private IDatabaseHelper helper;
        public DiemDanhDAL(IDatabaseHelper _helper)
        {
            this.helper = _helper;
        }
        public (string k, bool h) createBD(Model_.DiemDanh diemDanh)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemDiemDanh",
                "@MaDiemDanh", diemDanh.IDDiemDanh,
                "@NgayDiemDanh", diemDanh.NgayDiemDanh,
                "@MaSinhVien", diemDanh.IDSinhVien,
                "@MaLichHoc", diemDanh.IDLichHoc,
                "@TrangThai", diemDanh.TrangThai,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã điểm danh đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Mã sinh viên không tồn tại";
                h = false;
            }
            else if (Exe == "3")
            {
                k = "Mã lịch học không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) updateBD(Model_.DiemDanh diemDanh)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_SuaDiemDanh",
                "@MaDiemDanh", diemDanh.IDDiemDanh,
                "@NgayDiemDanh", diemDanh.NgayDiemDanh,
                "@MaSinhVien", diemDanh.IDSinhVien,
                "@MaLichHoc", diemDanh.IDLichHoc,
                "@TrangThai", diemDanh.TrangThai,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã điểm danh không tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Mã sinh viên không tồn tại";
                h = false;
            }
            else if (Exe == "3")
            {
                k = "Mã lịch học không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public List<DiemDanh> getAllDD()
        {
            List<Model_.DiemDanh> list = new List<Model_.DiemDanh>();
            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllDiemDanh");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                Model_.DiemDanh diemDanh = new Model_.DiemDanh(
                    row["MaDiemDanh"].ToString(),
                    Convert.ToDateTime(row["NgayDiemDanh"]),
                    row["MaSinhVien"].ToString(),
                    row["MaLichHoc"].ToString(),
                    row["TrangThai"].ToString()
                );
                list.Add(diemDanh);
            }
            return list;
        }
        public (string k, bool h) deleteBD(string idDiemDanh)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_XoaDiemDanh",
                "@MaDiemDanh", idDiemDanh,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã điểm danh không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<DiemDanh> searchBD(DiemDanh diemDanh)
        {
            List<DiemDanh> list = new List<DiemDanh>();
            string kq = "";
            int i = 0;
            var dt = helper.ExcuteProcedureToDataTable(out kq, "sp_SearchDiemDanh",
                "@MaSinhVien", diemDanh.IDSinhVien,
                "@NgayDiemDanh", diemDanh.NgayDiemDanh,
                "@MaLichHoc", diemDanh.IDLichHoc
            );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                Model_.DiemDanh dd = new Model_.DiemDanh(
                    row["maDiemDanh"].ToString(),
                    Convert.ToDateTime(row["NgayDiemDanh"]),
                    row["maSinhVien"].ToString(),
                    row["maLichHoc"].ToString(),
                    row["trangThai"].ToString()
                );
                list.Add(dd);
            }
            return list;
        }
    }
}
