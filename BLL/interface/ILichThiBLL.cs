using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;
using DAL_;

namespace BLL.InterFace
{
    public interface ILichThiBLL
    {
        (string k,bool h) ThemLichThi(LichThi lt);
        (string k, bool h) SuaLichThi(LichThi lt);
        List<LichThi> GetAllLichThi();
        (string k, bool h) XoaLichThi(string iDLichThi);
        List<LichThi> SearchLichThi(LichThi lt);
    }
}
