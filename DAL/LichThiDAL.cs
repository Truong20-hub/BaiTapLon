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
    public class LichThiDAL : ILichThiDAL
    {
        private IDatabaseHelper _helper;
        public LichThiDAL(IDatabaseHelper helper)
        {
            _helper = helper;
        }
        public (string k, bool h) createLichThi(LichThi lichThi)
        {
            string k = "";
            bool h = false;
            var Exe = _helper.ExcuteNonQueryProcedure("sp_ThemLichThi",
                "@MaLichThi", lichThi.IDLichThi,
                "@MaLopPhan", lichThi.IDLopPhan,
                "@NgayThi", lichThi.NgayThi,
                "@GioThi", lichThi.GioThi,
                "@MaPhong", lichThi.IDPhong,
                "@PhongHoc", lichThi.PhongHoc,
                "@HinhThucThi", lichThi.HinhThucThi,
                "@GiamThi", lichThi.GiamThi,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã lịch thi đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Mã lớp phần không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) updateLichThi(LichThi lichThi)
        {
            string k = "";
            bool h = false;
            var Exe = _helper.ExcuteNonQueryProcedure("sp_SuaLichThi",
                "@MaLichThi", lichThi.IDLichThi,
                "@MaLopPhan", lichThi.IDLopPhan,
                "@NgayThi", lichThi.NgayThi,
                "@GioThi", lichThi.GioThi,
                "@MaPhong", lichThi.IDPhong,
                "@PhongHoc", lichThi.PhongHoc,
                "@HinhThucThi", lichThi.HinhThucThi,
                "@GiamThi", lichThi.GiamThi,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã lịch thi không tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Mã lớp phần không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public List<LichThi> getAllLichThi()
        {
            List<LichThi> list = new List<LichThi>();
            var dt = _helper.ExcuteProcedureToDataTable("sp_GetAllLichThi");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                LichThi lt = new LichThi(
                    row["maLichThi"].ToString(),
                    row["MaLopPhan"].ToString(),
                    Convert.ToDateTime(row["NgayThi"]),
                    row["gioThi"].ToString(),
                    row["maPhong"].ToString(),
                    row["phongHoc"].ToString(),
                    row["hinhThucThi"].ToString(),
                    row["GiamThi"].ToString()
                );
                list.Add(lt);
            }
            return list;
        }
        public (string k, bool h) deleteLichThi(string iDLichThi)
        {
            string k = "";
            bool h = false;
            var Exe = _helper.ExcuteNonQueryProcedure("sp_XoaLichThi",
                "@MaLichThi", iDLichThi,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã lịch thi không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<LichThi> searchLichThi(LichThi lichThi)
        {
            List<LichThi> list = new List<LichThi>();
            string kq="";
            int t= 0;
            var dt = _helper.ExcuteProcedureToDataTable(out kq,"sp_SearchLichThi",
                "@MaLichThi", lichThi.IDLichThi,
                "@MaLopPhan", lichThi.IDLopPhan,
                "@NgayThi", lichThi.NgayThi == DateTime.MinValue ? null : (DateTime?)lichThi.NgayThi
            );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                LichThi lt = new LichThi(
                    row["maLichThi"].ToString(),
                    row["MaLopPhan"].ToString(),
                    Convert.ToDateTime(row["NgayThi"]),
                    row["gioThi"].ToString(),
                    row["maPhong"].ToString(),
                    row["phongHoc"].ToString(),
                    row["hinhThucThi"].ToString(),
                    row["GiamThi"].ToString()
                );
                list.Add(lt);
            }
            return list;
        }
    }
}
