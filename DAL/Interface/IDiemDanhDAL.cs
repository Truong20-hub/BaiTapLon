using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDiemDanhDAL
    {
        (string k, bool h) createBD(DiemDanh diemDanh);
        (string k, bool h) updateBD(DiemDanh diemDanh);
        (string k, bool h) deleteBD(string idDiemDanh);
        List<DiemDanh> searchBD(DiemDanh diemDanh);
        List<DiemDanh> getAllDD();
    }
}
