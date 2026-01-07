using BLL.InterFace;
using BLL_;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace APIAdmin.Controllers
{
    [Route("api/admin/[controller]")]
    [ApiController]
    public class PhongHocController : ControllerBase
    {
        IPhongHocBLL _phongHocBLL;
        public PhongHocController(IPhongHocBLL phongHocBLL)
        {
            _phongHocBLL = phongHocBLL;
        }
        [HttpPost("createPH")]
        public IActionResult createPH(Model_.PhongHoc phongHoc)
        {
            var result = _phongHocBLL.ThemPhongHoc(phongHoc);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpPost("updatePH")]
        public IActionResult updatePH(Model_.PhongHoc phongHoc)
        {
            var result = _phongHocBLL.SuaPhongHoc(phongHoc);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpDelete("deletePH")]
        public IActionResult deletePH(string iDPhong)
        {
            var result = _phongHocBLL.XoaPhongHoc(iDPhong);
            return Ok(new { Thongbao = result.k, XacNhan = result.h });
        }
        [HttpGet("getAllPH")]
        public IActionResult getAllPH()
        {
            try
            {
                var result = _phongHocBLL.GetAllPhongHoc();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
        [HttpPost("searchPH")]
        public IActionResult searchPH(Model_.PhongHoc phongHoc)
        {
            var result = _phongHocBLL.SearchPhongHoc(phongHoc);
            return Ok(result);
        }
    }
}
