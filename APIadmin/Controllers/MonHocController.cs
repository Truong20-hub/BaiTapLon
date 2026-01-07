using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL_;
using BLL.InterFace;
using Model_;
namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class MonHocController : ControllerBase
    {
        IMonHocBLL _monHocBLL;
        public MonHocController(IMonHocBLL monHocBLL)
        {
            _monHocBLL = monHocBLL;
        }
        [HttpPost("createMH")]
        public IActionResult createMH(MonHoc mh)
        {
            var result = _monHocBLL.ThemMonHoc(mh);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateMH")]
        public IActionResult updateMH(MonHoc mh)
        {
            var result = _monHocBLL.SuaMonHoc(mh);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpDelete("deleteMH")]
        public IActionResult deleteMH(string idMH)
        {
            var result = _monHocBLL.XoaMonHoc(idMH);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllMH")]
        public IActionResult getAllMH()
        {
            try
            {
                var result = _monHocBLL.GetAllMonHoc();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpPost("searchMH")]
        public IActionResult searchMH(MonHoc mh)
        {
            try
            {
                var result = _monHocBLL.SearchMonHoc(mh);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
