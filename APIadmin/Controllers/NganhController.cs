using BLL.InterFace;
using BLL_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model_;

namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class NganhController : ControllerBase
    {
        INganhBLL _nganhBLL;
        public NganhController( INganhBLL nganhBLL)
        {
            _nganhBLL = nganhBLL;
        }
        [HttpPost("createNganh")]
        public IActionResult createNganh(Nganh ng)
        {
            var result = _nganhBLL.ThemNganh(ng);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateNganh")]
        public IActionResult updateNganh(Nganh ng)
        {
            var result = _nganhBLL.SuaNganh(ng);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllNganh")]
        public IActionResult getAllNganh()
        {
            try
            {
                var result = _nganhBLL.GetAllNganh();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteNganh")]
        public IActionResult deleteNganh([FromBody] string iDNganh)
        {
            var result = _nganhBLL.XoaNganh(iDNganh);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("getSVById")]
        public IActionResult Search([FromBody] Nganh ng)
        {
            var k = _nganhBLL.Search(ng);
            return Ok(k);
        }
    }

}
