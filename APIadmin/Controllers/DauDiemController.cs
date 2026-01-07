using BLL;
using BLL.InterFace;
using BLL_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class DauDiemController : ControllerBase
    {
        IDauDiemBLL _dauDiemBLL;
        public DauDiemController(IDauDiemBLL dauDiemBLL)
        {
            _dauDiemBLL = dauDiemBLL;
        }
        [HttpPost("createDD")]
        public IActionResult createDD(Model_.DauDiem dauDiem)
        {
            var result = _dauDiemBLL.ThemDauDiem(dauDiem);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updateDD")]
        public IActionResult updateDD(Model_.DauDiem dauDiem)
        {
            var result = _dauDiemBLL.SuaDauDiem(dauDiem);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllDD")]
        public IActionResult getAllDD()
        {
            try
            {

                var result = _dauDiemBLL.GetAllDauDiem();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteDD")]
        public IActionResult deleteDD([FromQuery] string idDD)
        {
            var result = _dauDiemBLL.XoaDauDiem(idDD);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("searchDD")]
        public IActionResult searchDD(Model_.DauDiem dauDiem)
        {
            var result = _dauDiemBLL.SearchDauDiem(dauDiem);
            return Ok(result);
        }
    }
}
