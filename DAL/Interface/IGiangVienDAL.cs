using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL_
{
    public interface IGiangVienDAL
    {
        (string k, bool h) createGiangVien(GiangVien giangVien);
        (string k, bool h) updateGiangVien(GiangVien giangVien);
        (string k, bool h) deleteGiangVien(string iDGV);
        List<GiangVien> Search(GiangVien giangVien);
        List<GiangVien> getAllGiangVien();
    }
}

