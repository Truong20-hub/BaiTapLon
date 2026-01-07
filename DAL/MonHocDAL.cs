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
    public class MonHocDAL: IMonHocDAL
    {
        private IDatabaseHelper helper;
        public MonHocDAL(IDatabaseHelper _helper)
        {
            this.helper = _helper;
        }
        public (string k, bool h) createMonHoc(MonHoc monHoc)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemMonHoc",
                "@MaMonHoc", monHoc.IDMonHoc,
                "@SoTinChi", monHoc.SoTinChi,
                "@SoTiet", monHoc.SoTiet,
                "@ThuTuUtien", monHoc.ThuTuUuTien,
                "@TenMonHoc", monHoc.TenMonHoc,
                "@MaNganh", monHoc.IDNganh,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã môn học đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Mã ngành không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) updateMonHoc(MonHoc monHoc)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_SuaMonHoc",
                "@MaMonHoc", monHoc.IDMonHoc,
                "@SoTinChi", monHoc.SoTinChi,
                "@SoTiet", monHoc.SoTiet,
                "@ThuTuUtien", monHoc.ThuTuUuTien,
                "@TenMonHoc", monHoc.TenMonHoc,
                "@MaNganh", monHoc.IDNganh,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã môn học không tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Mã ngành không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) deleteMonHoc(string iDMonHoc)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_XoaMonHoc",
                "@MaMonHoc", iDMonHoc,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã môn học không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<MonHoc> getAllMonHoc()
        {
            List<MonHoc> list = new List<MonHoc>();
            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllMonHoc");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                MonHoc monHoc = new MonHoc
                (
                    row["MaMonHoc"].ToString(),
                    Convert.ToInt32(row["SoTinChi"]),
                    Convert.ToInt32(row["SoTiet"]),
                    Convert.ToInt32(row["ThuTuUtien"]),
                    row["TenMonHoc"].ToString(),
                    row["MaNganh"].ToString()
                );
                list.Add(monHoc);
            }
            return list;
        }
        public List<MonHoc> searchMonHoc(MonHoc monHoc)
        {
            List<MonHoc> list = new List<MonHoc>();
            string kq = "";
            int t = 0;
            var dt = helper.ExcuteProcedureToDataTable(out kq, "sp_SearchMonHoc",
                "@MaMonHoc", monHoc.IDMonHoc,
                "@TenMonHoc", monHoc.TenMonHoc,
                "@MaNganh", monHoc.IDNganh
            );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                MonHoc mh = new MonHoc
                (
                    row["MaMonHoc"].ToString(),
                    Convert.ToInt32(row["SoTinChi"]),
                    Convert.ToInt32(row["SoTiet"]),
                    Convert.ToInt32(row["ThuTuUtien"]),
                    row["TenMonHoc"].ToString(),
                    row["MaNganh"].ToString()
                );
                list.Add(mh);
            }
            return list;
        }
    }
}
