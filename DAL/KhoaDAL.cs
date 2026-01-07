using DAL_.helper;
using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_
{
    public class KhoaDAL : IKhoaRepostiry
    {
        private IDatabaseHelper helper;
        public KhoaDAL(IDatabaseHelper _helper)
        {
            this.helper = _helper;
        }
        public (bool k, string i) createKhoa(Khoa khoa)
        {
            bool k = false;
            string msg = "";
            try
            {
                var result = helper.ExcuteNonQueryProcedure("sp_ThemKhoa",
                             "@MaKhoa", khoa.IDKhoa,
                             "@TenKhoa", khoa.TenKhoa,
                             "@SDT", khoa.SDT,
                                "@Email", khoa.Email,
                                "@TruongKhoa", khoa.TruongKhoa,
                                "@Result", 0

                );

                if (result == "1")
                {
                    k = false;
                    msg = "mã khoa đã tồn tại";
                    return (k, msg);
                }
                else if (result == "2")
                {

                    k = false;
                    msg = "GIảng viên ko tồn tại";
                    return (k, msg);
                }
                k = true;
                msg = "Thêm thành công";
                return (k, msg);


            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public List<Khoa> getAllKhoa()
        {
            List<Khoa> list = new List<Khoa>();

            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllKhoa");

            foreach (System.Data.DataRow row in dt.Rows)
            {
                Khoa khoa = new Khoa(
                    row["MaKhoa"].ToString(),
                    row["TenKhoa"].ToString(),
                    row["SDT"] == DBNull.Value ? null : row["SDT"].ToString(),
                    row["Email"] == DBNull.Value ? null : row["Email"].ToString(),
                    row["TruongKhoa"] == DBNull.Value ? null : row["TruongKhoa"].ToString()
                );

                list.Add(khoa);
            }

            return list;
        }



        public (bool k, string i) updateKhoa(Khoa khoa)
        {
            bool k = false;
            string msg = "";
            try
            {
                var result = helper.ExcuteNonQueryProcedure("sp_ThemKhoa",
                             "@MaKhoa", khoa.IDKhoa,
                             "@TenKhoa", khoa.TenKhoa,
                             "@SDT", khoa.SDT,
                                "@Email", khoa.Email,
                                "@TruongKhoa", khoa.TruongKhoa,
                                "@Result", 0

                );

                if (result == "1")
                {
                    k = false;
                    msg = "mã khoa đã tồn tại";
                    return (k, msg);
                }
                else if (result == "2")
                {

                    k = false;
                    msg = "GIảng viên ko tồn tại";
                    return (k, msg);
                }
                k = true;
                msg = "Thêm thành công";
                return (k, msg);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public (bool k, string i) deleteKhoa(string iDKhoa)
        {
            string i = "";
            bool k = false;

            var Exe = helper.ExcuteNonQueryProcedure(
                "sp_XoaKhoa",
                "@MaKhoa", iDKhoa,
                "@Result", 0
            );

            if (Exe == "1")
            {
                i = "Mã khoa không tồn tại";
                k = false;
            }
            else if (Exe == "2")
            {
                i = "Không thể xóa khoa vì đang được sử dụng";
                k = false;
            }
            else
            {
                i = "Xóa khoa thành công";
                k = true;
            }

            return (k, i);
        }

        public List<Khoa> search(Khoa khoa)
        {
            List<Khoa> list = new List<Khoa>();
            string kq = "";
            int t = 0;

            var dt = helper.ExcuteProcedureToDataTable(
                out kq,
                "sp_SearchKhoa",
                "@MaKhoa", khoa.IDKhoa,
                "@TenKhoa", khoa.TenKhoa,
                "@SDT", khoa.SDT,
                "@Email", khoa.Email,
                "@TruongKhoa", khoa.TruongKhoa
            );

            foreach (System.Data.DataRow row in dt.Rows)
            {
                Khoa k = new Khoa(
                    row["MaKhoa"].ToString(),
                    row["TenKhoa"].ToString(),
                    row["SDT"] == DBNull.Value ? null : row["SDT"].ToString(),
                    row["Email"] == DBNull.Value ? null : row["Email"].ToString(),
                    row["TruongKhoa"] == DBNull.Value ? null : row["TruongKhoa"].ToString()
                );

                list.Add(k);
            }

            t = dt.Rows.Count;
            return list;
        }


    }
}
