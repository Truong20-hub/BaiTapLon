using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL_.InterFace;
using Model_;
using DAL_;


namespace BLL_
{
    public partial class BLLKhoa : IkhoaBLL
    {
        private IKhoaRepostiry _khoa;
        public BLLKhoa(IKhoaRepostiry khoa)
        {
            _khoa = khoa;
        }
        public (bool k, string i) ThemKhoa(Khoa kh)
        {
            return _khoa.createKhoa(kh);
        }
        public (bool k, string i) SuaKhoa(Khoa kh)
        {
            return _khoa.updateKhoa(kh);
        }
        public List<Khoa> getAllKhoa()
        {
            return _khoa.getAllKhoa();
        }
        public (bool k, string i) XoaKhoa(string iDKhoa)
        {
            return _khoa.deleteKhoa(iDKhoa);
        }
        public List<Khoa> search(Khoa kh)
        {
            return _khoa.search(kh);
        }
    }
}