using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL_
{
    public interface INganhDAL
    {
        (string k, bool h) createNganh(Nganh nganh);
        (string k, bool h) updateNganh(Nganh nganh);
        (string k, bool h) deleteNganh(string iDNganh);
        List<Nganh> Search(Nganh nganh);
        List<Nganh> getAllNganh();
    }
}
