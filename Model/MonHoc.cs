using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class MonHoc
    {
        public MonHoc(string iDMonHoc, int soTinChi, int soTiet, int thuTuUuTien, string tenMonHoc, string iDNganh)
        {
            IDMonHoc = iDMonHoc;
            SoTinChi = soTinChi;
            SoTiet = soTiet;
            ThuTuUuTien = thuTuUuTien;
            TenMonHoc = tenMonHoc;
            IDNganh = iDNganh;
        }

        public string IDMonHoc { get; set; }
        public int SoTinChi { get; set; }
        public int SoTiet { get; set; }
        public int ThuTuUuTien { get; set; }
        public string TenMonHoc { get; set; }
        public string IDNganh { get; set; }
    }
}
