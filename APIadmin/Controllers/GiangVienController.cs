using BLL.InterFace;
using BLL_;
using BLL_.InterFace;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_;

namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        IGiangVienBLL giangVienBLL;
        public GiangVienController(IGiangVienBLL giangVienBLL)
        {
            this.giangVienBLL = giangVienBLL;
        }
        [HttpPost("createGV")]
        public IActionResult createGV(GiangVien gv)
        {
            var result = giangVienBLL.ThemGV(gv);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateGV")]
        public IActionResult updateGV(GiangVien gv)
        {
            var result = giangVienBLL.SuaGV(gv);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllGV")]
        public IActionResult getAllGiangVien()
        {
            try
            {
                var result = giangVienBLL.GetAllGV();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteGV")]
        public IActionResult deleteGV([FromBody] string iDGV)
        {
            var result = giangVienBLL.XoaGV(iDGV);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("getSVById")]
        public IActionResult Search([FromBody] GiangVien gv)
        {
            var k = giangVienBLL.Search(gv);
            return Ok(k);
        }
    }
}
