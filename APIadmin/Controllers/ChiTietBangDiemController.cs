using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL_;
using BLL.InterFace;
namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class ChiTietBangDiemController : ControllerBase
    {
        IChiTietBangDiemBLL _chiTietBangDiemBLL;
        public ChiTietBangDiemController(IChiTietBangDiemBLL chiTietBangDiemBLL)
        {
            _chiTietBangDiemBLL = chiTietBangDiemBLL;
        }
        [HttpPost("createCTBD")]
        public IActionResult createIDCTBD(Model_.ChiTietBangDiem chiTietBangDiem)
        {
            var result = _chiTietBangDiemBLL.ThemChiTietBangDiem(chiTietBangDiem);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateCTBD")]
        public IActionResult updateCTBD(Model_.ChiTietBangDiem chiTietBangDiem)
        {
            var result = _chiTietBangDiemBLL.SuaChiTietBangDiem(chiTietBangDiem);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllCTBD")]
        public IActionResult getAllCTBD()
        {
            try
            {
                var result = _chiTietBangDiemBLL.GetAllChiTietBangDiem();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteCTBD")]
        public IActionResult deleteCTBD(string idCTBD)
        {
            var result = _chiTietBangDiemBLL.XoaChiTietBangDiem(idCTBD);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("searchCTBD")]
        public IActionResult searchCTBD(Model_.ChiTietBangDiem chiTietBangDiem)
        {
            var result = _chiTietBangDiemBLL.SearchChiTietBangDiem(chiTietBangDiem);
            return Ok(result);
        }
    }
}
