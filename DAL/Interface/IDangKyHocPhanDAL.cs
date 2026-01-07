using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL
{
    public interface IDangKyHocPhanDAL
    {
        (string k,bool h) createDKHP(DangKyHocPhan dangKyHocPhan);
        (string k, bool h) updateDKHP(DangKyHocPhan dangKyHocPhan);
        (string k, bool h) deleteDKHP(string iDSinhVien, string iDLopHP);
        List<DangKyHocPhan> searchDKHP(DangKyHocPhan dangKyHocPhan);
        List<DangKyHocPhan> getAllDKHP();
    }
}
