using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class LichHoc
    {
        public LichHoc(string iDLopPhan, DateTime ngayHoc, int soTiet, string phongHoc, string iDLichHoc)
        {
            IDLopPhan = iDLopPhan;
            NgayHoc = ngayHoc;
            SoTiet = soTiet;
            PhongHoc = phongHoc;
            IDLichHoc = iDLichHoc;
        }

        public string IDLopPhan { get; set; }
        public DateTime NgayHoc { get; set; }
        public int SoTiet { get; set; }
        public string PhongHoc { get; set; }
        public string IDLichHoc { get; set; }
    }
}
