using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class LopHocPhan
    {
        public LopHocPhan(string iDLopHP, string tenLop, string iDMonHoc, string iDGiangVien, DateTime thoiGianMo, DateTime thoiGianDong, int soLuongSinhVien, string thuTuUuTien)
        {
            IDLopHP = iDLopHP;
            TenLop = tenLop;
            IDMonHoc = iDMonHoc;
            IDGiangVien = iDGiangVien;
            ThoiGianMo = thoiGianMo;
            ThoiGianDong = thoiGianDong;
            SoLuongSinhVien = soLuongSinhVien;
            ThuTuUuTien = thuTuUuTien;
        }
        public string IDLopHP { get; set; }
        public string TenLop { get; set; }
        public string IDMonHoc { get; set; }
        public string IDGiangVien { get; set; }
        public DateTime ThoiGianMo { get; set; }
        public DateTime ThoiGianDong { get; set; }
        public int SoLuongSinhVien { get; set; }
        public string ThuTuUuTien { get; set; }
    }
}
