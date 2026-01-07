using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL_
{
    public interface IBangDiem
    {
        (string k,bool h) createBD(BangDiem bangDiem);
        (string k, bool h) updateBD(BangDiem bangDiem);
        (string k, bool h) deleteBD(string idBD);
        List<BangDiem>  Search(BangDiem bangDiem);
        List<BangDiem> getAllBD();
    }
}
