using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterFace
{
    public interface IDauDiemBLL
    {
        (string k,bool h) ThemDauDiem(DauDiem daudiem);
        (string k,bool h) SuaDauDiem(DauDiem daudiem);
        (string k, bool h) XoaDauDiem(string idDD);
        List<DauDiem> SearchDauDiem(DauDiem daudiem);
        List<DauDiem> GetAllDauDiem();
    }
}
