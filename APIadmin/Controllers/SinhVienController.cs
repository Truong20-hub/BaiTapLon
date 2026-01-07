using BLL.InterFace;
using BLL_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Model_;

namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        ISinhVienBLL _sinhVienBLL;
        public SinhVienController(ISinhVienBLL sinhVienBLL)
        {
            _sinhVienBLL = sinhVienBLL;
        }
        [HttpPost("createSV")]
        public IActionResult createSV([FromBody] SinhVien sv)
        {
            var result = _sinhVienBLL.ThemSV(sv);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateSV")]
        public IActionResult updateSV([FromBody] SinhVien sv)
        {
            var result = _sinhVienBLL.SuaSV(sv);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllSV")]
        public IActionResult getAllSV()
        {
            try
            {
                var result = _sinhVienBLL.GetAllSV();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteSV")]
        public IActionResult deleteSV([FromBody]string iDSinhVien)
        {
            var result = _sinhVienBLL.XoaSV(iDSinhVien);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("getSVById")]
        public IActionResult Search([FromBody]SinhVien sv)
        {
            var k = _sinhVienBLL.Search(sv);
            return Ok(k);
        }
    }
}
