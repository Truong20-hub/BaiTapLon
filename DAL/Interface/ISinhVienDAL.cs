using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL_
{
    public interface ISinhVienDAL
    {
        (string k,bool h) createSinhVien(SinhVien sinhVien);
        (string k, bool h) updateSinhVien(SinhVien sinhVien);
        (string k, bool h) deleteSinhVien(string iDSinhVien);
        List<SinhVien> Search(SinhVien sinhVien);
        List<SinhVien> getAllSV();
    }
}
