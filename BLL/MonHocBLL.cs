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
    public class MonHocBLL: IMonHocBLL
    {
        private readonly IMonHocDAL monHocDAL;
        public MonHocBLL(IMonHocDAL _monHocDAL)
        {
            this.monHocDAL = _monHocDAL;
        }
        public (string k, bool h) ThemMonHoc(MonHoc mh)
        {
            return monHocDAL.createMonHoc(mh);
        }
        public (string k, bool h) SuaMonHoc(MonHoc mh)
        {
            return monHocDAL.updateMonHoc(mh);
        }
        public (string k, bool h) XoaMonHoc(string iDMonHoc)
        {
            return monHocDAL.deleteMonHoc(iDMonHoc);
        }
        public List<MonHoc> GetAllMonHoc()
        {
            return monHocDAL.getAllMonHoc();
        }
        public List<MonHoc> SearchMonHoc(MonHoc mh)
        {
            return monHocDAL.searchMonHoc(mh);
        }
    }
}
