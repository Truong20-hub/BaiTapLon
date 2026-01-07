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
    public class NganhDAL: INganhDAL
    {
        private IDatabaseHelper helper;
        public NganhDAL(IDatabaseHelper helper)
        {
            this.helper = helper;
        }
        public (string k, bool h) createNganh (Nganh nganh)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemNganh",
                "@MaNganh", nganh.IDNganh,
                "@TenNganh", nganh.TenNganh,
                "@MaKhoa", nganh.MaKhoa,
                "@TrinhDoDaoTao", nganh.TrinhDoDaoTao,
                "@SoTinChi", nganh.SoTinChi,
                "@Result",0
            );
            if (Exe == "1")
            {
                k = "Mã ngành đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Khoa không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) updateNganh(Nganh nganh)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_SuaNganh",
                "@MaNganh", nganh.IDNganh,
                "@TenNganh", nganh.TenNganh,
                "@MaKhoa", nganh.MaKhoa,
                "@TrinhDoDaoTao", nganh.TrinhDoDaoTao,
                "@SoTinChi", nganh.SoTinChi,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã ngành đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
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
        public (string k, bool h) deleteNganh(string iDNganh)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_XoaNganh",
                "@MaSV", iDNganh,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã ngành không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<Nganh> Search(Nganh nganh)
        {
            List<Nganh> list = new List<Nganh>();
            string kq = "";
            int t = 0;

            var dt = helper.ExcuteProcedureToDataTable(
                out kq,
                "sp_SearchNganh",
                "@maNganh", nganh.IDNganh,
                "@tenNganh", nganh.TenNganh,
                "@maKhoa", nganh.MaKhoa,
                "@trinhDoDaoTao", nganh.TrinhDoDaoTao,
                "@soTinChi", nganh.SoTinChi
            );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                Nganh n = new Nganh(
                    row["maNganh"].ToString(),
                    row["tenNganh"].ToString(),
                    row["maKhoa"].ToString(),
                    row["trinhDoDaoTao"].ToString(),
                    Convert.ToInt32(row["soTinChi"])
                );

                list.Add(n);
            }

            t = dt.Rows.Count;
            return list;
        }
        public List<Nganh> getAllNganh()
        {
            List<Nganh> list = new List<Nganh>();

            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllNganh");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                Nganh n = new Nganh(
                    row["maNganh"].ToString(),
                    row["tenNganh"].ToString(),
                    row["maKhoa"].ToString(),
                    row["trinhDoDaoTao"].ToString(),
                    Convert.ToInt32(row["soTinChi"])
                );

                list.Add(n);
            }

            return list;
        }


    }
}
