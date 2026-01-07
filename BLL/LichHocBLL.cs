using BLL.InterFace;
using DAL;
using DAL_;
using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class LichHocBLL: ILichHocBLL
    {
        private readonly ILichHocDAL iLichHoc;
        public LichHocBLL(ILichHocDAL _lichHoc)
        {
            this.iLichHoc = _lichHoc;
        }
        public (string k, bool h) ThemLichHoc(LichHoc lichhoc)
        {
            return iLichHoc.createLichHoc(lichhoc);
        }
        public (string k,bool h) SuaLichHoc(LichHoc lichhoc)
        {
            return iLichHoc.updateLichHoc(lichhoc);
        }
        public (string k,bool h) XoaLichHoc(string iDLichHoc)
        {
            return iLichHoc.deleteLichHoc(iDLichHoc);
        }
        public List<LichHoc> GetAllLichHoc()
        {
            return iLichHoc.getAllLichHoc();
        }
        public List<LichHoc> SearchLichHoc(LichHoc lichhoc)
        {
            return iLichHoc.searchLichHoc(lichhoc);
        }
    }
}
