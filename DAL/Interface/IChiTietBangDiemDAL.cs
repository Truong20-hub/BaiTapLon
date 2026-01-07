using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IChiTietBangDiemDAL
    {
        (string k,bool h) createIDCTBD(ChiTietBangDiem chiTietBangDiem);
        (string k, bool h) updateCTBD(ChiTietBangDiem chiTietBangDiem);
        (string k, bool h) deleteCTBD(string idCTBD);
        List<ChiTietBangDiem> getAllCTBD();
        List<ChiTietBangDiem> searchCTBD(ChiTietBangDiem chiTietBangDiem);
    }
}
