using BLL.InterFace;
using DAL_;
using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class BangDiemBLL: IBangDiemBLL
    {
        private readonly IBangDiem iBangDiem;
        public BangDiemBLL(IBangDiem _bangDiem)
        {
            this.iBangDiem = _bangDiem;
        }
        public (string k, bool h) ThemBangDiem(BangDiem bd)
        {
            return iBangDiem.createBD(bd);
        }
        public (string k, bool h) SuaBangDiem(BangDiem bd)
        {
            return iBangDiem.updateBD(bd);
        }
        public List<BangDiem> GetAllBangDiem()
        {
            return iBangDiem.getAllBD();
        }
        public (string k, bool h) XoaBangDiem(string idBD)
        {
            return iBangDiem.deleteBD(idBD);
        }
        public List<BangDiem> Search(BangDiem bangDiem)
        {
            return iBangDiem.Search(bangDiem);
        }

    }
}
