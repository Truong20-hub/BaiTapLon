
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class NguoiDung
    {
        public NguoiDung() { }
        public NguoiDung(string email, string matKhau, string id = null, string sdt = null , int loai = 0, string diaChi = "")
        {
            Id = id;
            MatKhau = matKhau;
            SDT = sdt;
            email = email;
            loai = loai;
            DiaChi = diaChi;
        }
        public string Id { get; set; }
        public string MatKhau { get; set; }
        public string SDT { get; set; }
        public string email { get; set; }
        public int loai { get; set; }
        public string DiaChi { get; set; }

    }
}
