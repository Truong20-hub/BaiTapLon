using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL_
{
    public interface ILopHanhChinhDAL
    {
        (string k, bool h) createLopHC(LopHanhChinh lopHanhChinh);
        (string k, bool h) updateLopHC(LopHanhChinh lopHanhChinh);
        (string k, bool h) deleteLopHC(string iDLopHC);
        List<LopHanhChinh> Search(LopHanhChinh lopHanhChinh);
        List<LopHanhChinh> getAllLopHC();
    }
}
