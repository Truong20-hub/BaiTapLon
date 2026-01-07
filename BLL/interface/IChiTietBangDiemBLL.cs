using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace BLL.InterFace
{
    public interface IChiTietBangDiemBLL
    {
        (string k,bool h) ThemChiTietBangDiem(ChiTietBangDiem ctbd);
        (string k, bool h) SuaChiTietBangDiem(ChiTietBangDiem ctbd);
        (string k, bool h) XoaChiTietBangDiem(string idCTBD);
        List<ChiTietBangDiem> SearchChiTietBangDiem(ChiTietBangDiem ctbd);
        List<ChiTietBangDiem> GetAllChiTietBangDiem();
    }
}
