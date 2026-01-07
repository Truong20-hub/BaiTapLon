using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class BangDiem
    {
        public BangDiem(string iDBD, string iDSinhVien, string iDMonHoc,string iDLopHP, string iDDauDiem, float diem)
        {
            IDBD = iDBD;
            IDSinhVien = iDSinhVien;
            IDMonHoc = iDMonHoc;
            IDLopHP=iDLopHP;
            IDDauDiem = iDDauDiem;
            Diem = diem;

        }

        public string IDBD { get; set; }
        public string IDSinhVien { get; set; }
        public string IDMonHoc { get; set; }
        public string IDLopHP { get; set; }
        public string IDDauDiem { get; set; }
        public float Diem { get; set; }
    }
}
