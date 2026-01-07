using BLL;
using BLL.InterFace;
using BLL_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class DangKyHocPhanontroller : ControllerBase
    {
        IDangKyHocPhanBLL _dangKyHocPhanBLL;
        public DangKyHocPhanontroller(IDangKyHocPhanBLL dangKyHocHocPhanBLL)
        {
            _dangKyHocPhanBLL = dangKyHocHocPhanBLL;
        }
        [HttpPost("createDKHP")]
        public IActionResult createDKHP(Model_.DangKyHocPhan dangKyHocPhan)
        {
            var result = _dangKyHocPhanBLL.ThemDangKyHocPhan(dangKyHocPhan);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateDKHP")]
        public IActionResult updateDKHP(Model_.DangKyHocPhan dangKyHocPhan)
        {
            var result = _dangKyHocPhanBLL.SuaDangKyHocPhan(dangKyHocPhan);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllDKHP")]
        public IActionResult getAllDKHP()
        {
            try
            {

                var result = _dangKyHocPhanBLL.GetAllDangKyHocPhan();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteDKHP")]
        public IActionResult deleteDKHP(string iDSinhVien, string iDLopHP)
        {
            var result = _dangKyHocPhanBLL.XoaDangKyHocPhan(iDSinhVien, iDLopHP);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("searchDKHP")]
        public IActionResult searchDKHP(Model_.DangKyHocPhan dangKyHocPhan)
        {
            var result = _dangKyHocPhanBLL.SearchDangKyHocPhan(dangKyHocPhan);
            return Ok(result);
        }
    }
}
