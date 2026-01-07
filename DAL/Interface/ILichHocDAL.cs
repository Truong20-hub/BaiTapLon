using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL
{
    public interface ILichHocDAL
    {
        (string k, bool h) createLichHoc(LichHoc lichHoc);
        (string k, bool h) updateLichHoc(LichHoc lichHoc);
        (string k, bool h) deleteLichHoc(string iDLichHoc);
        List<LichHoc> searchLichHoc(LichHoc lichHoc);
        List<LichHoc> getAllLichHoc();
    }
}
