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
    public class LichThiBLL: ILichThiBLL
    {
        private readonly ILichThiDAL iLichThi;
        public LichThiBLL(ILichThiDAL _lichThi)
        {
            this.iLichThi = _lichThi;
        }
        public (string k, bool h) ThemLichThi(LichThi lt)
        {
            return iLichThi.createLichThi(lt);
        }
        public (string k, bool h) SuaLichThi(LichThi lt)
        {
            return iLichThi.updateLichThi(lt);
        }
        public List<LichThi> GetAllLichThi()
        {
            return iLichThi.getAllLichThi();
        }
        public (string k, bool h) XoaLichThi(string iDLichThi)
        {
            return iLichThi.deleteLichThi(iDLichThi);
        }
        public List<LichThi> SearchLichThi(LichThi lt)
        {
            return iLichThi.searchLichThi(lt);
        }
    }
}
