using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL_
{
    public interface IKhoaRepostiry
    {
        (bool k, string i) createKhoa(Khoa khoa);
        List<Khoa> getAllKhoa();

        (bool k, string i) updateKhoa(Khoa khoa);
        (bool k, string i) deleteKhoa(string iDKhoa);
        List<Khoa> search(Khoa khoa); // tìm kiếm theo mã khoa
        
    }
}
