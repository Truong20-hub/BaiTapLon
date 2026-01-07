using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;
namespace BLL.InterFace
{
    public interface IGiangVienBLL
    {
        (string k, bool h) ThemGV (GiangVien giangVien);
        (string k, bool h) SuaGV(GiangVien giangVien);
        (string k, bool h) XoaGV(string iDGV);
        List<GiangVien> Search(GiangVien giangVien);
        List<GiangVien> GetAllGV();
    }
}
