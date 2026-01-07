using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL
{
    public interface IPhongHocDAL
    {
        (string k, bool h) createPH(PhongHoc phongHoc);
        (string k, bool h) updatePH(PhongHoc phongHoc);
        (string k, bool h) deletePH(string iDPhong);
        List<PhongHoc> searchPH(PhongHoc phongHoc);
        List<PhongHoc> getAllPH();
    }
}
