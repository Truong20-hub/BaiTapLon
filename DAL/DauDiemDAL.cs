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
    public class DauDiemDAL: IDauDiemDAL
    {
        private IDatabaseHelper helper;
        public DauDiemDAL(IDatabaseHelper _helper)
        {
            this.helper = _helper;
        }
        public (string k, bool h) createDD(DauDiem dauDiem)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_ThemDauDiem",
                "@MaDD", dauDiem.IDĐĐ,
                "@TenDD", dauDiem.TenĐĐ,
                "@HeSoDiem", dauDiem.HeSoDiem,
                "@LoaiDiem", dauDiem.LoaiDiem,
                "@MoTa", dauDiem.MoTa,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã đầu điểm đã tồn tại";
                h = false;
            }
            else
            {
                k = "Thêm thành công";
                h = true;
            }
            return (k, h);
        }
        public (string k, bool h) updateDD(DauDiem dauDiem)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_SuaDauDiem",
                "@MaDD", dauDiem.IDĐĐ,
                "@TenDD", dauDiem.TenĐĐ,
                "@HeSoDiem", dauDiem.HeSoDiem,
                "@LoaiDiem", dauDiem.LoaiDiem,
                "@MoTa", dauDiem.MoTa,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã đầu điểm không tồn tại";
                h = false;
            }
            else
            {
                k = "Cập nhật thành công";
                h = true;
            }
            return (k, h);
        }
        public List<DauDiem> getAllDD()
        {
            List<DauDiem> list = new List<DauDiem>();
            var dt = helper.ExcuteProcedureToDataTable("sp_GetAllDauDiem");
            foreach (System.Data.DataRow row in dt.Rows)
            {
                DauDiem dauDiem = new DauDiem(
                    row["MaDD"].ToString(),
                    row["TenDD"].ToString(),
                    float.Parse(row["HeSoDiem"].ToString()),
                    row["LoaiDiem"].ToString(),
                    row["MoTa"].ToString()
                );
                list.Add(dauDiem);
            }
            return list;
        }
        public (string k, bool h) deleteDD(string idDD)
        {
            string k = "";
            bool h = false;
            var Exe = helper.ExcuteNonQueryProcedure("sp_XoaDauDiem",
                "@MaDD", idDD,
                "@Result", 0
            );
            if (Exe == "1")
            {
                k = "Mã đầu điểm không tồn tại";
                h = false;
            }
            else
            {
                k = "Xóa thành công";
                h = true;
            }
            return (k, h);
        }
        public List<DauDiem> searchDD(DauDiem dauDiem)
        {
            List<DauDiem> list = new List<DauDiem>();
            string kq = "";
            int t = 0;
            var dt = helper.ExcuteProcedureToDataTable(out kq,"sp_SearchDauDiem",
                "@MaDD", dauDiem.IDĐĐ,
                "@TenDD", dauDiem.TenĐĐ
            );
            foreach (System.Data.DataRow row in dt.Rows)
            {
                DauDiem dd = new DauDiem(
                    row["MaDD"].ToString(),
                    row["TenDD"].ToString(),
                    float.Parse(row["HeSoDiem"].ToString()),
                    row["loaiDiem"].ToString(),
                    row["moTa"].ToString()
                );
                list.Add(dd);
            }
            return list;
        }
    }
}
