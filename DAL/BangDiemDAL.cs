using DAL_.helper;
using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_
{
    public class BangDiemDAL:IBangDiem
    {
        private IDatabaseHelper helper;
        public BangDiemDAL(IDatabaseHelper _helper)
        {
            this.helper = _helper;
        }
        public (string k, bool h) createBD(BangDiem bangDiem)
        {
            string k ="";
            bool h = false;
            var Exe= helper.ExcuteNonQueryProcedure("sp_ThemBangDiem",
                "@MaBD", bangDiem.IDBD,
                "@MaSinhVien", bangDiem.IDSinhVien,
                "@MaMonHoc", bangDiem.IDMonHoc,
                "@MaLopHP", bangDiem.IDLopHP,
                "@MaDD", bangDiem.IDDauDiem,
                "@Diem", bangDiem.Diem,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã điểm đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Mã sinh viên không tồn tại";
                h = false;
            }
            else if (Exe == "3")
            {
                k = "Mã môn học không tồn tại";
                h = false;
            }
            else if (Exe == "4")
            {
                k = "Lớp học phần không tồn tại";
                h = false;
            }
            else if (Exe == "5")
            {
                k = "Đầu điểm không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k,h);
        }
        public (string k, bool h) updateBD(BangDiem bangDiem)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_CapNhatBangDiem",
                "@MaBD", bangDiem.IDBD,
                "@MaSinhVien", bangDiem.IDSinhVien,
                "@MaMonHoc", bangDiem.IDMonHoc,
                "@MaLopHP", bangDiem.IDLopHP,
                "@MaDD", bangDiem.IDDauDiem,
                "@Diem", bangDiem.Diem,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã điểm không tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Mã sinh viên không tồn tại";
                h = false;
            }
            else if (Exe == "3")
            {
                k = "Mã môn học không tồn tại";
                h = false;
            }
            else if (Exe == "4")
            {
                k = "Lớp học phần không tồn tại";
                h = false;
            }
            else if (Exe == "5")
            {
                k = "Đầu điểm không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k,h);
        }
        public List<BangDiem> getAllBD()
        {
            List<BangDiem> list = new List<BangDiem>();
            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllBangDiem");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                BangDiem bd = new BangDiem(
                    row["MaBD"].ToString(),
                    row["MaSinhVien"].ToString(),
                    row["MaMonHoc"].ToString(),
                    row["MaLopHP"].ToString(),
                    row["MaDD"].ToString(),
                    float.Parse( row["Diem"].ToString())
                );
                list.Add(bd);
            }
            return list;
        }
        public (string k, bool h) deleteBD(string idBD)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_XoaBangDiem",
                "@MaBD", idBD,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã điểm không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<BangDiem>  Search(BangDiem bangDiem)
        {
            List<BangDiem> list = new List<BangDiem>();
            string kq = "";
            int t = 0;
            var dt = helper.ExcuteProcedureToDataTable(out kq, "sp_SearchBangDiem",
                "@MaBD", bangDiem.IDBD,
                "@MaSinhVien", bangDiem.IDSinhVien,
                "@MaMonHoc", bangDiem.IDMonHoc,
                "@MaLopHP", bangDiem.IDLopHP,
                "@MaDD", bangDiem.IDDauDiem,
                "@Diem", bangDiem.Diem
                );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                BangDiem bd = new BangDiem(
                    row["MaBD"].ToString(),
                    row["MaSinhVien"].ToString(),
                    row["MaMonHoc"].ToString(),
                    row["MaLopHP"].ToString(),
                    row["MaDD"].ToString(),
                    float.Parse(row["Diem"].ToString())
                );
                list.Add(bd);
            }
            t = dt.Rows.Count;
            return list;
        }
    }
}
