using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model_
{
    public class ChiTietBangDiem
    {
        public ChiTietBangDiem(string iDCTBD, string iDBD, string iDSV, string iDLopHP, string iDĐĐ, float diem)
        {
            IDCTBD = iDCTBD;
            IDBD = iDBD;
            IDSV = iDSV;
            IDLopHP = iDLopHP;
            IDĐĐ = iDĐĐ;
            Diem = diem;
        }

        public string IDCTBD { get; set; }
        public string IDBD { get; set; }
        public string IDSV { get; set; }
        public string IDLopHP { get; set; }
        public string IDĐĐ { get; set; }
        public float Diem { get; set; }
    }
}
