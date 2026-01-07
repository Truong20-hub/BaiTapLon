using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL_;
using BLL_.InterFace;
using Model_;



namespace btlapi.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]

    public class KhoaController : ControllerBase
    {
        private IkhoaBLL _ikhoa;
        public KhoaController(IkhoaBLL ikhoa)
        {
            _ikhoa = ikhoa;
        }
        [Route("create-khoa")]
        
        [HttpPost]
        public IActionResult create([FromBody] Khoa khoa)
        {
            var result = _ikhoa.ThemKhoa(khoa);
            return Ok(new { j = result.i, i = result.k });
        }
        [HttpPost]
        public IActionResult update([FromBody] Khoa khoa)
        {
            var result = _ikhoa.SuaKhoa(khoa);
            return Ok(new { j = result.i, i = result.k });
        }
        [HttpGet("getAllKhoa")]
        public IActionResult getAllKhoa()
        {
            try
            {
                var result = _ikhoa.getAllKhoa();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteKhoa")]
        public IActionResult deleteKhoa([FromBody] string iDKhoa)
        {
            var result = _ikhoa.XoaKhoa(iDKhoa);
            return Ok(new { Thongbao = result.i, XacNhan = result.k });
        }
        [HttpPost("getSVById")]
        public IActionResult Search([FromBody] Khoa kh)
        {
            var k = _ikhoa.search(kh);
            return Ok(k);
        }
    }
}
