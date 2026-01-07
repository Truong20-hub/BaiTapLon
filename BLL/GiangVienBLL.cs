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
    public class GiangVienBLL: IGiangVienBLL
    {
        private readonly IGiangVienDAL giangVienDAL;
        public GiangVienBLL(IGiangVienDAL giangVienDAL)
        {
            this.giangVienDAL = giangVienDAL;
        }
        public (string k, bool h) ThemGV(GiangVien gv)
        {
            return giangVienDAL.createGiangVien(gv);
        }
        public (string k, bool h) SuaGV(GiangVien gv)
        {
            return giangVienDAL.updateGiangVien(gv);
        }
        public List<GiangVien> GetAllGV()
        {
            return giangVienDAL.getAllGiangVien();
        }
        public (string k, bool h) XoaGV(string iDGV)
        {
            return giangVienDAL.deleteGiangVien(iDGV);
        }
        public List<GiangVien> Search(GiangVien gv)
        {
            return giangVienDAL.Search(gv);
        }
    }
}
