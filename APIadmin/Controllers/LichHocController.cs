using BLL;
using BLL.InterFace;
using BLL_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_;
namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class LichHocController : ControllerBase
    {
        ILichHocBLL _lichHocBLL;
        public LichHocController(ILichHocBLL _ilichHocBLL)
        {
            _lichHocBLL = _ilichHocBLL;
        }
        [HttpPost("createLichHoc")]
        public IActionResult createLichHoc(LichHoc lichHoc)
        {
            var result = _lichHocBLL.ThemLichHoc(lichHoc);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateBD")]
        public IActionResult updateLichHoc(LichHoc lichHoc)
        {
            var result = _lichHocBLL.SuaLichHoc(lichHoc);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpDelete("deleteLichHoc")]
        public IActionResult deleteLichHoc(string iDLichHoc)
        {
            var result = _lichHocBLL.XoaLichHoc(iDLichHoc);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllLichHoc")]
        public IActionResult getAllLichHoc()
        {
            try
            {
                var result = _lichHocBLL.GetAllLichHoc();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpPost("searchLichHoc")]
        public IActionResult searchLichHoc(LichHoc lichHoc)
        {
            try
            {
                var result = _lichHocBLL.SearchLichHoc(lichHoc);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
