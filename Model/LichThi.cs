using System;

namespace Model_
{
    public class LichThi
    {
        // ✅ Constructor rỗng (BẮT BUỘC để dùng new LichThi { })
        public LichThi() { }

        // (Không bắt buộc) Constructor đầy đủ nếu bạn muốn dùng
        public LichThi(
            string iDLichThi,
            string iDLopPhan,
            DateTime ngayThi,
            string gioThi,
            string iDPhong,
            string phongHoc,
            string hinhThucThi,
            string giamThi)
        {
            IDLichThi = iDLichThi;
            IDLopPhan = iDLopPhan;
            NgayThi = ngayThi;
            GioThi = gioThi;
            IDPhong = iDPhong;
            PhongHoc = phongHoc;
            HinhThucThi = hinhThucThi;
            GiamThi = giamThi;
        }

        public string IDLichThi { get; set; }
        public string IDLopPhan { get; set; }
        public DateTime NgayThi { get; set; }
        public string GioThi { get; set; }
        public string IDPhong { get; set; }
        public string PhongHoc { get; set; }
        public string HinhThucThi { get; set; }
        public string GiamThi { get; set; }
    }
}
