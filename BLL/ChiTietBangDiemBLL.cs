using BLL.InterFace;
using DAL;
using DAL_;
using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class ChiTietBangDiemBLLL: IChiTietBangDiemBLL
    {
        private readonly IChiTietBangDiemDAL iChiTietBangDiem;
        public ChiTietBangDiemBLLL(IChiTietBangDiemDAL _chiTietBangDiem)
        {
            this.iChiTietBangDiem = _chiTietBangDiem;
        }
        public (string k, bool h) ThemChiTietBangDiem(ChiTietBangDiem ctbd)
        {
            return iChiTietBangDiem.createIDCTBD(ctbd);
        }
        public (string k, bool h) SuaChiTietBangDiem(ChiTietBangDiem ctbd)
        {
            return iChiTietBangDiem.updateCTBD(ctbd);
        }
        public List<ChiTietBangDiem> GetAllChiTietBangDiem()
        {
            return iChiTietBangDiem.getAllCTBD();
        }
        public (string k, bool h) XoaChiTietBangDiem(string idCTBD)
        {
            return iChiTietBangDiem.deleteCTBD(idCTBD);
        }
        public List<ChiTietBangDiem> SearchChiTietBangDiem(ChiTietBangDiem ctbd)
        {
            return iChiTietBangDiem.searchCTBD(ctbd);
        }
    }
}
