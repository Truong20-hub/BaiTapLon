using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class GiangVien
    {
        public GiangVien(string iDGV,string iDNguoiDung, string tenGiangVien, string gioiTinh, DateTime ngaySinh, string trinhDo, string khoa, string mon, List<LopHoc> danhSachLH)
        {
            IDGV = iDGV;
            IDNguoiDung = iDNguoiDung;
            TenGiangVien = tenGiangVien;
            GioiTinh = gioiTinh;
            NgaySinh = ngaySinh;
            TrinhDo = trinhDo;
            Khoa = khoa;
            Mon = mon;
            DanhSachLH = danhSachLH;
        }

        public string IDGV { get; set; }
        public string IDNguoiDung { get; set; }
        public string TenGiangVien { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }

        public string TrinhDo { get; set; }
        public string Khoa { get; set; }
        public string Mon { get; set; }
        public List<LopHoc> DanhSachLH { get; set; }
    }
}
