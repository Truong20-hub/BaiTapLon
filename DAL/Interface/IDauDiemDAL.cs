using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL
{
    public interface IDauDiemDAL
    {
        (string k, bool h) createDD(DauDiem dauDiem);
        (string k, bool h) updateDD(DauDiem dauDiem);
        (string k, bool h) deleteDD(string idDD);
        List<DauDiem> searchDD(DauDiem dauDiem);
        List<DauDiem> getAllDD();
    }
}
