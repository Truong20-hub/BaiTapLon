using BLL;
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
    public class LichThiController : ControllerBase
    {
        ILichThiBLL _lichThiBLL;
        public LichThiController(ILichThiBLL lichThiBLL)
        {
            _lichThiBLL = lichThiBLL;
        }
        [HttpPost("createLichThi")]
        public IActionResult createLichThi([FromBody] LichThi lichThi)
        {
            var result = _lichThiBLL.ThemLichThi(lichThi);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateLichThi")]
        public IActionResult updateLichThi([FromBody] LichThi lichThi)
        {
            var result = _lichThiBLL.SuaLichThi(lichThi);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllLichThi")]
        public IActionResult getAllLichThi()
        {
            try
            {
                var result = _lichThiBLL.GetAllLichThi();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteLichThi")]
        public IActionResult deleteLichThi([FromQuery] string iDLichThi)
        {
            var result = _lichThiBLL.XoaLichThi(iDLichThi);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("searchLichThi")]
        public IActionResult searchLichThi([FromBody] LichThi lichThi)
        {
             var result = _lichThiBLL.SearchLichThi(lichThi);
             return Ok(result);
        }
    }
}
