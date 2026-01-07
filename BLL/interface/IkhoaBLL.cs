using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_.InterFace
{
    public interface IkhoaBLL
    {
        (bool k, string i) ThemKhoa(Khoa khoa);
        List<Khoa> getAllKhoa();

        (bool k, string i) SuaKhoa(Khoa khoa);
        (bool k, string i) XoaKhoa(string iDKhoa);
        List<Khoa> search(Khoa khoa); // tìm kiếm theo mã khoa

    }
}
