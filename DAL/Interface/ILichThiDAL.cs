using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL
{
    public interface ILichThiDAL
    {
        (string k, bool h) createLichThi(LichThi lichThi);
        (string k, bool h) updateLichThi(LichThi lichThi);
        (string k, bool h) deleteLichThi(string iDLichThi);
        List<LichThi> searchLichThi(LichThi lichThi);
        List<LichThi> getAllLichThi();
    }
}
