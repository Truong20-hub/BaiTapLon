using BLL.InterFace;
using DAL;
using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class PhongHocBLL: IPhongHocBLL
    {
        private readonly IPhongHocDAL iPhongHoc;
        public PhongHocBLL(IPhongHocDAL _phongHoc)
        {
            this.iPhongHoc = _phongHoc;
        }
        public (string k, bool h) ThemPhongHoc(PhongHoc ph)
        {
            return iPhongHoc.createPH(ph);
        }
        public (string k, bool h) SuaPhongHoc(PhongHoc ph)
        {
            return iPhongHoc.updatePH(ph);
        }
        public (string k, bool h) XoaPhongHoc(string iDPhong)
        {
            return iPhongHoc.deletePH(iDPhong);
        }
        public List<PhongHoc> GetAllPhongHoc()
        {
            return iPhongHoc.getAllPH();
        }
        public List<PhongHoc> SearchPhongHoc(PhongHoc ph)
        {
            return iPhongHoc.searchPH(ph);
        }
    }
}
