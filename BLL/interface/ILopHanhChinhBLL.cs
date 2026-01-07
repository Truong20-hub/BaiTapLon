using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterFace
{
    public interface ILopHanhChinhBLL
    {
        (string k, bool h) ThemLopHC(LopHanhChinh lopHanhChinh);
        (string k, bool h) SuaLopHC(LopHanhChinh lopHanhChinh);
        (string k, bool h) XoaLopHC(string iDLopHC);
        List<LopHanhChinh> Search(LopHanhChinh lopHanhChinh);
        List<LopHanhChinh> GetAllLopHC();
    }
}
