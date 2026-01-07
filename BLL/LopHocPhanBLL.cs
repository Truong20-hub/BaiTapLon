using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL_;
using BLL.InterFace;
using Model_;
using BLL_.InterFace;
namespace BLL_
{
    public class LopHocPhanBLL: ILopHocPhanBLL
    {
        private readonly ILopHocPhanDAL lopHocPhanDAL;
        public LopHocPhanBLL(ILopHocPhanDAL _lopHocPhanDAL)
        {
            this.lopHocPhanDAL = _lopHocPhanDAL;
        }
        public (string k, bool h) ThemLHP(LopHocPhan lhp)
        {
            return lopHocPhanDAL.createLopHocPhan(lhp);
        }
        public (string k, bool h) SuaLHP(LopHocPhan lhp)
        {
            return lopHocPhanDAL.updateLopHocPhan(lhp);
        }
        public List<LopHocPhan> GetAllLopHocPhan()
        {
            return lopHocPhanDAL.getAllLopHocPhan();
        }
        public (string k, bool h) XoaLHP(string iDLopHP)
        {
            return lopHocPhanDAL.deleteLopHocPhan(iDLopHP);
        }
        public List<LopHocPhan> Search(LopHocPhan lhp)
        {
            return lopHocPhanDAL.Search(lhp);
        }
    }
}
