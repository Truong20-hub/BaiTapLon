using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_
{
    public interface ILopHocPhanDAL
    {
        (string k, bool h) createLopHocPhan(LopHocPhan lopHocPhan);
        (string k, bool h) updateLopHocPhan(LopHocPhan lopHocPhan);
        (string k, bool h) deleteLopHocPhan(string iDLopHP);
        List<LopHocPhan> Search(LopHocPhan lopHocPhan);
        List<LopHocPhan> getAllLopHocPhan();
    }
}
