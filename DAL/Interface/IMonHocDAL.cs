using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace DAL
{
    public interface IMonHocDAL
    {
        (string k,bool h) createMonHoc(MonHoc monHoc);
        (string k,bool h) updateMonHoc(MonHoc monHoc);
        (string k,bool h) deleteMonHoc(string iDMonHoc);
        List<MonHoc> searchMonHoc(MonHoc monHoc);
        List<MonHoc> getAllMonHoc();
    }
}
