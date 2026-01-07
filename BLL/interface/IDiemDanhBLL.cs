using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace BLL.InterFace
{
    public interface IDiemDanhBLL
    {
        (string k ,bool h) ThemDiemDanh(DiemDanh diemdanh);
        (string k, bool h) SuaDiemDanh(DiemDanh diemdanh);
        (string k, bool h) XoaDiemDanh(string idDiemDanh);
        List<DiemDanh> SearchDiemDanh(DiemDanh diemdanh);
        List<DiemDanh> GetAllDiemDanh();
    }
}
