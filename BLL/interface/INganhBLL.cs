using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.InterFace
{
    public interface INganhBLL
    {
        public (string k, bool h ) ThemNganh(Nganh ng);
        public (string k, bool h) SuaNganh(Nganh ng);
        (string k, bool h) XoaNganh(string iDNganh);
        List<Nganh> Search(Nganh ng);
        List<Nganh> GetAllNganh();
    }
}
