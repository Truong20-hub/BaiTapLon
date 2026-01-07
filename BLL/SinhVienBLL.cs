using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.InterFace;
using DAL;
using DAL_;
using Model_;

namespace BLL_
{
    public class SinhVienBLL: ISinhVienBLL
    {
        private readonly ISinhVienDAL sinhVienDAL;
        public SinhVienBLL(ISinhVienDAL _sinhVienDAL)
        {
            this.sinhVienDAL = _sinhVienDAL;
        }
        public (string k, bool h) ThemSV(SinhVien sv)
        {
            return sinhVienDAL.createSinhVien(sv);
        }
        public (string k, bool h) SuaSV(SinhVien sv)
        {
            return sinhVienDAL.updateSinhVien(sv);
        }
        public List<SinhVien> GetAllSV()
        {
            return sinhVienDAL.getAllSV();
        }
        public (string k, bool h) XoaSV(string iDSinhVien)
        {
            return sinhVienDAL.deleteSinhVien(iDSinhVien);
        }
        public List<SinhVien> Search(SinhVien sv)
        {
            return sinhVienDAL.Search(sv);
        }
    }
}
