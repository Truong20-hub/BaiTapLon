using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterFace
{
    public interface IBangDiemBLL
    {
        (string k,bool h) ThemBangDiem(BangDiem bd);
        (string k, bool h) SuaBangDiem(BangDiem bd);
        (string k, bool h) XoaBangDiem(string idBD);
        List<BangDiem> Search(BangDiem bangDiem);
        List<BangDiem> GetAllBangDiem();
    }
}
