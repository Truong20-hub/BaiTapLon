using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL_;
using BLL.InterFace;
using Model_;

namespace BLL_
{
    public class LopHanhChinhBLL: ILopHanhChinhBLL
    {
        private readonly ILopHanhChinhDAL lopHanhChinhDAL;
        public LopHanhChinhBLL(ILopHanhChinhDAL lopHanhChinhDAL)
        {
            this.lopHanhChinhDAL = lopHanhChinhDAL;
        }
        public (string k, bool h) ThemLopHC(LopHanhChinh lhc)
        {
            return lopHanhChinhDAL.createLopHC(lhc);
        }
        public (string k, bool h) SuaLopHC(LopHanhChinh lhc)
        {
            return lopHanhChinhDAL.updateLopHC(lhc);
        }
        public List<LopHanhChinh> GetAllLopHC()
        {
            return lopHanhChinhDAL.getAllLopHC();
        }
        public (string k, bool h) XoaLopHC(string iDLopHC)
        {
            return lopHanhChinhDAL.deleteLopHC(iDLopHC);
        }
        public List<LopHanhChinh> Search(LopHanhChinh lhc)
        {
            return lopHanhChinhDAL.Search(lhc);
        }
    }
}
