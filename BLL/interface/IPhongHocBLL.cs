using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterFace
{
    public interface IPhongHocBLL
    {
        (string k, bool h) ThemPhongHoc(PhongHoc ph);
        (string k, bool h) SuaPhongHoc(PhongHoc ph);
        (string k, bool h) XoaPhongHoc(string iDPhong);
        List<PhongHoc> GetAllPhongHoc();
        List<PhongHoc> SearchPhongHoc(PhongHoc ph);
    }
}
