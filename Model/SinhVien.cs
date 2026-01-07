using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class SinhVien
    {
        public SinhVien(string iDSinhVien,string maNguoiDung, string hoTen, string gioiTinh, DateTime ngaySinh, string nganhHoc, string khoaHoc, string maLopHC, string trangThai)
        {
            IDSinhVien = iDSinhVien;
            MaNguoiDung = maNguoiDung;
            HoTen = hoTen;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            NganhHoc = nganhHoc;
            KhoaHoc = khoaHoc;
            MaLopHC = maLopHC;
            TrangThai = trangThai;
        }

        public string IDSinhVien { get; set; }
        public string MaNguoiDung { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        public string NganhHoc { get; set; }
        public string KhoaHoc { get; set; }
        public string MaLopHC { get; set; }
        
        public string TrangThai { get; set; }
    }
}
