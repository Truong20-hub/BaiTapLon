using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class DangKyHocPhan
    {
        public DangKyHocPhan(string iDSinhVien,string iDLopHP, DateTime ngayDK, string trangThaiDK)
        {
            IDSinhVien = iDSinhVien;
            IDLopHP = iDLopHP;
            NgayDK = ngayDK;
            TrangThaiDK = trangThaiDK;
        }

        public string IDSinhVien { get; set; }
        public string IDLopHP { get; set; }
        public DateTime NgayDK { get; set; }
        public string TrangThaiDK { get; set; }
    }
}
