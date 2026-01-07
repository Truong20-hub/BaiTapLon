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
    public class ChiTietBangDiemDAL: IChiTietBangDiemDAL
    {
        private IDatabaseHelper helper;
        public ChiTietBangDiemDAL(IDatabaseHelper _helper)
        {
            this.helper = _helper;
        }
        public (string k, bool h) createIDCTBD(ChiTietBangDiem chiTietBangDiem)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemChiTietBangDiem",
                "@MaCTBD", chiTietBangDiem.IDCTBD,
                "@MaBD", chiTietBangDiem.IDBD,
                "@MaSinhVien", chiTietBangDiem.IDSV,
                "@MaLopHP", chiTietBangDiem.IDLopHP,
                "@MaDD", chiTietBangDiem.IDĐĐ,
                "@Diem", chiTietBangDiem.Diem,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã chi tiết bảng điểm đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Mã bảng điểm không tồn tại";
                h = false;
            }
            else if (Exe == "3")
            {
                k = "Mã sinh viên không tồn tại";
                h = false;
            }
            else if (Exe == "4")
            {
                k = "Mã lớp học phần không tồi tại";
                h = false;
            }
            else if (Exe == "5")
            {
                k = "Mã đầu điểm không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) updateCTBD(ChiTietBangDiem chiTietBangDiem)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_SuaChiTietBangDiem",
                "@MaCTBD", chiTietBangDiem.IDCTBD,
                "@MaBD", chiTietBangDiem.IDBD,
                "@MaSinhVien", chiTietBangDiem.IDSV,
                "@MaLopHP", chiTietBangDiem.IDLopHP,
                "@MaDD", chiTietBangDiem.IDĐĐ,
                "@Diem", chiTietBangDiem.Diem,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã chi tiết bảng điểm không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) deleteCTBD(string idCTBD)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_XoaChiTietBangDiem",
                "@MaCTBD", idCTBD,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã chi tiết bảng điểm không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<ChiTietBangDiem> getAllCTBD()
        {
            List<ChiTietBangDiem> list = new List<ChiTietBangDiem>();
            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllChiTietBangDiem");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                ChiTietBangDiem ctbd =new ChiTietBangDiem(
                    row["MaCTBD"].ToString(),
                    row["MaBD"].ToString(),
                    row["MaSinhVien"].ToString(),
                    row["MaLopHP"].ToString(),
                    row["MaDD"].ToString(),
                    float.Parse(row["Diem"].ToString())
                );
                list.Add(ctbd);
            }
            return list;
        }
        public List<ChiTietBangDiem> searchCTBD(ChiTietBangDiem chiTietBangDiem)
        {
            List<ChiTietBangDiem> list = new List<ChiTietBangDiem>();
            string kq="";
            int t = 0;
            var dt = helper.ExcuteProcedureToDataTable(out kq,"sp_SearchChiTietBangDiem",
                "@MaSinhVien",chiTietBangDiem.IDSV,
                "@MaLopHP",chiTietBangDiem.IDCTBD,
                "@MaDD",chiTietBangDiem.IDĐĐ,
                "@Diem",chiTietBangDiem.Diem
            );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                ChiTietBangDiem ctbd = new ChiTietBangDiem(
                    row["MaCTBD"].ToString(),
                    row["MaBD"].ToString(),
                    row["MaSinhVien"].ToString(),
                    row["MaLopHP"].ToString(),
                    row["MaDD"].ToString(),
                    float.Parse(row["Diem"].ToString())
                );
                list.Add(ctbd);
            }
            return list;
        }
    }
}
