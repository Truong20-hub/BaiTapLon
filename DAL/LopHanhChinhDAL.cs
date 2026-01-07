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
    public class LopHanhChinhDAL:ILopHanhChinhDAL
    {
        private IDatabaseHelper helper;
        public LopHanhChinhDAL(IDatabaseHelper helper)
        {
            this.helper = helper;
        }
        public (string k, bool h) createLopHC(LopHanhChinh lopHanhChinh)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemLopHanhChinh",
                "@MaLopHC", lopHanhChinh.IDLopHC,
                "@TenLop", lopHanhChinh.TenLopHC,
                "@KhoaHoc", lopHanhChinh.KhoaHoc,
                "@NganhHoc", lopHanhChinh.NganhHoc,
                "@SISO", lopHanhChinh.SiSo,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã lớp đã tồn tại";
                h = false;
            }
            else if(Exe == "2")
            {
                k = "Ngành không tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return(k, h);
        }
        public (string k, bool h) updateLopHC(LopHanhChinh lopHanhChinh)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_SuaLopHanhChinh",
                "@MaLopHC", lopHanhChinh.IDLopHC,
                "@TenLop", lopHanhChinh.TenLopHC,
                "@KhoaHoc", lopHanhChinh.KhoaHoc,
                "@NganhHoc", lopHanhChinh.NganhHoc,
                "@SISO", lopHanhChinh.SiSo,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã lớp đã tồn tại";
                h = false;
            }
            else if (Exe == "2")
            {
                k = "Ngành không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) deleteLopHC(string iDLopHC)
        {
            string k = "";
            bool h = false;

            var Exe = helper.ExcuteNonQueryProcedure(
                "sp_XoaLopHanhChinh",
                "@MaLopHC", iDLopHC,
                "@Result", 0
            );

            if (Exe == "1")
            {
                k = "Mã lớp hành chính không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa lớp hành chính thành công";
                h = true;
            }

            return (k, h);
        }

        public List<LopHanhChinh> Search(LopHanhChinh lopHanhChinh)
        {
            List<LopHanhChinh> list = new List<LopHanhChinh>();
            string kq = "";
            int t = 0;

            var dt = helper.ExcuteProcedureToDataTable(
                out kq,
                "sp_SearchLopHanhChinh",
                "@MaLopHC", lopHanhChinh.IDLopHC,
                "@TenLop", lopHanhChinh.TenLopHC,
                "@KhoaHoc", lopHanhChinh.KhoaHoc,
                "@NganhHoc", lopHanhChinh.NganhHoc,
                "@SISO", lopHanhChinh.SiSo
            );

            foreach (System.Data.DataRow row in dt.Rows)
            {
                LopHanhChinh lhc = new LopHanhChinh(
                    row["MaLopHC"].ToString(),
                    row["TenLop"].ToString(),
                    row["KhoaHoc"].ToString(),
                    row["NganhHoc"].ToString(),
                    row["SISO"] == DBNull.Value ? 0 : Convert.ToInt32(row["SISO"]),
                    new List<SinhVien>()
                );

                list.Add(lhc);
            }

            t = dt.Rows.Count;
            return list;
        }
        public List<LopHanhChinh> getAllLopHC()
        {
            List<LopHanhChinh> list = new List<LopHanhChinh>();

            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllLopHanhChinh");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                LopHanhChinh lhc = new LopHanhChinh(
                    row["MaLopHC"].ToString(),
                    row["TenLop"].ToString(),
                    row["KhoaHoc"].ToString(),
                    row["NganhHoc"].ToString(),
                    row["SISO"] == DBNull.Value ? 0 : Convert.ToInt32(row["SISO"]),
                    new List<SinhVien>()
                );

                list.Add(lhc);
            }

            return list;
        }

    }
}
