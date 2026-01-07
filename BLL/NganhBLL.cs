using BLL.InterFace;
using DAL_;
using Model_;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class NganhBLL:INganhBLL
    {
        private readonly INganhDAL nganhDAL;
        public NganhBLL (INganhDAL nganhDAL)
        {
            this.nganhDAL = nganhDAL;
        }
        public (string k, bool h) ThemNganh(Nganh ng)
        {
            return nganhDAL.createNganh(ng);
        }
        public (string k, bool h) SuaNganh(Nganh ng)
        {
            return nganhDAL.updateNganh(ng);
        }
        public List<Nganh> GetAllNganh()
        {
            return nganhDAL.getAllNganh();
        }
        public (string k, bool h) XoaNganh(string iDNganh)
        {
            return nganhDAL.deleteNganh(iDNganh);
        }
        public List<Nganh> Search(Nganh ng)
        {
            return nganhDAL.Search(ng);
        }
    }
}
