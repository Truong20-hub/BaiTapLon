using BLL.InterFace;
using DAL;
using Model_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_
{
    public class DiemDanhBLL: IDiemDanhBLL
    {
        private readonly IDiemDanhDAL iDiemDanh;
        public DiemDanhBLL(IDiemDanhDAL _diemDanh)
        {
            this.iDiemDanh = _diemDanh;
        }
        public (string k, bool h) ThemDiemDanh(DiemDanh diemdanh)
        {
            return iDiemDanh.createBD(diemdanh);
        }
        public (string k, bool h) SuaDiemDanh(DiemDanh diemdanh)
        {
            return iDiemDanh.updateBD(diemdanh);
        }
        public List<DiemDanh> GetAllDiemDanh()
        {
            return iDiemDanh.getAllDD();
        }
        public (string k, bool h) XoaDiemDanh(string idDiemDanh)
        {
            return iDiemDanh.deleteBD(idDiemDanh);
        }
        public List<DiemDanh> SearchDiemDanh(DiemDanh diemdanh)
        {
            return iDiemDanh.searchBD(diemdanh);
        }
    }
}
