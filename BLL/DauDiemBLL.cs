using BLL.InterFace;
using DAL;
using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class DauDiemBLL: IDauDiemBLL
    {
        private readonly IDauDiemDAL iDauDiem;
        public DauDiemBLL(IDauDiemDAL _iDauDiem)
        {
            iDauDiem = _iDauDiem;
        }
        public (string k,bool h) ThemDauDiem(DauDiem daudiem)
        {
            return iDauDiem.createDD(daudiem);
        }
        public (string k,bool h) SuaDauDiem(DauDiem daudiem)
        {
            return iDauDiem.updateDD(daudiem);
        }
        public List<DauDiem> GetAllDauDiem()
        {
            return iDauDiem.getAllDD();
        }
        public (string k, bool h) XoaDauDiem(string idDD)
        {
            return iDauDiem.deleteDD(idDD);
        }
        public List<DauDiem> SearchDauDiem(DauDiem daudiem)
        {
            return iDauDiem.searchDD(daudiem);
        }
    }
}
