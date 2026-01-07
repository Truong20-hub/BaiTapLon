using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model_;

namespace BLL_.InterFace
{
    public interface ILopHocPhanBLL
    {
        (string k, bool h) ThemLHP(LopHocPhan lhp);
        (string k, bool h) SuaLHP(LopHocPhan lhp);
        (string k, bool h) XoaLHP(string iDLopHP);
        List<LopHocPhan> Search(LopHocPhan lhp);
        List<LopHocPhan> GetAllLopHocPhan();
    }
}
