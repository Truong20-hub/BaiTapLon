using BLL;
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
    public class BangDiemController : ControllerBase
    {
        IBangDiemBLL _bangDiemBLL;
        public BangDiemController(IBangDiemBLL bangDiemBLL)
        {
            _bangDiemBLL = bangDiemBLL;
        }
        [HttpPost("createBD")]
        public IActionResult createBD(BangDiem bangDiem)
        {
            var result = _bangDiemBLL.ThemBangDiem(bangDiem);
            return Ok(new { Thongbao = result.k,XacNhan = result.h});
        }
        [HttpPost("updateBD")]
        public IActionResult updateBD(BangDiem bangDiem)
        {
            var result = _bangDiemBLL.SuaBangDiem(bangDiem);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllBD")]
        public IActionResult getAllBD()
        {
            try
            {

                var result = _bangDiemBLL.GetAllBangDiem();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpDelete("deleteBD")]
        public IActionResult deleteBD(string idBD)
        {
            var result = _bangDiemBLL.XoaBangDiem(idBD);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("getBDById")]
        public IActionResult Search(BangDiem bangDiem)
        {
            var k = _bangDiemBLL.Search(bangDiem);
            return Ok(k);
        }
    }
}
