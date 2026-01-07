using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace BLL.InterFace
{
    public interface IMonHocBLL
    {
        (string k, bool h) ThemMonHoc(MonHoc mh);
        (string k, bool h) SuaMonHoc(MonHoc mh);
        (string k, bool h) XoaMonHoc(string iDMonHoc);
        List<MonHoc> GetAllMonHoc();
        List<MonHoc> SearchMonHoc(MonHoc mh);
    }
}
