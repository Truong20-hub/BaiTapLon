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
    public class DangKyHocPhanBLL: IDangKyHocPhanBLL
    {
        private readonly IDangKyHocPhanDAL iDangKyHocPhan;
        public DangKyHocPhanBLL(IDangKyHocPhanDAL _dangKyHocPhan)
        {
            this.iDangKyHocPhan = _dangKyHocPhan;
        }
        public (string k, bool h) ThemDangKyHocPhan(DangKyHocPhan dkhp)
        {
            return iDangKyHocPhan.createDKHP(dkhp);
        }
        public (string k, bool h) SuaDangKyHocPhan(DangKyHocPhan dkhp)
        {
            return iDangKyHocPhan.updateDKHP(dkhp);
        }
        public List<DangKyHocPhan> GetAllDangKyHocPhan()
        {
            return iDangKyHocPhan.getAllDKHP();
        }
        public (string k, bool h) XoaDangKyHocPhan(string iDSinhVien, string iDLopHP)
        {
            return iDangKyHocPhan.deleteDKHP(iDSinhVien, iDLopHP);
        }
        public List<DangKyHocPhan> SearchDangKyHocPhan(DangKyHocPhan dkhp)
        {
            return iDangKyHocPhan.searchDKHP(dkhp);
        }
    }
}
