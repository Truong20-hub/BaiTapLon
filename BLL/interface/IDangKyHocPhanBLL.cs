using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace BLL.InterFace
{
    public interface IDangKyHocPhanBLL
    {
        (string k,bool h) ThemDangKyHocPhan(DangKyHocPhan dkhp);
        (string k, bool h) SuaDangKyHocPhan(DangKyHocPhan dkhp);
        (string k, bool h) XoaDangKyHocPhan(string iDSinhVien, string iDLopHP);
        List<DangKyHocPhan> SearchDangKyHocPhan(DangKyHocPhan dkhp);
        List<DangKyHocPhan> GetAllDangKyHocPhan();
    }
}
