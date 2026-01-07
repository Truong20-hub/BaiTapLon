using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class Khoa
    {
        public Khoa(string iDKhoa, string tenKhoa, string sDT, string email, string truongKhoa)
        {
            IDKhoa = iDKhoa;
            TenKhoa = tenKhoa;
            SDT = sDT;
            Email = email;
            TruongKhoa = truongKhoa;
        }
        public string IDKhoa { get; set; }
        public string TenKhoa { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string TruongKhoa { get; set; }
    }
}
