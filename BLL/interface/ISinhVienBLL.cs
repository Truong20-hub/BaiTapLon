using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterFace
{
    public interface ISinhVienBLL
    {
        (string k, bool h) ThemSV(SinhVien sv);
        (string k, bool h) SuaSV(SinhVien sv);
        (string k, bool h) XoaSV(string iDSinhVien);
        List<SinhVien> Search(SinhVien sv);
        List<SinhVien> GetAllSV();
    }
}
