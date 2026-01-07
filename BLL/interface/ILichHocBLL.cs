using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace BLL.InterFace
{
    public interface ILichHocBLL
    {
        (string k,bool h) ThemLichHoc(LichHoc lichhoc);
        (string k, bool h) SuaLichHoc(LichHoc lichhoc);
        (string k, bool h) XoaLichHoc(string iDLichHoc);
        List<LichHoc> GetAllLichHoc();
        List<LichHoc> SearchLichHoc(LichHoc lichhoc);
    }
}
